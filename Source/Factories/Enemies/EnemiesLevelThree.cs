using System.Collections.Generic;
using Shooter.Source.Dumies.Enemies;
using Shooter.Source.Models.Levels;
using Sooter.Source.Dumies.Enemies;

namespace Shooter.Source.Factories.Enemies
{
    public class EnemiesLevelThree
    {
        public static List<EnemySection> GetEnemies()
        {
            return new List<EnemySection>()
            {
                new EnemySection(50, false, new DSniper(100, Enums.EEnemyProjectileType.Normal)),
                new EnemySection(50, false, new DSurpriser()),
                new EnemySection(50, false, new DSurpriser()),
                new EnemySection(50, false, new DSurpriser()),
                new EnemySection(50, false, new DSurpriser()),
                new EnemySection(50, false, new DSurpriser()),
                new EnemySection(50, false, new DSurpriser()),
                new EnemySection(50, false, new DSurpriser()),
                new EnemySection(50, false, new DSurpriser()),
                new EnemySection(50, false, new DSurpriser()),
            };

        }
    }
}