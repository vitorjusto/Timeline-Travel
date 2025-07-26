using System;
using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;
using Shooter.Source.Enums;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Enemies
{
    public partial class Shoter : CharacterBody2D, IEnemy
    {
        private int _speed = 3;
        private int _timeShooted = 0;
        private float _time = 0;

        public EEnemyProjectileType ProjectileType;

        public override void _Process(double delta)
        {
            MoveEnemy(delta);

            _time+= (float)(delta * 60);
        }

        private void MoveEnemy(double delta)
        {
            if (_timeShooted == 15)
            {
                Position += new Vector2(x: 0, y: -_speed * (float)(delta * 60));
                return;
            }

            if (_time < 50)
            {
                Position += new Vector2(x: 0, y: _speed * (float)(delta * 60));
            }
            else if (_time >= 100)
            {
                ShootProjectile();
                _time = 50;
                _timeShooted++;
            }
        }

        private void ShootProjectile()
        {
            var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
            var angle = Math.Atan2(Position.X - player.Position.X, Position.Y - player.Position.Y);
            var projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");

            if (ProjectileType == EEnemyProjectileType.Normal)
            {
                projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y + 30, (float)Math.Sin(angle) * -3, (float)Math.Cos(angle) * -3));
                projectiles.AddProjectile(new DNormalProjectile(Position.X + 42, Position.Y + 18, (float)Math.Sin(angle + 0.6) * -3, (float)Math.Cos(angle + 0.6) * -3));
                projectiles.AddProjectile(new DNormalProjectile(Position.X - 42, Position.Y + 18, (float)Math.Sin(angle - 0.6) * -3, (float)Math.Cos(angle - 0.6) * -3));
                projectiles.AddProjectile(new DNormalProjectile(Position.X + 21, Position.Y + 21, (float)Math.Sin(angle + 0.3) * -3, (float)Math.Cos(angle + 0.3) * -3));
                projectiles.AddProjectile(new DNormalProjectile(Position.X - 21, Position.Y + 21, (float)Math.Sin(angle - 0.3) * -3, (float)Math.Cos(angle - 0.3) * -3));
            }
            else if (ProjectileType == EEnemyProjectileType.Light)
            {
                projectiles.AddProjectile(new DLightProjectile(Position.X, Position.Y + 30, (float)Math.Sin(angle) * -3, (float)Math.Cos(angle) * -3));
                projectiles.AddProjectile(new DLightProjectile(Position.X + 42, Position.Y + 18, (float)Math.Sin(angle + 0.6) * -3, (float)Math.Cos(angle + 0.6) * -3));
                projectiles.AddProjectile(new DLightProjectile(Position.X - 42, Position.Y + 18, (float)Math.Sin(angle - 0.6) * -3, (float)Math.Cos(angle - 0.6) * -3));
                projectiles.AddProjectile(new DLightProjectile(Position.X + 21, Position.Y + 21, (float)Math.Sin(angle + 0.3) * -3, (float)Math.Cos(angle + 0.3) * -3));
                projectiles.AddProjectile(new DLightProjectile(Position.X - 21, Position.Y + 21, (float)Math.Sin(angle - 0.3) * -3, (float)Math.Cos(angle - 0.3) * -3));
            }
            else if (ProjectileType == EEnemyProjectileType.Strong)
            {
                projectiles.AddProjectile(new DStrongProjectile(Position.X, Position.Y + 30, (float)Math.Sin(angle) * -3, (float)Math.Cos(angle) * -3));
                projectiles.AddProjectile(new DStrongProjectile(Position.X + 42, Position.Y + 18, (float)Math.Sin(angle + 0.6) * -3, (float)Math.Cos(angle + 0.6) * -3));
                projectiles.AddProjectile(new DStrongProjectile(Position.X - 42, Position.Y + 18, (float)Math.Sin(angle - 0.6) * -3, (float)Math.Cos(angle - 0.6) * -3));
                projectiles.AddProjectile(new DStrongProjectile(Position.X + 21, Position.Y + 21, (float)Math.Sin(angle + 0.3) * -3, (float)Math.Cos(angle + 0.3) * -3));
                projectiles.AddProjectile(new DStrongProjectile(Position.X - 21, Position.Y + 21, (float)Math.Sin(angle - 0.3) * -3, (float)Math.Cos(angle - 0.3) * -3));
            }
            else if (ProjectileType == EEnemyProjectileType.Homing)
                projectiles.AddProjectile(new DHomingProjectile(Position.X, Position.Y + 36));
        }

        public void OnScreenExited()
            => EnemySpawner.GetEnemySpawner().RemoveEnemy(this);

        public void Destroy()
            => EnemySpawner.GetEnemySpawner().DestroyEnemy(this);

        public bool IsImortal()
            => false;

        public EnemyBoundy GetBoundy()
            => new(hpUpPoints: 3, bulletPoints: 2, position: Position);
    }
}