using System;
using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Bosses.BossLevelNine.States
{
    public class HoldingPlayerState : IState
    {
        private Node2D _boss;
        private Player _player;
        private Vector2 _speed;
        private QuickTimer _timer = new(100);

        public HoldingPlayerState(Node2D boss)
        {
            _boss = boss;
            _boss.GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("CruchingPlayer");
            _player = _boss.GetTree().Root.GetNode<Player>("/root/Main/Player");
            _player.DisablePlayerToMove();

            var angle = Math.Atan2(_boss.Position.X - 700, _boss.Position.Y - 450);

            _speed = new Vector2((float)Math.Sin(angle) * (-2), (float)Math.Cos(angle) * (-2));
        }

        public IState NextState()
        {
            return new MovingState(_boss);
        }

        public bool Process(double delta)
        {
            if(_timer.Process(delta))
            {
                DestroyPlayer();
                return true;
            }
            else
            {
                _boss.Position += _speed * (float)(delta * 60);
                _player.Position += _speed * (float)(delta * 60);
            }                

            return false;
        }

        private void DestroyPlayer()
        {
            _boss.GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("PlayerCruched");
            _player.DestroyPlayer();
            _player.EnablePlayerToMove();
        }
    }
}