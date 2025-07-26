using System;
using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;
using Shooter.Source.Enums;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Enemies
{
    public partial class Sniper : CharacterBody2D, IEnemy
    {
        private int _speed = 9;
        private readonly QuickTimer _timer = new(900);

        public EEnemyProjectileType ProjectileType;
        private bool _shooted;

        public override void _Process(double delta)
        {
            MoveEnemy(delta);

            _timer.Process(delta);
        }

        private void MoveEnemy(double delta)
        {
            if (_timer.Time < 15)
            {
                Position += new Vector2(x: 0, y: _speed * (float)(delta * 60));

            }
            else if (_timer.Time >= 35 && !_shooted)
            {
                ShootProjectile();
                _shooted = true;
            }
            else if (_timer.Time > 50)
            {
                Position += new Vector2(x: 0, y: -_speed * (float)(delta * 60));
            }
        }

        private void ShootProjectile()
        {
            var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
            var angle = Math.Atan2(Position.X - player.Position.X, Position.Y - player.Position.Y);
            var projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");

            if (ProjectileType == EEnemyProjectileType.Normal)
                projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y + 41, (float)Math.Sin(angle) * -3, (float)Math.Cos(angle) * -3));
            else if (ProjectileType == EEnemyProjectileType.Light)
                projectiles.AddProjectile(new DLightProjectile(Position.X, Position.Y + 41, (float)Math.Sin(angle) * -3, (float)Math.Cos(angle) * -3));
            else if (ProjectileType == EEnemyProjectileType.Strong)
                projectiles.AddProjectile(new DStrongProjectile(Position.X, Position.Y + 41, (float)Math.Sin(angle) * -3, (float)Math.Cos(angle) * -3));
            else if (ProjectileType == EEnemyProjectileType.Homing)
                projectiles.AddProjectile(new DHomingProjectile(Position.X, Position.Y + 41));

            if (GameManager.IsSpecialMode)
            {
                projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y + 41, (float)Math.Sin(angle - 0.5) * -3, (float)Math.Cos(angle - 0.5) * -3));
                projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y + 41, (float)Math.Sin(angle + 0.5) * -3, (float)Math.Cos(angle + 0.5) * -3));
            }
        }

        public void OnScreenExited()
            => EnemySpawner.GetEnemySpawner().RemoveEnemy(this);

        public void Destroy()
            => EnemySpawner.GetEnemySpawner().DestroyEnemy(this);

        public bool IsImortal()
            => false;

        public EnemyBoundy GetBoundy()
            => new(hpUpPoints: 2, bulletPoints: 1, position: Position);
    }
}