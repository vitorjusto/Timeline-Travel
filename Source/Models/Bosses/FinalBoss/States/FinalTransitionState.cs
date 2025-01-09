using System;
using Godot;
using Shooter.Source.Interfaces;

namespace shooter.Source.Models.Bosses.FinalBoss.States
{
    public class FinalTransitionState : IState
    {
        private Player _player;
        private Panel _panel;
        private int _playerSpeed = -10;
        private byte _panelOpacity = 0;

        public FinalTransitionState(Player player, Panel panel)
        {
            _player = player;
            _player.OnEndingLevel();
            _panel = panel;
        }

        public IState NextState()
        {
            return null;
        }

        public bool Process()
        {
            AnimatePlayer();
            CreateExplosions();
            ModulatePanel();
            return false;
        }

        private void ModulatePanel()
        {
            if(_panelOpacity == 255)
            {
                _player.GetTree().ChangeSceneToFile("res://Scenes/Misc/FinalCutscene.tscn");
                if(GameManager.IsSpecialMode)
                {
                    SaveManager.Data.BossRushUnlocked = true;
                    SaveManager.Save();
                }else if(!EnemySpawner.GetEnemySpawner().isBossRush)
                {
                    SaveManager.Data.SpecialModeUnlocked = true;
                    SaveManager.Save();
                }
                
                return;
            }

            _panelOpacity++;
            _panel.Modulate = Color.Color8(255, 255, 255, _panelOpacity);
        }

        private void CreateExplosions()
        {
            EnemySpawner.GetEnemySpawner().AddExplosion(new Random().Next(0, 1444), new Random().Next(0, 940), addScore: false);
        }

        private void AnimatePlayer()
        {
            if(_player.Position.Y < -150)
            {
                _playerSpeed = 10;
                _player.Scale = new Vector2(1, -1);
            }
            
            _player.SetSpeed(0, _playerSpeed, -160);
        }
    }
}