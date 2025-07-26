using Godot;
using System;
using Shooter.Source.Interfaces;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Enemies
{
    public partial class Bomber : CharacterBody2D, IEnemy
    {
        private int _speed = 12;
        private readonly QuickTimer _timer = new(70);

        public override void _Process(double delta)
            => MoveEnemy(delta);

        private void MoveEnemy(double delta)
        {
            if (_timer.Process(delta))
            {
                Destroy();
                return;
            }

            var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
            var angle = Math.Atan2(Position.X - player.Position.X, Position.Y - player.Position.Y);

            var x = Position.X + (float)Math.Sin(angle) * _speed * -1 * (float)(delta * 60);
            var y = Position.Y + (float)Math.Cos(angle) * _speed * -1 * (float)(delta * 60);
            Position = new Vector2(x, y);

            Scale = new Vector2(Math.Abs(Scale.X), Scale.Y);
            Scale *= new Vector2(Position.X - player.Position.X < 0 ? 1 : -1, 1);
        }

        public void Destroy()
        {
            var projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");
            projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 5, 5));
            projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 5, -5));
            projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, -5, 5));
            projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, -5, -5));

            projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 5, 0));
            projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 0, 5));
            projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, -5, 0));
            projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 0, -5));

            projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 5, 2.5f));
            projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, -5, 2.5f));
            projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 2.5f, 5));
            projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 2.5f, -5));

            projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 5, -2.5f));
            projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, -5, -2.5f));
            projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, -2.5f, 5));
            projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, -2.5f, -5));

            EnemySpawner.GetEnemySpawner().DestroyEnemy(this);
        }

        public void OnScreenExited()
            => EnemySpawner.GetEnemySpawner().RemoveEnemy(this);

        public bool IsImortal()
            => false;

        public EnemyBoundy GetBoundy()
            => new();
    }
}