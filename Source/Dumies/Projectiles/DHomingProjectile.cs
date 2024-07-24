using Godot;
using Shooter.Source.Dumies.Interfaces;

namespace Shooter.Source.Dumies.Projectiles
{
    public class DHomingProjectile : IProjectileDummy
    {
        public float X;
        public float Y;
        private float _speedModifier;

        public DHomingProjectile(float x, float y, float speedModifier = 3)
        {
            X = x;
            Y = y;
            _speedModifier = speedModifier;
        }

        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Projectiles/EnemyProjectiles/HomingProjectile.tscn");

            var instance = (HomingProjectile)scene.Instantiate();

            instance.SetPosition(X, Y);
            instance.SpeedModifier = _speedModifier;
            
            return instance;
        }
    }
}