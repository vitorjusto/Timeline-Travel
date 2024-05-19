using System.Collections.Generic;
using Shooter.Source.Dumies.Enemies;
using Shooter.Source.Models.Levels;

namespace Shooter.Source.Factories.Enemies
{
    public class EnemiesLevelEight
    {
        public static List<EnemySection> GetEnemies()
        {
            return new List<EnemySection>()
            {
                new EnemySection(10, false, new DOrbiter()),
                new EnemySection(50, true, new DOrbiter()),
                new EnemySection(50, true, new DOrbiter()),
                new EnemySection(50, true, new DOrbiter()),
                new EnemySection(50, true, new DOrbiter()),
                new EnemySection(50, true, new DOrbiter()),
                new EnemySection(50, true, new DOrbiter()),
                new EnemySection(50, true, new DOrbiter()),
                new EnemySection(50, true, new DOrbiter()),
                new EnemySection(50, true, new DOrbiter()),
                new EnemySection(50, true, new DOrbiter()),
                new EnemySection(50, true, new DOrbiter()),
            };

        }
    }
}