using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;
using Shooter.Source.Enums;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Enemies
{
    public partial class Spread : CharacterBody2D, IEnemy
    {
        public int Speed;
        private float _time = 0;
        private int _cycle = 0;
        public EEnemyProjectileType ProjectileType;
        public override void _Process(double delta)
        {
            _time += (float)(delta * 60);

            MoveEnemy(delta);
            VerifyShoot();
        }

        private void VerifyShoot()
        {
            if (_time < 10)
                return;

            _time -= 10;
            _cycle++;

            if (_cycle == 8)
            {
                ShootProjectile(0, 1);
                _cycle = 0;
            }
            else if (_cycle == 1)
                ShootProjectile(-1, 1);
            else if (_cycle == 2)
                ShootProjectile(-1, 0);
            else if (_cycle == 3)
                ShootProjectile(-1, -1);
            else if (_cycle == 4)
                ShootProjectile(0, -1);
            else if (_cycle == 5)
                ShootProjectile(1, -1);
            else if (_cycle == 6)
                ShootProjectile(1, 0);
            else if (_cycle == 7)
                ShootProjectile(1, 1);
        }

        private void MoveEnemy(double delta)
            => Position += new Vector2(x: 0, y: Speed * (float)(delta * 60));

        private void ShootProjectile(float xspeed, float yspeed)
        {
            var projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");

            if (ProjectileType == EEnemyProjectileType.Normal)
                projectiles.AddProjectile(new DNormalProjectile(Position.X + xspeed * 30, Position.Y + yspeed * 30, xspeed * 4, yspeed * 4));
            else if (ProjectileType == EEnemyProjectileType.Light)
                projectiles.AddProjectile(new DLightProjectile(Position.X + xspeed * 30, Position.Y + yspeed * 30, xspeed * 6, yspeed * 6));
            else if (ProjectileType == EEnemyProjectileType.Strong)
                projectiles.AddProjectile(new DStrongProjectile(Position.X + xspeed * 30, Position.Y + yspeed * 30, xspeed * 3, yspeed * 3));
        }

        public void OnScreenExited()
            => EnemySpawner.GetEnemySpawner().RemoveEnemy(this);

        public void Destroy()
            => EnemySpawner.GetEnemySpawner().DestroyEnemy(this);

        public bool IsImortal()
            => false;

        public EnemyBoundy GetBoundy()
            => new(hpUpPoints: 2, bulletPoints: 2, position: Position);
    }
}