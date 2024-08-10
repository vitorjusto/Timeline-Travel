using System;
using Godot;
using Shooter.Source.Interfaces;

namespace Shooter.Source.Models.Bosses.BossLevelNine.States
{
    public class HoldingPlayerState : IState
    {
        private Node2D _boss;
        private Player _player;
        private Vector2 _speed;
        private int _timer;

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
            return null;
        }

        public bool Process()
        {
            _timer++;

            if(_timer == 100)
                DestroyPlayer();
            else if(_timer < 100)
            {
                _boss.Position += _speed;
                _player.Position += _speed;
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