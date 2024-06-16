
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Interfaces
{
    public interface IEnemy
    {
        public void Destroy();
        public bool IsImortal();
        public EnemyBoundy GetBoundy();
    }
}