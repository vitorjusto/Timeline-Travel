using System.Collections.Generic;
using Shooter.Source.Dumies.Enemies;
using Shooter.Source.Enums;
using Shooter.Source.Models.Levels;

namespace Shooter.Source.Factories.Enemies
{
    public class EnemiesLevelFour
    {
        public static List<EnemySection> GetEnemies()
        {
            return new List<EnemySection>()
            {
                new(30, false, new DLazer(100, 200)),
                new(30, false, new DLazer(200, 200)),
                new(30, false, new DLazer(300, 200)),
                new(30, false, new DLazer(400, 200)),
                new(30, false, new DLazer(500, 200)),

                new(30, false, new DLazer(1300, 200)),
                new(30, false, new DLazer(1200, 200)),
                new(30, false, new DLazer(1100, 200)),
                new(30, false, new DLazer(1000, 200)),
                new(30, true, new DLazer(900, 200)),

                new(20, false, new DCommon(100, 3)
                             , new DCommon(200, 3)
                             , new DCommon(300, 3)
                             , new DCommon(400, 3)
                             , new DCommon(500, 3)
                             , new DCommon(600, 3)
                             , new DCommon(700, 3)
                             , new DCommon(800, 3)
                             , new DCommon(900, 3)
                             , new DCommon(1000, 3)
                             , new DCommon(1100, 3)
                             , new DCommon(1200, 3)
                             , new DCommon(1300, 3)),

                new(50, false, new DLazer(100, 200)),

                new(20, false, new DCommon(100, 3)
                             , new DCommon(200, 3)
                             , new DCommon(300, 3)
                             , new DCommon(400, 3)
                             , new DCommon(500, 3)
                             , new DCommon(600, 3)
                             , new DCommon(700, 3)
                             , new DCommon(800, 3)
                             , new DCommon(900, 3)
                             , new DCommon(1000, 3)
                             , new DCommon(1100, 3)
                             , new DCommon(1200, 3)
                             , new DCommon(1300, 3)),

                new(50, false, new DLazer(700, 200)),
                
                new(20, false, new DCommon(100, 3)
                             , new DCommon(200, 3)
                             , new DCommon(300, 3)
                             , new DCommon(400, 3)
                             , new DCommon(500, 3)
                             , new DCommon(600, 3)
                             , new DCommon(700, 3)
                             , new DCommon(800, 3)
                             , new DCommon(900, 3)
                             , new DCommon(1000, 3)
                             , new DCommon(1100, 3)
                             , new DCommon(1200, 3)
                             , new DCommon(1300, 3)),

                new(50, true, new DLazer(1300, 200)),

                new(60, false, new DSpread(100, EEnemyProjectileType.Normal, 2), new DSpread(1300, EEnemyProjectileType.Normal, 2)),

                new(60, false, new DSpread(200, EEnemyProjectileType.Normal, 2), new DSpread(1200, EEnemyProjectileType.Normal, 2), new DCommon(100, 2), 
                                                                                                                                    new DCommon(1300, 2)),
            
                new(60, false, new DSpread(300, EEnemyProjectileType.Normal, 2), new DSpread(1100, EEnemyProjectileType.Normal, 2), new DCommon(100, 2),
                                                                                                                                    new DCommon(200, 2), 
                                                                                                                                    new DCommon(1200, 2), 
                                                                                                                                    new DCommon(1300, 2)),
                
                new(60, false, new DSpread(400, EEnemyProjectileType.Normal, 2), new DSpread(1000, EEnemyProjectileType.Normal, 2), new DCommon(100, 2),
                                                                                                                                    new DCommon(200, 2), 
                                                                                                                                    new DCommon(300, 2), 
                                                                                                                                    new DCommon(1100, 2), 
                                                                                                                                    new DCommon(1200, 2), 
                                                                                                                                    new DCommon(1300, 2)),
            
                new(60, false, new DSpread(500, EEnemyProjectileType.Normal, 2), new DSpread(900, EEnemyProjectileType.Normal, 2), new DCommon(100, 2),
                                                                                                                                    new DCommon(200, 2), 
                                                                                                                                    new DCommon(300, 2), 
                                                                                                                                    new DCommon(400, 2), 
                                                                                                                                    new DCommon(1000, 2), 
                                                                                                                                    new DCommon(1100, 2), 
                                                                                                                                    new DCommon(1200, 2), 
                                                                                                                                    new DCommon(1300, 2)),
            
                new(60, false, new DSpread(600, EEnemyProjectileType.Normal, 2), new DSpread(800, EEnemyProjectileType.Normal, 2), new DCommon(100, 2),
                                                                                                                                    new DCommon(200, 2), 
                                                                                                                                    new DCommon(300, 2), 
                                                                                                                                    new DCommon(400, 2), 
                                                                                                                                    new DCommon(500, 2), 
                                                                                                                                    new DCommon(900, 2), 
                                                                                                                                    new DCommon(1000, 2), 
                                                                                                                                    new DCommon(1100, 2), 
                                                                                                                                    new DCommon(1200, 2), 
                                                                                                                                    new DCommon(1300, 2)),

                new(60, false, new DSpread(700, EEnemyProjectileType.Normal, 2),new DCommon(100, 2),
                                                                                new DCommon(200, 2), 
                                                                                new DCommon(300, 2), 
                                                                                new DCommon(400, 2), 
                                                                                new DCommon(500, 2), 
                                                                                new DCommon(600, 2), 
                                                                                new DCommon(800, 2), 
                                                                                new DCommon(900, 2), 
                                                                                new DCommon(1000, 2), 
                                                                                new DCommon(1100, 2), 
                                                                                new DCommon(1200, 2), 
                                                                                new DCommon(1300, 2)),

                new(60, false, new DCommon(100, 2)
                             , new DCommon(200, 2)
                             , new DCommon(300, 2)
                             , new DCommon(400, 2)
                             , new DCommon(500, 2)
                             , new DCommon(600, 2)
                             , new DCommon(700, 2)
                             , new DCommon(800, 2)
                             , new DCommon(900, 2)
                             , new DCommon(1000, 2)
                             , new DCommon(1100, 2)
                             , new DCommon(1200, 2)
                             , new DCommon(1300, 2)),

                new(60, true, new DCommon(100, 2)
                             , new DCommon(200, 2)
                             , new DCommon(300, 2)
                             , new DCommon(400, 2)
                             , new DCommon(500, 2)
                             , new DCommon(600, 2)
                             , new DCommon(700, 2)
                             , new DCommon(800, 2)
                             , new DCommon(900, 2)
                             , new DCommon(1000, 2)
                             , new DCommon(1100, 2)
                             , new DCommon(1200, 2)
                             , new DCommon(1300, 2)),

                
                new(30, false, new DLazer(700, 500), new DLazer(600, 500), new DLazer(800, 500)),

                new(100, false, new DDasher(100), new DDasher(1300)),

                new(50, false, new DDasher(100), new DDasher(1300)),
                new(50, false, new DDasher(200), new DDasher(1200)),
                new(50, false, new DDasher(300), new DDasher(1100)),
            };

        }
        
    }
}