using Godot;
using System;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Enemies
{
    public partial class Orbiter : CharacterBody2D, IEnemy
    {
        private int _speed = 10;
        private bool _isRotating = false;

        private int _rotationCycle = 0;
        private bool _selfDestructing = false;
        private double _angle = 270;

        public override void _Ready()
        {
            var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
            Position = new Vector2(x: player.Position.X, y: 1000);
        }

        public override void _Process(double delta)
        {
            MoveEnemy(delta);
        }

        private void MoveEnemy(double delta)
        {
            var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
            if (_selfDestructing)
            {
                Position = new Vector2(x: player.Position.X, y: Position.Y + _speed * 3 * (float)(delta * 60));
            }
            else if (_isRotating)
            {
                Rotate(delta);
            }
            else
            {
                Position = new Vector2(x: player.Position.X, y: Position.Y - _speed * (float)(delta * 60));

                if (Position.Y - player.Position.Y < 150)
                    _isRotating = true;
            }
        }

        public void Rotate(double delta)
        {
            var player = GetTree().Root.GetNode<Player>("/root/Main/Player");

            _angle += 5 * (float)(delta * 60);

            var radian = -_angle * (Math.PI / 180);

            Position = new Vector2((int)(Math.Cos(radian) * 140) + player.Position.X, (int)(Math.Sin(radian) * 140) + player.Position.Y);

            if (_angle > 360)
            {
                _angle -= 360;
                _rotationCycle++;
            }

            _selfDestructing = _rotationCycle == 4 && _angle > 90;
        }

        public void OnScreenExited()
            => EnemySpawner.GetEnemySpawner().RemoveEnemy(this);

        public bool IsImortal()
            => false;

        public void Destroy()
            => EnemySpawner.GetEnemySpawner().DestroyEnemy(this);

        public EnemyBoundy GetBoundy()
            => new(hpUpPoints: 2, bulletPoints: 0, position: Position);
    }
}