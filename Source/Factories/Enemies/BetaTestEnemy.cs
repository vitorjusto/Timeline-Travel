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
                new EnemySection(50, true, new DCurver(500)),
                new EnemySection(50, true, new DCurver(500)),
                new EnemySection(50, true, new DCurver(500)),
                new EnemySection(50, true, new DCurver(500)),
                new EnemySection(50, true, new DCurver(500)),
                new EnemySection(50, true, new DCurver(500)),
                new EnemySection(50, true, new DCurver(500)),
                new EnemySection(50, true, new DCurver(500)),
            };
        }
    }
}