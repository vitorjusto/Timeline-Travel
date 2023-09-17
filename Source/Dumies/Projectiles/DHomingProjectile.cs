using Godot;
using Shooter.Source.Dumies.Interfaces;

namespace Shooter.Source.Dumies.Projectiles
{
    public class DHomingProjectile : IProjectileDummy
    {
        public float X;
        public float Y;

        public DHomingProjectile(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Projectiles/EnemyProjectiles/HomingProjectile.tscn");

            var instance = (HomingProjectile)scene.Instantiate();

            instance.SetPosition(X, Y);

            return instance;
        }
    }
}