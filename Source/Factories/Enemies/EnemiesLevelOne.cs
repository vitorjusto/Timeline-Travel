using System.Collections.Generic;
using Shooter.Source.Models.Levels;
using Shooter.Source.Dumies.Enemies;
using Shooter.Source.Enums;

namespace Shooter.Source.Factories.Levels
{
    public static class EnemiesLevelOne
    {
        public static List<EnemySection> GetEnemies()
        {
            return new List<EnemySection>()
            {
                new(10, false, new DCommon(100, 4)),
                new(10, false, new DCommon(200, 4)),
                new(10, false, new DCommon(300, 4)),
                new(10, false, new DCommon(400, 4)),
                new(10, false, new DCommon(500, 4)),
                new(10, false, new DCommon(600, 4)),
                new(10, false, new DCommon(700, 4)),
                new(10, false, new DCommon(800, 4)),
                new(10, false, new DCommon(900, 4)),
                new(10, false, new DCommon(1000, 4)),
                new(10, false, new DCommon(1100, 4)),
                new(10, false, new DCommon(1200, 4)),
                new(50, false, new DCommon(1300, 4)),

                new(10, false, new DCommon(1300, 4)),
                new(10, false, new DCommon(1200, 4)),
                new(10, false, new DCommon(1100, 4)),
                new(10, false, new DCommon(1000, 4)),
                new(10, false, new DCommon(900, 4)),
                new(10, false, new DCommon(800, 4)),
                new(10, false, new DCommon(700, 4)),
                new(10, false, new DCommon(600, 4)),
                new(10, false, new DCommon(500, 4)),
                new(10, false, new DCommon(400, 4)),
                new(10, false, new DCommon(300, 4)),
                new(10, false, new DCommon(200, 4)),
                new(10, true,  new DCommon(100, 4)),

                new(20, false, new DSniper(300, EEnemyProjectileType.Normal)),
                new(20, false, new DSniper(1100, EEnemyProjectileType.Normal)),
                new(20, false, new DSniper(500, EEnemyProjectileType.Normal)),
                new(20, true, new DSniper(900, EEnemyProjectileType.Normal)),

                new(20, false, new DCommon(1300, 8),
                               new DCommon(1200, 9),
                               new DCommon(1100, 10),
                               new DCommon(1000, 11),
                               new DCommon(900, 12),
                               new DCommon(800, 13),
                               new DCommon(700, 14),
                               new DCommon(600, 13),
                               new DCommon(500, 12),
                               new DCommon(400, 11),
                               new DCommon(300, 10),
                               new DCommon(200, 9),
                               new DCommon(100, 8)),
                            
                new(20, true, new DSniper(1300, EEnemyProjectileType.Normal),
                               new DSniper(1200, EEnemyProjectileType.Normal),
                               new DSniper(1100, EEnemyProjectileType.Normal),
                               new DSniper(1000, EEnemyProjectileType.Normal),
                               new DSniper(900, EEnemyProjectileType.Normal),
                               new DSniper(800, EEnemyProjectileType.Normal),
                               new DSniper(700, EEnemyProjectileType.Normal),
                               new DSniper(600, EEnemyProjectileType.Normal),
                               new DSniper(500, EEnemyProjectileType.Normal),
                               new DSniper(400, EEnemyProjectileType.Normal),
                               new DSniper(300, EEnemyProjectileType.Normal),
                               new DSniper(200, EEnemyProjectileType.Normal),
                               new DSniper(100, EEnemyProjectileType.Normal)),
                
                new(30, false, new DSpread(700, EEnemyProjectileType.Normal)),
                new(30, true, new DSpread(500, EEnemyProjectileType.Normal), new DSpread(900, EEnemyProjectileType.Normal)),

                new(10, false, new DFollower(200, EEnemyProjectileType.Normal), new DFollower(1300, EEnemyProjectileType.Normal), new DFollower(1200, EEnemyProjectileType.Normal)),
                new(70, false, new DSpread(100, EEnemyProjectileType.Normal)),

                new(40, false, new DCommon(1300, 3),
                               new DCommon(1200, 3),
                               new DCommon(1100, 3),
                               new DCommon(1000, 3),
                               new DCommon(900, 3),
                               new DCommon(800, 3),
                               new DCommon(700, 3),
                               new DCommon(600, 3),
                               new DCommon(500, 3),
                               new DCommon(400, 3),
                               new DCommon(300, 3),
                               new DCommon(200, 3),
                               new DCommon(100, 3)),

                new(40, false, new DCommon(1300, 3),
                               new DCommon(1200, 3),
                               new DCommon(1100, 3),
                               new DCommon(1000, 3),
                               new DCommon(900, 3),
                               new DCommon(800, 3),
                               new DCommon(700, 3),
                               new DCommon(600, 3),
                               new DCommon(500, 3),
                               new DCommon(400, 3),
                               new DCommon(300, 3),
                               new DCommon(200, 3),
                               new DCommon(100, 3)),

                new(40, false, new DCommon(1300, 3),
                               new DCommon(1200, 3),
                               new DCommon(1100, 3),
                               new DCommon(1000, 3),
                               new DCommon(900, 3),
                               new DCommon(800, 3),
                               new DCommon(700, 3),
                               new DCommon(600, 3),
                               new DCommon(500, 3),
                               new DCommon(400, 3),
                               new DCommon(300, 3),
                               new DCommon(200, 3),
                               new DCommon(100, 3)),

                 new(40, false, new DCommon(1300, 3),
                               new DCommon(1200, 3),
                               new DCommon(1100, 3),
                               new DCommon(1000, 3),
                               new DCommon(900, 3),
                               new DCommon(800, 3),
                               new DCommon(700, 3),
                               new DCommon(600, 3),
                               new DCommon(500, 3),
                               new DCommon(400, 3),
                               new DCommon(300, 3),
                               new DCommon(200, 3),
                               new DCommon(100, 3)),

                new(40, false, new DCommon(1300, 3),
                               new DCommon(1200, 3),
                               new DCommon(1100, 3),
                               new DCommon(1000, 3),
                               new DCommon(900, 3),
                               new DCommon(800, 3),
                               new DCommon(700, 3),
                               new DCommon(600, 3),
                               new DCommon(500, 3),
                               new DCommon(400, 3),
                               new DCommon(300, 3),
                               new DCommon(200, 3),
                               new DCommon(100, 3)),
                new(5, false, new DShoter(500, EEnemyProjectileType.Normal)),

                new(40, false, new DCommon(1300, 3),
                               new DCommon(1200, 3),
                               new DCommon(1100, 3),
                               new DCommon(1000, 3),
                               new DCommon(900, 3),
                               new DCommon(800, 3),
                               new DCommon(700, 3),
                               new DCommon(600, 3),
                               new DCommon(500, 3),
                               new DCommon(400, 3),
                               new DCommon(300, 3),
                               new DCommon(200, 3),
                               new DCommon(100, 3)),

                new(5, false, new DShoter(900, EEnemyProjectileType.Normal)),

                new(40, false, new DCommon(1300, 3),
                               new DCommon(1200, 3),
                               new DCommon(1100, 3),
                               new DCommon(1000, 3),
                               new DCommon(900, 3),
                               new DCommon(800, 3),
                               new DCommon(700, 3),
                               new DCommon(600, 3),
                               new DCommon(500, 3),
                               new DCommon(400, 3),
                               new DCommon(300, 3),
                               new DCommon(200, 3),
                               new DCommon(100, 3)),

                new(40, true, new DCommon(1300, 3),
                               new DCommon(1200, 3),
                               new DCommon(1100, 3),
                               new DCommon(1000, 3),
                               new DCommon(900, 3),
                               new DCommon(800, 3),
                               new DCommon(700, 3),
                               new DCommon(600, 3),
                               new DCommon(500, 3),
                               new DCommon(400, 3),
                               new DCommon(300, 3),
                               new DCommon(200, 3),
                               new DCommon(100, 3)),

                new(30, false, new DCommon(700, 4)
                            , new DCommon(600, 4)
                            , new DCommon(800, 4)),
                
                new(30, false, new DCommon(600, 4)
                            , new DSpread(700, EEnemyProjectileType.Normal, 4)
                            , new DCommon(800, 4)),
                
                new(30, false, new DCommon(600, 4)
                            , new DSpread(700, EEnemyProjectileType.Normal, 4)
                            , new DCommon(800, 4)),
                
                new(30, false, new DCommon(600, 4)
                            , new DSpread(700, EEnemyProjectileType.Normal, 4)
                            , new DCommon(800, 4)),

                new(30, false, new DCommon(600, 4)
                            , new DSpread(700, EEnemyProjectileType.Normal, 4)
                            , new DCommon(800, 4)),
                
                new(30, false, new DCommon(600, 4)
                            , new DSpread(700, EEnemyProjectileType.Normal, 4)
                            , new DCommon(800, 4)),
                
                new(30, false, new DCommon(600, 4)
                            , new DSpread(700, EEnemyProjectileType.Normal, 4)
                            , new DCommon(800, 4)),

                new(30, false, new DCommon(1300, 4),
                               new DCommon(1200, 4),
                               new DCommon(1100, 4),
                               new DCommon(1000, 4),
                               new DCommon(900, 4),
                               new DCommon(800, 4),
                               new DCommon(700, 4),
                               new DCommon(600, 4),
                               new DCommon(500, 4),
                               new DCommon(400, 4),
                               new DCommon(300, 4),
                               new DCommon(200, 4),
                               new DCommon(100, 4)),
                
                new(30, false, new DCommon(1300, 4),
                               new DSpread(1200, EEnemyProjectileType.Normal, 4),
                               new DSpread(1100, EEnemyProjectileType.Normal, 4),
                               new DSpread(1000, EEnemyProjectileType.Normal, 4),
                               new DSpread(900, EEnemyProjectileType.Normal, 4),
                               new DSpread(800, EEnemyProjectileType.Normal, 4),
                               new DSpread(700, EEnemyProjectileType.Normal, 4),
                               new DSpread(600, EEnemyProjectileType.Normal, 4),
                               new DSpread(500, EEnemyProjectileType.Normal, 4),
                               new DSpread(400, EEnemyProjectileType.Normal, 4),
                               new DSpread(300, EEnemyProjectileType.Normal, 4),
                               new DSpread(200, EEnemyProjectileType.Normal, 4),
                               new DCommon(100, 4)),
                
                new(30, false, new DCommon(1300, 4),
                               new DCommon(1200, 4),
                               new DCommon(1100, 4),
                               new DCommon(1000, 4),
                               new DCommon(900, 4),
                               new DCommon(800, 4),
                               new DCommon(700, 4),
                               new DCommon(600, 4),
                               new DCommon(500, 4),
                               new DCommon(400, 4),
                               new DCommon(300, 4),
                               new DCommon(200, 4),
                               new DCommon(100, 4)),

                new(5, false, new DShoter(100, EEnemyProjectileType.Normal)),
                new(5, false, new DShoter(1300, EEnemyProjectileType.Normal)),

                new(10, false, new DCurver(200)
                             , new DCurver(400)
                             , new DCurver(600)
                             , new DCurver(800)
                             , new DCurver(1200)),
            };

        }
    }
}