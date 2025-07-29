
using System;
using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Bosses.BossLevelNine.States
{
    public class StartCruchingPlayerState : IState
    {
        private Node2D _boss;
        private Player _player;
        private bool _nearPlayer;

        private QuickTimer _timer = new(100);

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

            else if(_timer.Time > 50)
                Dash(delta);
                
            return _timer.Process(delta) && _nearPlayer;
        }

        private void FollowPlayer()
        {
            _boss.Position = new Vector2(_player.Position.X, _player.Position.Y - 128);
        }

        private void Dash(double delta)
        {
            
            var angle = Math.Atan2(_boss.Position.X - _player.Position.X, _boss.Position.Y - _player.Position.Y + 128);
            _boss.Position += new Vector2((float)Math.Sin(angle) * (-20), (float)Math.Cos(angle) * (-20)) * (float)(delta * 60);

            if(Math.Abs(_player.Position.X - _boss.Position.X) < 30 && Math.Abs(_player.Position.X - _boss.Position.X) < 158)
            {
                _nearPlayer = true;
                _timer.Reset();
            }
        }
    }
}