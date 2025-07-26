using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Dumies.Enemies.EnemiesPart;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Enemies
{
    public partial class Lazer : CharacterBody2D, IEnemy
    {
        private int _yspeed = 8;
        private float _time = 0;
        private bool _isShooting = false;
        public int MaxTime = 201;
        public override void _Process(double delta)
        {
            if (_isShooting)
                Shoot(delta);
            else
                MoveEnemy(delta);
        }

        private void MoveEnemy(double delta)
        {
            if (_time < 10)
            {
                Position += new Vector2(0, y: _yspeed * (float)(delta * 60));
            }
            else
            {
                AudioManager.OnLaser();
                _isShooting = true;
                _time = 0;
            }

            _time+= (float)(delta * 60);
        }

        private void Shoot(double delta)
        {
            _time+= (float)(delta * 60);

            if (_time > MaxTime)
            {
                Position += new Vector2(x: 0, y: -_yspeed * (float)(delta * 60));
            }
            else
            {
                var y = Position.Y + 20 * _time;

                if (y > 900)
                    return;

                var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

                enemySpawner.AddEnemy(new DLazerPart(Position.X, y, MaxTime));
            }
        }

        public void OnScreenExited()
            => EnemySpawner.GetEnemySpawner().RemoveEnemy(this);

        public bool IsImortal()
            => true;

        public void Destroy(){}

        public EnemyBoundy GetBoundy()
        {
            if (_isShooting)
                return new();

            return new(1, 1, Position);
        }
    }
}