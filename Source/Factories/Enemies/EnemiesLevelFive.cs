using System.Collections.Generic;
using Shooter.Source.Dumies.Enemies;
using Shooter.Source.Enums;
using Shooter.Source.Models.Levels;

namespace Shooter.Source.Factories.Enemies
{
    public class EnemiesLevelFive
    {
        public static List<EnemySection> GetEnemies()
        {
            return new List<EnemySection>()
            {
                new(20, false, new DCommon(600, 5), new DCommon(700, 5), new DCommon(800, 5)),
                new(20, false, new DCommon(600, 5), new DSpreader(700, EEnemyProjectileType.Strong, 5), new DCommon(800, 5)),
                new(70, false, new DCommon(600, 5), new DCommon(700, 5), new DCommon(800, 5)),

                new(20, false, new DCommon(900, 5), new DCommon(1000, 5), new DCommon(1100, 5)),
                new(20, false, new DCommon(900, 5), new DSpreader(1000, EEnemyProjectileType.Light, 5), new DCommon(1100, 5)),
                new(70, false, new DCommon(900, 5), new DCommon(1000, 5), new DCommon(1100, 5)),

                new(20, false, new DCommon(300, 5), new DCommon(400, 5), new DCommon(500, 5)),
                new(20, false, new DCommon(300, 5), new DSpreader(400, EEnemyProjectileType.Normal, 5), new DCommon(500, 5)),
                new(70, true, new DCommon(300, 5), new DCommon(400, 5), new DCommon(500, 5)),

                new(50, false, new DOrbiter()),
                new(50, false, new DOrbiter()),
                new(50, false, new DOrbiter()),
                new(50, true, new DOrbiter()),

                new(100, false, new DLazer(200, 2300), new DLazer(1200, 2300)),
                new(200, false,  new DSpreader(100, EEnemyProjectileType.Normal, 3),  new DSpreader(1300, EEnemyProjectileType.Normal, 3)),
                new(200, false,  new DSpreader(100, EEnemyProjectileType.Normal, 3),  new DSpreader(1300, EEnemyProjectileType.Normal, 3)),
                new(400, false,  new DSpreader(100, EEnemyProjectileType.Normal, 3),  new DSpreader(1300, EEnemyProjectileType.Normal, 3)),
                new(20, false, new DOrbiter()),
                new(20, false, new DOrbiter()),
                new(20, false, new DOrbiter()),
                new(20, false, new DOrbiter()),
                new(20, false, new DOrbiter()),
                new(20, false, new DOrbiter()),
                new(20, false, new DOrbiter()),
                new(20, false, new DOrbiter()),
                new(50, false,  new DSpreader(100, EEnemyProjectileType.Normal, 3),  new DSpreader(1300, EEnemyProjectileType.Normal, 3)),
                new(50, false, new DCommon(600, 3), new DCommon(700, 3), new DCommon(800, 3)),
                new(50, false, new DCommon(600, 3), new DSpread(700, EEnemyProjectileType.Normal, 3), new DCommon(800, 3)),
                new(200, false, new DCommon(600, 3), new DCommon(700, 3), new DCommon(800, 3)),

                new(100, false,  new DSpreader(100, EEnemyProjectileType.Strong, 3),  new DSpreader(1300, EEnemyProjectileType.Strong, 3)),
                new(50, false, new DCommon(300, 3), new DCommon(400, 3), new DCommon(500, 3), new DCommon(600, 3), new DCommon(700, 3), new DCommon(800, 3), new DCommon(900, 3), new DCommon(1000, 3), new DCommon(1100, 3)),
                new(50, false, new DCommon(300, 3), new DCommon(400, 3), new DCommon(500, 3), new DCommon(600, 3), new DCommon(700, 3), new DCommon(800, 3), new DCommon(900, 3), new DCommon(1000, 3), new DCommon(1100, 3)),
                new(50, false, new DCommon(300, 3), new DCommon(400, 3), new DCommon(500, 3), new DCommon(600, 3), new DCommon(700, 3), new DCommon(800, 3), new DCommon(900, 3), new DCommon(1000, 3), new DCommon(1100, 3)),
                new(50, false, new DCommon(300, 3), new DCommon(400, 3), new DCommon(500, 3), new DCommon(600, 3), new DCommon(700, 3), new DCommon(800, 3), new DCommon(900, 3), new DCommon(1000, 3), new DCommon(1100, 3)),
                new(200, false,  new DSpreader(100, EEnemyProjectileType.Strong, 3),  new DSpreader(1300, EEnemyProjectileType.Strong, 3)),
                
                new(50, false, new DCommon(300, 3), new DCommon(400, 3), new DCommon(500, 3), new DCommon(600, 3), new DCommon(700, 3), new DCommon(800, 3), new DCommon(900, 3), new DCommon(1000, 3), new DCommon(1100, 3)),
                new(50, false, new DCommon(300, 3), new DSpread(400, EEnemyProjectileType.Normal, 3), new DSpread(500, EEnemyProjectileType.Normal, 3), new DSpread(600, EEnemyProjectileType.Normal, 3), new DSpread(700, EEnemyProjectileType.Normal, 3), new DSpread(800, EEnemyProjectileType.Normal, 3), new DSpread(900, EEnemyProjectileType.Normal, 3), new DSpread(1000, EEnemyProjectileType.Normal, 3), new DCommon(1100, 3)),
                new(50, true, new DCommon(300, 3), new DCommon(400, 3), new DCommon(500, 3), new DCommon(600, 3), new DCommon(700, 3), new DCommon(800, 3), new DCommon(900, 3), new DCommon(1000, 3), new DCommon(1100, 3)),
            
                new(30, false, new DCommon(600, 4)
                            , new DCommon(700, 4)
                            , new DCommon(800, 4)),

                new(30, false, new DCommon(600, 4)
                            , new DSpreader(700, EEnemyProjectileType.Light, 4)
                            , new DCommon(800, 4)),
                
                new(30, false, new DCommon(600, 4)
                            , new DSpreader(700, EEnemyProjectileType.Light, 4)
                            , new DCommon(800, 4)),
                
                new(30, false, new DCommon(600, 4)
                            , new DSpreader(700, EEnemyProjectileType.Light, 4)
                            , new DCommon(800, 4)),

                new(30, false, new DCommon(600, 4)
                            , new DSpreader(700, EEnemyProjectileType.Light, 4)
                            , new DCommon(800, 4)),
                
                new(30, false, new DCommon(600, 4)
                            , new DSpreader(700, EEnemyProjectileType.Light, 4)
                            , new DCommon(800, 4)),
                
                new(30, false, new DCommon(600, 4)
                            , new DSpreader(700, EEnemyProjectileType.Light, 4)
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
                               new DSpreader(1200, EEnemyProjectileType.Strong, 4),
                               new DCommon(1100, 4),
                               new DSpreader(1000, EEnemyProjectileType.Strong, 4),
                               new DCommon(900, 4),
                               new DCommon(800, 4),
                               new DCommon(700, 4),
                               new DCommon(600, 4),
                               new DCommon(500, 4),
                               new DSpreader(400, EEnemyProjectileType.Strong, 4),
                               new DCommon(300, 4),
                               new DSpreader(200, EEnemyProjectileType.Strong, 4),
                               new DCommon(100, 4)),
                
                new(30, true, new DCommon(1300, 4),
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

                new(5, false, new DOrbiter()),
                new(5, false, new DOrbiter()),
                new(5, false, new DOrbiter()),
                new(5, false, new DOrbiter()),
                new(5, false, new DOrbiter()),
                new(5, false, new DOrbiter()),
                new(5, false, new DOrbiter()),
                new(5, false, new DOrbiter()),
                new(5, false, new DOrbiter()),
                new(5, false, new DOrbiter()),
                new(5, false, new DOrbiter()),
                new(5, false, new DOrbiter()),
                new(5, false, new DOrbiter()),
                new(5, false, new DOrbiter()),
                new(5, false, new DOrbiter()),
                new(5, false, new DOrbiter()),
                new(5, false, new DOrbiter()),
                new(5, false, new DOrbiter()),
                new(5, false, new DOrbiter()),
                new(5, false, new DOrbiter()),
                new(5, false, new DOrbiter()),
                new(5, false, new DOrbiter()),
                new(5, false, new DOrbiter()),
                new(5, false, new DOrbiter()),
                new(5, false, new DOrbiter()),
                new(5, false, new DOrbiter()),
                new(5, false, new DOrbiter()),
                new(5, false, new DOrbiter()),
                new(5, false, new DOrbiter()),
                new(5, false, new DOrbiter()),
                new(5, false, new DOrbiter()),
                new(5, false, new DOrbiter()),
                new(5, false, new DOrbiter()),
                new(5, false, new DOrbiter()),
                new(5, false, new DOrbiter()),
                new(5, false, new DOrbiter()),

                new(20, false, new DSniper(100, EEnemyProjectileType.Strong),
                               new DSniper(200, EEnemyProjectileType.Strong),
                               new DSniper(300, EEnemyProjectileType.Strong),
                               new DSniper(400, EEnemyProjectileType.Strong),
                               new DSniper(500, EEnemyProjectileType.Strong),
                               new DSniper(600, EEnemyProjectileType.Strong),
                               new DSniper(700, EEnemyProjectileType.Strong),
                               new DSniper(800, EEnemyProjectileType.Strong),
                               new DSniper(900, EEnemyProjectileType.Strong),
                               new DSniper(1000, EEnemyProjectileType.Strong),
                               new DSniper(1100, EEnemyProjectileType.Strong),
                               new DSniper(1200, EEnemyProjectileType.Strong),
                               new DSniper(1300, EEnemyProjectileType.Strong)
                ),

                new(20, true, new DSniper(100, EEnemyProjectileType.Strong),
                               new DSniper(200, EEnemyProjectileType.Strong),
                               new DSniper(300, EEnemyProjectileType.Strong),
                               new DSniper(400, EEnemyProjectileType.Strong),
                               new DSniper(500, EEnemyProjectileType.Strong),
                               new DSniper(600, EEnemyProjectileType.Strong),
                               new DSniper(700, EEnemyProjectileType.Strong),
                               new DSniper(800, EEnemyProjectileType.Strong),
                               new DSniper(900, EEnemyProjectileType.Strong),
                               new DSniper(1000, EEnemyProjectileType.Strong),
                               new DSniper(1100, EEnemyProjectileType.Strong),
                               new DSniper(1200, EEnemyProjectileType.Strong),
                               new DSniper(1300, EEnemyProjectileType.Strong)
                ),

                new(20, false, new DSniper(100, EEnemyProjectileType.Normal),
                               new DSniper(200, EEnemyProjectileType.Normal),
                               new DSniper(300, EEnemyProjectileType.Normal),
                               new DSniper(400, EEnemyProjectileType.Normal),
                               new DSniper(500, EEnemyProjectileType.Normal),
                               new DSniper(600, EEnemyProjectileType.Normal),
                               new DSniper(700, EEnemyProjectileType.Normal),
                               new DSniper(800, EEnemyProjectileType.Normal),
                               new DSniper(900, EEnemyProjectileType.Normal),
                               new DSniper(1000, EEnemyProjectileType.Normal),
                               new DSniper(1100, EEnemyProjectileType.Normal),
                               new DSniper(1200, EEnemyProjectileType.Normal),
                               new DSniper(1300, EEnemyProjectileType.Normal)
                ),

                new(20, false, new DSniper(100, EEnemyProjectileType.Normal),
                               new DSniper(200, EEnemyProjectileType.Normal),
                               new DSniper(300, EEnemyProjectileType.Normal),
                               new DSniper(400, EEnemyProjectileType.Normal),
                               new DSniper(500, EEnemyProjectileType.Normal),
                               new DSniper(600, EEnemyProjectileType.Normal),
                               new DSniper(700, EEnemyProjectileType.Normal),
                               new DSniper(800, EEnemyProjectileType.Normal),
                               new DSniper(900, EEnemyProjectileType.Normal),
                               new DSniper(1000, EEnemyProjectileType.Normal),
                               new DSniper(1100, EEnemyProjectileType.Normal),
                               new DSniper(1200, EEnemyProjectileType.Normal),
                               new DSniper(1300, EEnemyProjectileType.Normal)
                ),

                new(20, false, new DSniper(100, EEnemyProjectileType.Light),
                               new DSniper(200, EEnemyProjectileType.Light),
                               new DSniper(300, EEnemyProjectileType.Light),
                               new DSniper(400, EEnemyProjectileType.Light),
                               new DSniper(500, EEnemyProjectileType.Light),
                               new DSniper(600, EEnemyProjectileType.Light),
                               new DSniper(700, EEnemyProjectileType.Light),
                               new DSniper(800, EEnemyProjectileType.Light),
                               new DSniper(900, EEnemyProjectileType.Light),
                               new DSniper(1000, EEnemyProjectileType.Light),
                               new DSniper(1100, EEnemyProjectileType.Light),
                               new DSniper(1200, EEnemyProjectileType.Light),
                               new DSniper(1300, EEnemyProjectileType.Light)
                ),

                new(20, false, new DSniper(100, EEnemyProjectileType.Light),
                               new DSniper(200, EEnemyProjectileType.Light),
                               new DSniper(300, EEnemyProjectileType.Light),
                               new DSniper(400, EEnemyProjectileType.Light),
                               new DSniper(500, EEnemyProjectileType.Light),
                               new DSniper(600, EEnemyProjectileType.Light),
                               new DSniper(700, EEnemyProjectileType.Light),
                               new DSniper(800, EEnemyProjectileType.Light),
                               new DSniper(900, EEnemyProjectileType.Light),
                               new DSniper(1000, EEnemyProjectileType.Light),
                               new DSniper(1100, EEnemyProjectileType.Light),
                               new DSniper(1200, EEnemyProjectileType.Light),
                               new DSniper(1300, EEnemyProjectileType.Light)
                ),

                new(15, false, new DLazer(100, 200)),
                new(15, false, new DLazer(200, 2000)),
                new(15, false, new DLazer(300, 2000)),
                new(15, false, new DLazer(400, 2000)),
                new(15, false, new DLazer(500, 2000)),
                new(15, false, new DLazer(600, 2000)),
                new(15, false, new DLazer(700, 2000)),
                new(15, false, new DLazer(800, 2000)),
                new(15, false, new DLazer(900, 2000)),
                new(15, false, new DLazer(1000, 2000)),
                new(15, false, new DLazer(1100, 2000)),
                new(100, false, new DLazer(1200, 2000)),

                new(40, false, new DSpreader(100, EEnemyProjectileType.Normal, 5)),
                new(40, false, new DSpreader(100, EEnemyProjectileType.Normal, 4)),
                new(40, false, new DSpreader(100, EEnemyProjectileType.Normal, 3)),
                new(40, false, new DSpreader(100, EEnemyProjectileType.Normal, 6)),
                new(40, false, new DSpreader(100, EEnemyProjectileType.Normal, 5)),

                new(40, false, new DSpreader(100, EEnemyProjectileType.Strong, 5)),
                new(40, false, new DSpreader(100, EEnemyProjectileType.Strong, 4)),
                new(40, false, new DSpreader(100, EEnemyProjectileType.Strong, 3)),
                new(40, false, new DSpreader(100, EEnemyProjectileType.Strong, 6)),
                new(40, false, new DSpreader(100, EEnemyProjectileType.Strong, 4)),

                new(40, false, new DSpreader(100, EEnemyProjectileType.Light, 5)),
                new(40, false, new DSpreader(100, EEnemyProjectileType.Light, 4)),
                new(40, false, new DSpreader(100, EEnemyProjectileType.Light, 3)),
                new(40, false, new DSpreader(100, EEnemyProjectileType.Light, 3)),
                new(40, false, new DSpreader(100, EEnemyProjectileType.Light, 6)),

                new(40, false, new DSniper(1300, EEnemyProjectileType.Normal)),
                new(40, false, new DSpreader(100, EEnemyProjectileType.Light, 3)),
                new(40, false, new DSpreader(100, EEnemyProjectileType.Strong, 6)),

                new(20, false, new DCommon(1300, 6)),
                new(20, false, new DCommon(1300, 6)),
                new(20, false, new DCommon(1300, 6)),
                new(20, false, new DCommon(1300, 6)),
                new(20, false, new DCommon(1300, 6)),
                new(20, false, new DCommon(1300, 6)),

                new(40, false, new DFollower(100, EEnemyProjectileType.Light)),

                new(20, false, new DCommon(1300, 6)),
                new(20, false, new DCommon(1300, 6)),
                new(20, false, new DCommon(1300, 6)),
                new(20, false, new DCommon(1300, 6)),
                new(20, false, new DCommon(1300, 6)),
                new(20, false, new DCommon(1300, 6)),

                new(40, false, new DFollower(100, EEnemyProjectileType.Light)),

                new(20, false, new DCommon(1300, 6)),
                new(20, false, new DCommon(1300, 6)),
                new(20, false, new DCommon(1300, 6)),
                new(20, false, new DCommon(1300, 6)),
                new(20, false, new DCommon(1300, 6)),
                new(20, false, new DCommon(1300, 6)),

                new(40, false, new DFollower(100, EEnemyProjectileType.Light)),

                new(40, false, new DSpreader(100, EEnemyProjectileType.Strong, 5)),
                new(40, false, new DSpreader(100, EEnemyProjectileType.Strong, 4)),
                new(40, false, new DSpreader(100, EEnemyProjectileType.Strong, 3)),
                new(40, false, new DSpreader(100, EEnemyProjectileType.Strong, 6)),
                new(120, false, new DSpreader(100, EEnemyProjectileType.Strong, 4)),

                new(10, false, new DSniper(100, EEnemyProjectileType.Light)),
                new(10, false, new DSniper(100, EEnemyProjectileType.Light)),
                new(10, false, new DSniper(100, EEnemyProjectileType.Light)),
                new(10, false, new DSniper(100, EEnemyProjectileType.Light)),
                new(10, false, new DSniper(100, EEnemyProjectileType.Light)),
                new(10, false, new DSniper(100, EEnemyProjectileType.Light)),
                new(10, false, new DSniper(100, EEnemyProjectileType.Light)),
                new(10, false, new DSniper(100, EEnemyProjectileType.Light)),
                new(10, false, new DSniper(100, EEnemyProjectileType.Light)),
                new(10, false, new DSniper(100, EEnemyProjectileType.Light)),
                new(10, false, new DSniper(100, EEnemyProjectileType.Light)),
                new(10, false, new DSniper(100, EEnemyProjectileType.Light)),
                new(10, false, new DSniper(100, EEnemyProjectileType.Light)),
                new(10, false, new DSniper(100, EEnemyProjectileType.Light)),
                new(10, false, new DSniper(100, EEnemyProjectileType.Light)),
                new(10, false, new DSniper(100, EEnemyProjectileType.Light)),
                new(10, false, new DSniper(100, EEnemyProjectileType.Light)),

            
            };

        }
    }
}