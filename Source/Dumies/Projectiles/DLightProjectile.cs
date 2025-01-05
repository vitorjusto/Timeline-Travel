using Godot;
using Shooter.Source.Dumies.Interfaces;
using Shooter.Source.Interfaces;

namespace Shooter.Source.Dumies.Projectiles
{
    public class DLightProjectile : IProjectileDummy
    {

        public float X;
        public float Y;
        public float XSpeed;
        public float YSpeeed;

        public DLightProjectile(float x, float y, float xSpeed, float ySpeeed)
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
                scene = GD.Load<PackedScene>("res://Scenes/Projectiles/EnemyProjectiles/LightProjectile.tscn");
            }

            var instance = scene.Instantiate<Node2D>();

            ((IEnemyProjectile)instance).SetPosition(X, Y);
            ((IEnemyProjectile)instance).SetSpeed(XSpeed, YSpeeed);

            return instance;
        }
    }
}