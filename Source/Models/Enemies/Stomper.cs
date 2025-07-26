using Godot;
using Shooter.Source.Enums;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;
using System;

namespace Shooter.Source.Models.Enemies
{

    public partial class Stomper : CharacterBody2D, IEnemy
    {
        private int _xSpeed = 5;
        private int _ySpeed = 5;

        private float _time = 0;
        private EDashStatus _dashStatus;
        private int _timeDashed = 0;

        public override void _Ready()
        {
            if (!GameManager.IsSpecialMode)
                return;

            _dashStatus = EDashStatus.Dashing;
            _timeDashed = 5;
            var player = GetTree().Root.GetNode<Player>("/root/Main/Player");

            Position = new Vector2(player.Position.X, -32);
            _time = 50;
            GetNode<Node2D>("ReiforcedStomper").Visible = true;
        }

        public override void _Process(double delta)
        {
            if (_time < 50)
            {
                Position += new Vector2(x: 0, y: _ySpeed * (float)(delta * 60));
                _time += (float)(delta * 60);
            }
            else
                FollowPlayer(delta);
        }

        private void FollowPlayer(double delta)
        {
            var player = GetTree().Root.GetNode<Player>("/root/Main/Player");

            var xSpeed = 0;
            float ySpeed = 0;

            if (Math.Abs(Position.X - player.Position.X) < 64 || _dashStatus == EDashStatus.Dashing)
            {
                ySpeed = _ySpeed * 4;
                _dashStatus = EDashStatus.Dashing;

                if (Position.Y + 96 >= GetViewport().GetWindow().Size.Y && _timeDashed < 5)
                {
                    _dashStatus = EDashStatus.GoingToOriginalPosition;
                    _timeDashed += 1;
                }
            }
            else if (_dashStatus == EDashStatus.GoingToOriginalPosition)
            {
                ySpeed = _ySpeed * -4;

                if (Position.Y + ySpeed <= 160)
                {
                    _dashStatus = EDashStatus.NotDashing;
                }
            }
            else if (Position.X < player.Position.X)
            {
                xSpeed = Math.Abs(_xSpeed) * 3;
            }
            else if (Position.X > player.Position.X)
            {
                xSpeed = Math.Abs(_xSpeed) * -3;
            }

            Position += new Vector2(x: xSpeed * (float)(delta * 60), y: ySpeed * (float)(delta * 60));
        }

        public void OnScreenExited()
            => EnemySpawner.GetEnemySpawner().RemoveEnemy(this);

        public bool IsImortal()
            => GameManager.IsSpecialMode;

        public void Destroy()
        {
            if (!GameManager.IsSpecialMode)
                EnemySpawner.GetEnemySpawner().DestroyEnemy(this);
        }

        public EnemyBoundy GetBoundy()
            => new(hpUpPoints: 2, bulletPoints: 0, position: Position);
    }
}