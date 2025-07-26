using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Enemies
{

    public partial class Crusader : CharacterBody2D, IEnemy, INonExplodable
    {
        private float _speed = 0;

        private QuickTimer _timer = new(185);
        private bool _isExplosing = false;

        public override void _Ready()
        {
            GetNode<CollisionShape2D>("CollisionShape2D").Disabled = true;
        }

        public override void _Process(double delta)
        {
            if (_timer.Time < 150 && !_isExplosing)
                MoveEnemy(delta);
            else if (_timer.Time >= 150 && !_isExplosing)
                Explode();
            
            if (_timer.Process(delta))
                EnemySpawner.GetEnemySpawner().RemoveEnemy(this);
        }

        private void Explode()
        {                
            _isExplosing = true;
             AudioManager.OnExplosion();

             var animation = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
             animation.Play("RayLazer");
             animation.ApplyScale(new Vector2(x: 1, y: 990));

             var collision = GetNode<CollisionShape2D>("CollisionShape2D");
             collision.ApplyScale(new Vector2(x: 1, y: 990));

             animation = GetNode<AnimatedSprite2D>("AuxAnimatedSprite");
             animation.Play("RayLazer");
             animation.ApplyScale(new Vector2(x: 1444, y: 1));

             collision = GetNode<CollisionShape2D>("AuxCollision");
             collision.ApplyScale(new Vector2(x: 1444, y: 1));

             GetNode<Sprite2D>("Crusader").Visible = false;
        }

        private void MoveEnemy(double delta)
            => Position += new Vector2(x: 0, y: _speed * (float)(delta * 60));

        public void SetSpeed(float speed)
            => _speed = speed;

        public void OnScreenExited()
            => EnemySpawner.GetEnemySpawner().RemoveEnemy(this);

        public bool IsImortal()
            => _isExplosing;


        public void Destroy()
        {
            if (_isExplosing)
                return;

            Explode();
            _timer = new(35);
        }

        public EnemyBoundy GetBoundy()
            => new();

        public void OnScreenEntered()
            => GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;
    }
}