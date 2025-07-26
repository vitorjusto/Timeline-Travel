using System.Collections.Generic;
using Shooter.Source.Dumies.Enemies;
using Shooter.Source.Models.Levels;

namespace Shooter.Source.Factories.Enemies
{
    public static class BetaTestEnemy
    {
        public static List<EnemySection> GetEnemies()
        {
            return new List<EnemySection>()
            {
                new EnemySection(50, true, new DCrusader(500, 2)),
                new EnemySection(50, true, new DCrusader(500, 3)),
                new EnemySection(50, true, new DCrusader(500, 4)),
                new EnemySection(50, true, new DCrusader(500, 3)),
                new EnemySection(50, true, new DCrusader(500, 3)),
                new EnemySection(50, true, new DCrusader(500, 3)),
                new EnemySection(50, true, new DCrusader(500, 3)),
                new EnemySection(50, true, new DCrusader(500, 3)),
            };
        }
    }
}