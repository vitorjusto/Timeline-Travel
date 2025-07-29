using System;
using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

namespace shooter.Source.Models.Bosses.FinalBoss.States
{
    public class FinalTransitionState : IState
    {
        private Player _player;
        private Panel _panel;
        private int _playerSpeed = -10;
        private float _panelOpacity = 0;

        private QuickTimer _timer = new(100);
        private float _explosionCooldown;

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

        public bool Process(double delta)
        {
            AnimatePlayer(delta);
            CreateExplosions(delta);
            ModulatePanel(delta);
            return false;
        }

        private void ModulatePanel(double delta)
        {
            if(_panelOpacity >= 255)
            {
                if(!_timer.Process(delta))
                    return;

                _player.GetTree().ChangeSceneToFile("res://Scenes/Misc/FinalEndings/FinalCutscene.tscn");

                return;
            }

            _panelOpacity += (float)(delta * 60);
            _panel.Modulate = Color.Color8(255, 255, 255, (byte)Math.Clamp(_panelOpacity, 0, 255));
        }

        private void CreateExplosions(double delta)
        {
            if(_explosionCooldown <= 0)
            {
                EnemySpawner.GetEnemySpawner().AddExplosion(new Random().Next(0, 1444), new Random().Next(0, 940), addScore: false, makeSound: true);
                _explosionCooldown += 10;
            }else
            {
                
                EnemySpawner.GetEnemySpawner().AddExplosion(new Random().Next(0, 1444), new Random().Next(0, 940), addScore: false, makeSound: false);
                _explosionCooldown -= (float)(delta * 60);
            }
        }

        private void AnimatePlayer(double delta)
        {
            if(_player.Position.Y < -150)
            {
                _playerSpeed = 10;
                _player.Scale = new Vector2(1, -1);
            }
            
            _player.SetSpeed(0, _playerSpeed * (float)(delta * 60), -160);
        }
    }
}