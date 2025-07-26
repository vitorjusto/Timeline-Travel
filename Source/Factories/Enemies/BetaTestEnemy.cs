using System.Collections.Generic;
using Shooter.Source.Dumies.Enemies;
using Shooter.Source.Enums;
using Shooter.Source.Models.Levels;

namespace Shooter.Source.Factories.Enemies
{
    public static class BetaTestEnemy
    {
        public static List<EnemySection> GetEnemies()
        {
            return new List<EnemySection>()
            {
                new EnemySection(50, false, new DSpreader(400, EEnemyProjectileType.Normal, speed: 2)),
                new EnemySection(50, false, new DSpreader(500, EEnemyProjectileType.Normal, speed: 2)),
                new EnemySection(50, false, new DSpreader(600, EEnemyProjectileType.Normal, speed: 2)),
                new EnemySection(50, false, new DSpreader(700, EEnemyProjectileType.Normal, speed: 2)),

                new EnemySection(50, false, new DSpread(400, EEnemyProjectileType.Normal)),
                new EnemySection(50, false, new DSpread(500, EEnemyProjectileType.Normal)),
                new EnemySection(50, false, new DSpread(600, EEnemyProjectileType.Normal)),
                new EnemySection(50, false, new DSpread(700, EEnemyProjectileType.Normal)),
            };
        }
    }
}