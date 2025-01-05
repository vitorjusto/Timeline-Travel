namespace Shooter.Source.Interfaces
{
    public interface IEnemyProjectile
    {
        int GetDamage();
        void SetPosition(float X, float Y);
        void SetSpeed(float XSpeed, float YSpeeed);
    }
}