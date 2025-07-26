using Godot;
using System;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Enemies
{
    public partial class Dasher : CharacterBody2D, IEnemy
    {
        private int _speed = 3;
        private float _xspeed = 0;
        private float _yspeed = 0;

        private bool _targetHid;
        private bool _showedTarget;

        private readonly QuickTimer _timer = new(9999);

        public override void _Ready()
            => GetNode<Node2D>("ReinforcedDasher").Visible = GameManager.IsSpecialMode;

        public override void _Process(double delta)
        {
            MoveEnemy(delta);

            _timer.Process(delta);
        }

        private void MoveEnemy(double delta)
        {
            if (_timer.Time < 50)
            {
                Position += new Vector2(x: 0, y: _speed * (float)(delta * 60));

            }
            else if (_timer.Time > 51 && !_showedTarget)
            {
                var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
                player.ShowTarget();
                _showedTarget = true;
            }
            else if (_timer.Time < 139)
            {
                Animate();
            }
            else if (_timer.Time > 139 && !_targetHid)
            {
                var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
                var angle = Math.Atan2(Position.X - player.Position.X, Position.Y - player.Position.Y);

                _xspeed = (float)Math.Sin(angle) * -20;
                _yspeed = (float)Math.Cos(angle) * -20;

                player.HideTarget();
                _targetHid = true;
            }
            else if (_timer.Time > 140)
            {
                Position += new Vector2(x: _xspeed, y: _yspeed * (float)(delta * 60));
            }
        }

        private void Animate()
        {
            var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
            var angle = Math.Atan2(Position.X - player.Position.X, Position.Y - player.Position.Y);
            var speed = new Vector2((float)Math.Sin(angle), (float)Math.Cos(angle));

            GetNode<Node2D>("Dasher").Rotation = 90;
            GetNode<Node2D>("ReinforcedDasher").Rotation = 90;
            Rotation = speed.Angle();
        }

        public void OnScreenExited()
            => EnemySpawner.GetEnemySpawner().RemoveEnemy(this);

        public void Destroy()
        {
            if (GameManager.IsSpecialMode)
                return;

            EnemySpawner.GetEnemySpawner().DestroyEnemy(this);

            if (!_targetHid)
                GetTree().Root.GetNode<Player>("/root/Main/Player").HideTarget();
        }

        public bool IsImortal()
            => GameManager.IsSpecialMode;

        public EnemyBoundy GetBoundy()
            => new(hpUpPoints: 1, bulletPoints: 0, position: Position);
    }
}