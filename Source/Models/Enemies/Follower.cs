using Godot;
using System;
using Shooter.Source.Interfaces;
using Shooter.Source.Enums;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Enemies
{
    public partial class Follower : CharacterBody2D, IEnemy
    {
        private bool _isStopped;
        private float _xspeed = 1;
        private float _yspeed = 1;
        private int _speed = 10;
        private readonly QuickTimer _timer = new(999);
        public EEnemyProjectileType ProjectileType;
        public int _cicle = 1;
        private bool _isFollowing;
        private bool _isShooting;

        public override void _Process(double delta)
        {
            _timer.Process(delta);
            Update();
            Position += new Vector2(x: _xspeed * (float)(delta * 60), y: _yspeed * (float)(delta * 60));
        }

        private void Update()
        {
            if (_cicle > 5)
                return;

            if (!_isFollowing)
            {
                _isFollowing = true;
                FollowPlayer();
            }
            else if (_timer.Time >= 50 && !_isStopped)
            {
                _isStopped = true;
                _xspeed = 0;
                _yspeed = 0;
            }
            else if (_timer.Time >= 60 && !_isShooting)
            {
                _isShooting = true;
                ShootProjectile();
            }
            else if (_timer.Time >= 69)
            {
                _cicle++;
                _timer.Reset();

                _isFollowing = false;
                _isStopped = false;
                _isShooting = false;

                if (_cicle > 5)
                    FollowPlayer();
            }
        }

        private void FollowPlayer()
        {
            var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
            var angle = Math.Atan2(Position.X - player.Position.X, Position.Y - player.Position.Y);

            _xspeed = (float)Math.Sin(angle) * -_speed;
            _yspeed = (float)Math.Cos(angle) * -_speed;
        }

        private void ShootProjectile()
        {
            var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
            var angle = Math.Atan2(Position.X - player.Position.X, Position.Y - player.Position.Y);
            var projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");

            if (GameManager.IsSpecialMode)
            {
                projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y + 10, 5, 5));
                projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y + 10, 5, -5));
                projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y + 10, -5, 5));
                projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y + 10, -5, -5));

                projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y + 10, 5, 0));
                projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y + 10, 0, 5));
                projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y + 10, -5, 0));
                projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y + 10, 0, -5));

                projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y + 10, 5, 2.5f));
                projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y + 10, -5, 2.5f));
                projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y + 10, 2.5f, 5));
                projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y + 10, 2.5f, -5));

                projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y + 10, 5, -2.5f));
                projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y + 10, -5, -2.5f));
                projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y + 10, -2.5f, 5));
                projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y + 10, -2.5f, -5));

            }
            else if (ProjectileType == EEnemyProjectileType.Normal)
                projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y + 10, (float)Math.Sin(angle) * -3, (float)Math.Cos(angle) * -3));
            else if (ProjectileType == EEnemyProjectileType.Light)
                projectiles.AddProjectile(new DLightProjectile(Position.X, Position.Y + 10, (float)Math.Sin(angle) * -3, (float)Math.Cos(angle) * -3));
            else if (ProjectileType == EEnemyProjectileType.Strong)
                projectiles.AddProjectile(new DStrongProjectile(Position.X, Position.Y + 10, (float)Math.Sin(angle) * -3, (float)Math.Cos(angle) * -3));
            else if (ProjectileType == EEnemyProjectileType.Homing)
                projectiles.AddProjectile(new DHomingProjectile(Position.X, Position.Y + 10));
        }

        public void OnScreenExited()
            => EnemySpawner.GetEnemySpawner().RemoveEnemy(this);

        public bool IsImortal()
            => false;

        public void Destroy()
            => EnemySpawner.GetEnemySpawner().DestroyEnemy(this);

        public EnemyBoundy GetBoundy()
            => new(hpUpPoints: 1, bulletPoints: 1, position: Position);
    }
}