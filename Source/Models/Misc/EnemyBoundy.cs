using Godot;

namespace Shooter.Source.Models.Misc
{
    public class EnemyBoundy
    {
        public int HpUpPoints;
        public int BulletPoints;
        public Vector2 Position;

        public EnemyBoundy()
        {
        }

        public EnemyBoundy(int hpUpPoints, int bulletPoints, Vector2 position)
        {
            HpUpPoints = hpUpPoints;
            BulletPoints = bulletPoints;
            Position = position;
        }
    }
}