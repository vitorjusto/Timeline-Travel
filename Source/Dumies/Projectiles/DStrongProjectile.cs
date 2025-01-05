using Godot;
using Shooter.Source.Dumies.Interfaces;
using Shooter.Source.Interfaces;

namespace Shooter.Source.Dumies.Projectiles
{
    public class DStrongProjectile : IProjectileDummy
    {
        public float X;
        public float Y;
        public float XSpeed;
        public float YSpeeed;

        public DStrongProjectile(float x, float y, float xSpeed, float ySpeeed)
        {
            X = x;
            Y = y;
            XSpeed = xSpeed;
            YSpeeed = ySpeeed;
        }

        public Node2D GetInstance()
        {
            PackedScene scene;
            if(GameManager.IsSpecialMode)
            {
                scene = GD.Load<PackedScene>("res://Scenes/Projectiles/EnemyProjectiles/SpecialProjectile.tscn");
            }else
            {
                scene = GD.Load<PackedScene>("res://Scenes/Projectiles/EnemyProjectiles/StrongProjectile.tscn");
            }
            
            var instance = scene.Instantiate<Node2D>();

            ((IEnemyProjectile)instance).SetPosition(X, Y);
            ((IEnemyProjectile)instance).SetSpeed(XSpeed, YSpeeed);

            return instance;
        }
    }
}