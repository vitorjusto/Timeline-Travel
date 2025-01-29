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

        private int _timer = 0;
        private int _explosionCooldown;

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
                _timer++;

                if(_timer < 100)
                    return;

                _player.GetTree().ChangeSceneToFile("res://Scenes/Misc/FinalEndings/FinalCutscene.tscn");

                return;
            }

            _panelOpacity++;
            _panel.Modulate = Color.Color8(255, 255, 255, _panelOpacity);
        }

        private void CreateExplosions()
        {
            if(_explosionCooldown == 0)
            {
                EnemySpawner.GetEnemySpawner().AddExplosion(new Random().Next(0, 1444), new Random().Next(0, 940), addScore: false, makeSound: true);
                _explosionCooldown = 10;
            }else
            {
                
                EnemySpawner.GetEnemySpawner().AddExplosion(new Random().Next(0, 1444), new Random().Next(0, 940), addScore: false, makeSound: false);
                _explosionCooldown--;
            }
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