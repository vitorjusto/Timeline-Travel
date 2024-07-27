using System.Collections.Generic;
using Shooter.Source.Dumies.Enemies;
using Shooter.Source.Enums;
using Shooter.Source.Models.Levels;

namespace Shooter.Source.Factories.Enemies
{
    public class EnemiesLevelSeven
    {
        public static List<EnemySection> GetEnemies()
        {
            return new List<EnemySection>()
            {
                new(30, false, new DSniper(100, EEnemyProjectileType.Normal)
                             , new DSniper(200, EEnemyProjectileType.Normal)
                             , new DSniper(300, EEnemyProjectileType.Normal)
                             , new DSniper(400, EEnemyProjectileType.Normal)
                             , new DSniper(500, EEnemyProjectileType.Normal)
                             , new DSniper(600, EEnemyProjectileType.Normal)
                             , new DSniper(700, EEnemyProjectileType.Normal)
                             , new DSniper(800, EEnemyProjectileType.Normal)
                             , new DSniper(900, EEnemyProjectileType.Normal)
                             , new DSniper(1000, EEnemyProjectileType.Normal)
                             , new DSniper(1100, EEnemyProjectileType.Normal)
                             , new DSniper(1200, EEnemyProjectileType.Normal)
                             , new DSniper(1300, EEnemyProjectileType.Normal)),

                new(30, false, new DSniper(100, EEnemyProjectileType.Normal)
                             , new DSniper(200, EEnemyProjectileType.Normal)
                             , new DSniper(300, EEnemyProjectileType.Normal)
                             , new DSniper(400, EEnemyProjectileType.Normal)
                             , new DSniper(500, EEnemyProjectileType.Normal)
                             , new DSniper(600, EEnemyProjectileType.Normal)
                             , new DSniper(700, EEnemyProjectileType.Normal)
                             , new DSniper(800, EEnemyProjectileType.Normal)
                             , new DSniper(900, EEnemyProjectileType.Normal)
                             , new DSniper(1000, EEnemyProjectileType.Normal)
                             , new DSniper(1100, EEnemyProjectileType.Normal)
                             , new DSniper(1200, EEnemyProjectileType.Normal)
                             , new DSniper(1300, EEnemyProjectileType.Normal)),


                new(30, false, new DSniper(100, EEnemyProjectileType.Normal)
                             , new DSniper(200, EEnemyProjectileType.Normal)
                             , new DSniper(300, EEnemyProjectileType.Normal)
                             , new DSniper(400, EEnemyProjectileType.Normal)
                             , new DSniper(500, EEnemyProjectileType.Normal)
                             , new DSniper(600, EEnemyProjectileType.Normal)
                             , new DSniper(700, EEnemyProjectileType.Normal)
                             , new DSniper(800, EEnemyProjectileType.Normal)
                             , new DSniper(900, EEnemyProjectileType.Normal)
                             , new DSniper(1000, EEnemyProjectileType.Normal)
                             , new DSniper(1100, EEnemyProjectileType.Normal)
                             , new DSniper(1200, EEnemyProjectileType.Normal)
                             , new DSniper(1300, EEnemyProjectileType.Normal)),


                new(30, false, new DSniper(100, EEnemyProjectileType.Normal)
                             , new DSniper(200, EEnemyProjectileType.Normal)
                             , new DSniper(300, EEnemyProjectileType.Normal)
                             , new DSniper(400, EEnemyProjectileType.Normal)
                             , new DSniper(500, EEnemyProjectileType.Normal)
                             , new DSniper(600, EEnemyProjectileType.Normal)
                             , new DSniper(700, EEnemyProjectileType.Normal)
                             , new DSniper(800, EEnemyProjectileType.Normal)
                             , new DSniper(900, EEnemyProjectileType.Normal)
                             , new DSniper(1000, EEnemyProjectileType.Normal)
                             , new DSniper(1100, EEnemyProjectileType.Normal)
                             , new DSniper(1200, EEnemyProjectileType.Normal)
                             , new DSniper(1300, EEnemyProjectileType.Normal)),

                new(30, false, new DSniper(100, EEnemyProjectileType.Normal)
                             , new DSniper(200, EEnemyProjectileType.Normal)
                             , new DSniper(300, EEnemyProjectileType.Normal)
                             , new DSniper(400, EEnemyProjectileType.Normal)
                             , new DSniper(500, EEnemyProjectileType.Normal)
                             , new DSniper(600, EEnemyProjectileType.Normal)
                             , new DSniper(700, EEnemyProjectileType.Normal)
                             , new DSniper(800, EEnemyProjectileType.Normal)
                             , new DSniper(900, EEnemyProjectileType.Normal)
                             , new DSniper(1000, EEnemyProjectileType.Normal)
                             , new DSniper(1100, EEnemyProjectileType.Normal)
                             , new DSniper(1200, EEnemyProjectileType.Normal)
                             , new DSniper(1300, EEnemyProjectileType.Normal)),

                new(100, false, new DSniper(100, EEnemyProjectileType.Normal)
                             , new DSniper(200, EEnemyProjectileType.Normal)
                             , new DSniper(300, EEnemyProjectileType.Normal)
                             , new DSniper(400, EEnemyProjectileType.Normal)
                             , new DSniper(500, EEnemyProjectileType.Normal)
                             , new DSniper(600, EEnemyProjectileType.Normal)
                             , new DSniper(700, EEnemyProjectileType.Normal)
                             , new DSniper(800, EEnemyProjectileType.Normal)
                             , new DSniper(900, EEnemyProjectileType.Normal)
                             , new DSniper(1000, EEnemyProjectileType.Normal)
                             , new DSniper(1100, EEnemyProjectileType.Normal)
                             , new DSniper(1200, EEnemyProjectileType.Normal)
                             , new DSniper(1300, EEnemyProjectileType.Normal)),

                new(30, false, new DBomber(100)),
                new(30, false, new DBomber(200)),
                new(30, false, new DBomber(300)),
                new(30, false, new DBomber(400)),
                new(30, false, new DBomber(500)),
                new(30, false, new DBomber(600)),
                new(30, false, new DBomber(700)),
                new(30, false, new DBomber(800)),
                new(30, false, new DBomber(900)),
                new(30, false, new DBomber(1000)),
                new(30, false, new DBomber(1100)),
                new(30, false, new DBomber(1200)),
                new(30, false, new DBomber(1300)),

            };

        }        
    }
}