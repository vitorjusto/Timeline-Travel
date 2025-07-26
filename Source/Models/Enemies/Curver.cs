using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Enemies
{
    public partial class Curver : CharacterBody2D, IEnemy
    {
        private int _speed = 3;
        private WaveSpeed _xSpeed;
        private float _time = 0f;
    
        public override void _Process(double delta)
        {
            MoveEnemy(delta);
        }
    
        private void MoveEnemy(double delta)
            => Position = new Vector2(x: _xSpeed.Update(delta), y: Position.Y + (_speed * (float)(delta * 60)));
    
        public void OnScreenExited()
            => EnemySpawner.GetEnemySpawner().RemoveEnemy(this);
    
        public bool IsImortal()
            => false;
    
        public void SetPosition(float x)
        {
            _xSpeed = new WaveSpeed(-6, 30, x);
            Position = new Vector2(x, y: -30);
        }
    
        public void Destroy()
            => EnemySpawner.GetEnemySpawner().DestroyEnemy(this);
    
        public EnemyBoundy GetBoundy()
            => new(hpUpPoints: 1, bulletPoints: 0, position: Position);
    }
}