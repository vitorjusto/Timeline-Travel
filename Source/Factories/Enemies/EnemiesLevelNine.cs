using System.Collections.Generic;
using Shooter.Source.Dumies.Enemies;
using Shooter.Source.Models.Levels;

namespace Shooter.Source.Factories.Enemies
{
    public class EnemiesLevelNine
    {
        public static List<EnemySection> GetEnemies()
        {
            return new List<EnemySection>()
            {
                new EnemySection(50, true, new DCommon(100, 1)),
                new EnemySection(50, true, new DCommon(100, 1)),
                new EnemySection(50, false, new DCommon(100, 1)),
            };

        }
    }
}