using Godot;
using System;
using Shooter.Source.Interfaces;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Enemies
{

    public partial class Gooder : CharacterBody2D, IEnemy
    {
        private int _yspeed = 2;
        private int _xspeed = 6;
        private double _timer = 0;
        public bool _isAngry = false;
        public bool Walk = false;
        private float _speedModifier = 5;
        public int MaxTimer = 900;
        public override void _Process(double delta)
        {
            MoveEnemy(delta);
        }

        private void MoveEnemy(double delta)
        {
            if (_isAngry)
                DoAngryBehavior(delta);
            else
                DoNormalBehavior(delta);

            _timer += delta * 60;
        }

        private void DoNormalBehavior(double delta)
        {
            if (_timer < 50)
            {
                Position += new Vector2(x: 0, y: _yspeed * (float)(delta * 60));

            }
            else if (_timer > MaxTimer)
            {
                Position += new Vector2(x: 0, y: -_yspeed * (float)(delta * 60));
            }
            else if (Walk)
            {
                Position += new Vector2(x: _xspeed * (float)(delta * 60), y: 0);

                if (Position.X > 1412 || Position.X < 32)
                    _xspeed *= -1;
            }
        }

        private void DoAngryBehavior(double delta)
        {
            if (_timer < 500)
            {
                FollowPlayer(delta);

                if ((int)_timer % 20 == 0)
                {
                    Shoot();
                }
            }
            else
            {
                EnemySpawner.GetEnemySpawner().DestroyEnemy(this);
            }
        }

        private void Shoot()
        {
            var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
            var angle = Math.Atan2(Position.X - player.Position.X, Position.Y - player.Position.Y);
            var projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");

            projectiles.AddProjectile(new DNormalProjectile(Position.X + 2, Position.Y + 26, (float)Math.Sin(angle) * -5, (float)Math.Cos(angle) * -5));
        }

        private void FollowPlayer(double delta)
        {
            var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
            var angle = Math.Atan2(Position.X - player.Position.X, Position.Y - player.Position.Y);

            var xspeed = (float)Math.Sin(angle) * -_speedModifier;
            var yspeed = (float)Math.Cos(angle) * -_speedModifier;

            Position += new Vector2(x: xspeed * (float)(delta * 60), y: yspeed * (float)(delta * 60));
        }

        public void OnScreenExited()
            => EnemySpawner.GetEnemySpawner().RemoveEnemy(this);

        public bool IsImortal()
            => false;

        public void Destroy()
        {
            if (_isAngry)
            {
                if (GameManager.IsSpecialMode)
                {
                    EnemySpawner.GetEnemySpawner().DestroyEnemy(this);
                    return;
                }
                _speedModifier += 0.5f;
                return;
            }

            MakeAngry();
        }

        public void MakeAngry()
        {
            _isAngry = true;
            GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("Angry");
            _timer = 0;
        }

        public EnemyBoundy GetBoundy()
            => new(hpUpPoints: 2, bulletPoints: 2, position: Position);
    }
}
