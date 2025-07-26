
using System;
using Godot;
using Shooter.Source.Interfaces;

namespace Shooter.Source.Models.Bosses.BossLevelNine.States
{
    public class StartCruchingPlayerState : IState
    {
        private Node2D _boss;
        private Player _player;
        private bool _nearPlayer;

        private int _timer;

        public StartCruchingPlayerState(Node2D boss)
        {
            _boss = boss;
            _boss.GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("AttackReady");
            _player = _boss.GetTree().Root.GetNode<Player>("/root/Main/Player");
        }

        public IState NextState()
        {
            return new HoldingPlayerState(_boss);
        }

        public bool Process(double delta)
        {

            if(_nearPlayer)
                FollowPlayer();

            else if(_timer < 50)
            {
                _timer++;
                return false;
            }
            else
                Dash();
                
            return _nearPlayer && _timer > 100;
        }

        private void FollowPlayer()
        {
            _boss.Position = new Vector2(_player.Position.X, _player.Position.Y - 128);
            _timer++;
        }

        private void Dash()
        {
            
            var angle = Math.Atan2(_boss.Position.X - _player.Position.X, _boss.Position.Y - _player.Position.Y + 128);
            _boss.Position += new Vector2((float)Math.Sin(angle) * (-20), (float)Math.Cos(angle) * (-20));

            if(Math.Abs(_player.Position.X - _boss.Position.X) < 30 && Math.Abs(_player.Position.X - _boss.Position.X) < 158)
            {
                _nearPlayer = true;
                _timer = 0;
            }
        }
    }
}