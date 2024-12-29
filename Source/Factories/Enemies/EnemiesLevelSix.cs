using System.Collections.Generic;
using Shooter.Source.Dumies.Enemies;
using Shooter.Source.Enums;
using Shooter.Source.Models.Levels;

namespace Shooter.Source.Factories.Enemies
{
    public class EnemiesLevelSix
    {
        public static List<EnemySection> GetEnemies()
        {
            return new List<EnemySection>()
            {
                new(10, true, new DLighting(700), new DLighting(600), new DLighting(800)),
                new(10, true, new DLighting(100), new DLighting(200), new DLighting(300), new DLighting(400), new DLighting(500), new DLighting(600), new DLighting(700), new DLighting(800), new DLighting(900)),
                new(10, true, new DLighting(1300), new DLighting(1200), new DLighting(1100), new DLighting(1000), new DLighting(900), new DLighting(800), new DLighting(700), new DLighting(600), new DLighting(500), new DLighting(400), new DLighting(300)),

                new(20, false, new DCrusader(100, 1), new DCrusader(100, 4), new DCrusader(1300, 1), new DCrusader(1300, 4)),
                new(20, true, new DSpread(700, EEnemyProjectileType.Normal)),

                new(10, false, new DLighting(100)),
                new(10, false, new DLighting(200)),
                new(10, false, new DLighting(300)),
                new(10, false, new DLighting(400)),
                new(10, false, new DLighting(500)),
                new(10, false, new DLighting(600), new DSpreader(100,  EEnemyProjectileType.Light, 4)),
                new(10, false, new DLighting(700)),
                new(10, false, new DLighting(800), new DSpreader(100,  EEnemyProjectileType.Light, 3), new DSpreader(250,  EEnemyProjectileType.Normal, 3)),
                new(10, false, new DLighting(900)),
                new(60, false, new DLighting(1000)),

                new(30, false, new DLighting(1200)),
                new(20, false, new DLighting(1300), new DLighting(1100)),
                new(10, true, new DLighting(1000), new DLighting(900), new DLighting(800)),

                new(10, false, new DLighting(100)
                            , new DLighting(200)
                            , new DLighting(500)
                            , new DLighting(600)
                            , new DLighting(700)
                            , new DLighting(800)
                            , new DLighting(900)
                            , new DLighting(1000)
                            , new DLighting(1100)
                            , new DLighting(1200)
                            , new DLighting(1300)),

                new(15, false, new DCommon(300, 5), new DCommon(400, 5)),
                new(15, false, new DCommon(300, 5), new DCommon(400, 5)),
                new(15, false, new DCommon(300, 5), new DCommon(400, 5)),
                new(15, false, new DSpread(300, EEnemyProjectileType.Normal,5), new DSpread(400, EEnemyProjectileType.Light, 5)),
                new(15, false, new DSpread(300, EEnemyProjectileType.Normal,5), new DSpread(400, EEnemyProjectileType.Light, 5)),
                new(15, true, new DSpread(300, EEnemyProjectileType.Normal,5), new DSpread(400, EEnemyProjectileType.Light, 5)),

                new(30, false, new DLazer(100, 2000)
                             , new DLazer(200, 2000)
                             , new DLazer(0, 2000)
                             , new DLazer(300, 2000)
                             , new DLazer(400, 2000)
                             , new DLazer(500, 2000)
                             , new DLazer(900, 2000)
                             , new DLazer(1000, 2000)
                             , new DLazer(1100, 2000)
                             , new DLazer(1200, 2000)
                             , new DLazer(1400, 2000)
                             , new DLazer(1300, 2000)),

                new(40, false, new DLighting(600), new DLighting(700)),
                new(40, false, new DLighting(800), new DLighting(700)),
                new(40, false, new DLighting(600), new DLighting(700)),
                new(40, false, new DLighting(800), new DLighting(700)),
                new(40, false, new DLighting(600), new DLighting(700)),
                new(100, false, new DLighting(800), new DLighting(700)),

                new(40, false, new DCrusader(800, 3)),
                new(100, false, new DLighting(600), new DLighting(700)),

                new(50, false, new DCommon(600, 3), new DCommon(700, 3), new DCommon(800, 3)),
                new(50, false, new DCommon(600, 3), new DCommon(700, 3), new DCommon(800, 3)),
                new(50, false, new DCommon(600, 3), new DCommon(700, 3), new DCommon(800, 3)),
                new(50, false, new DCommon(600, 3), new DCommon(700, 3), new DCommon(800, 3)),
                new(50, false, new DSpread(600, EEnemyProjectileType.Normal, 3), new DSpread(700, EEnemyProjectileType.Light, 3), new DSpread(800, EEnemyProjectileType.Normal, 3)),
                new(50, false, new DSpread(600, EEnemyProjectileType.Light, 3), new DSpread(700, EEnemyProjectileType.Strong, 3), new DSpread(800, EEnemyProjectileType.Light, 3)),
                new(150, false, new DSpread(600, EEnemyProjectileType.Strong, 3), new DSpread(700, EEnemyProjectileType.Normal, 3), new DSpread(800, EEnemyProjectileType.Strong, 3)),

                new(60, false, new DCrusader(700, 4)),
                new(40, false, new DLighting(600), new DLighting(800)),
                new(40, false, new DLighting(700)),

                new(10, false, new DSniper(600, EEnemyProjectileType.Normal), new DSniper(800, EEnemyProjectileType.Normal)),
                new(10, false, new DSniper(600, EEnemyProjectileType.Normal), new DSniper(800, EEnemyProjectileType.Normal)),
                new(10, false, new DSniper(600, EEnemyProjectileType.Normal), new DSniper(800, EEnemyProjectileType.Normal)),
                new(10, false, new DSniper(600, EEnemyProjectileType.Normal), new DSniper(800, EEnemyProjectileType.Normal)),
                new(10, false, new DSniper(600, EEnemyProjectileType.Normal), new DSniper(800, EEnemyProjectileType.Normal)),
                new(10, false, new DSniper(600, EEnemyProjectileType.Normal), new DSniper(800, EEnemyProjectileType.Normal)),
                new(10, false, new DSniper(600, EEnemyProjectileType.Normal), new DSniper(800, EEnemyProjectileType.Normal)),
                new(10, false, new DSniper(600, EEnemyProjectileType.Normal), new DSniper(800, EEnemyProjectileType.Normal)),

                new(60, false, new DCrusader(700, 4)),
                new(200, false, new DCrusader(600, 3), new DCrusader(800, 3)),

                new(20, false, new DFollower(600, EEnemyProjectileType.Normal), new DFollower(700, EEnemyProjectileType.Normal), new DFollower(800, EEnemyProjectileType.Normal)),
                new(20, false, new DFollower(600, EEnemyProjectileType.Normal), new DFollower(700, EEnemyProjectileType.Normal), new DFollower(800, EEnemyProjectileType.Normal)),
                new(20, false, new DFollower(600, EEnemyProjectileType.Normal), new DFollower(700, EEnemyProjectileType.Normal), new DFollower(800, EEnemyProjectileType.Normal)),

                new(20, false, new DSniper(700, EEnemyProjectileType.Homing)),

                new(50, false, new DCommon(600, 5), new DCommon(700, 5), new DCommon(800, 5)),
                new(50, false, new DCommon(600, 5), new DCommon(700, 5), new DCommon(800, 5)),
                new(50, false, new DCommon(600, 5), new DSpread(700, EEnemyProjectileType.Normal, 5), new DCommon(800, 5)),
                new(50, false, new DCommon(600, 5), new DSpread(700, EEnemyProjectileType.Normal, 5), new DCommon(800, 5)),
                new(50, false, new DCommon(600, 5), new DSpread(700, EEnemyProjectileType.Normal, 5), new DCommon(800, 5)),
                new(50, false, new DCommon(600, 5), new DSpread(700, EEnemyProjectileType.Normal, 5), new DCommon(800, 5)),
                new(100, false, new DCommon(600, 5), new DCommon(700, 5), new DCommon(800, 5)),

                new(40, false, new DSpreader(700, EEnemyProjectileType.Light, 6)),
                new(40, false, new DSpreader(700, EEnemyProjectileType.Light, 6)),
                new(40, true, new DLighting(600), new DLighting(700), new DLighting(800)),

                new(40, false, new DCommon(600, 4), new DCommon(500, 4), new DCommon(400, 4), new DCommon(900, 4), new DCommon(1000, 4)),
                new(40, false, new DCommon(600, 4), new DSpread(500, EEnemyProjectileType.Normal, 4), new DCommon(400, 4), new DCommon(800, 4), new DCrusader(900, 4), new DCommon(1000, 4)),
                new(40, false, new DCommon(600, 4), new DSpread(500, EEnemyProjectileType.Normal, 4), new DCommon(400, 4), new DCommon(700, 4), new DCrusader(800, 4), new DCommon(900, 4)),
                new(40, false, new DCommon(600, 4), new DSpread(500, EEnemyProjectileType.Normal, 4), new DCommon(400, 4), new DCrusader(700, 4), new DCommon(800, 4)),
                new(40, false, new DSpread(500, EEnemyProjectileType.Normal, 4), new DCommon(400, 4), new DCrusader(600, 4), new DCommon(700, 4), new DCommon(800, 4), new DCommon(900, 4), new DCommon(1000, 4)),
                new(40, false, new DCommon(400, 4), new DSpread(500, EEnemyProjectileType.Normal, 4), new DSpread(600, EEnemyProjectileType.Normal, 4), new DSpread(700, EEnemyProjectileType.Normal, 4), new DSpread(800, EEnemyProjectileType.Normal, 4), new DSpread(900, EEnemyProjectileType.Normal, 4), new DCommon(1000, 4)),
                new(40, false, new DCommon(400, 4), new DSpread(500, EEnemyProjectileType.Normal, 4), new DCommon(600, 4), new DCommon(700, 4), new DCommon(800, 4), new DSpread(900, EEnemyProjectileType.Normal, 4), new DCommon(1000, 4)),
                new(40, false, new DCommon(400, 4), new DSpread(500, EEnemyProjectileType.Normal, 4), new DSpread(600, EEnemyProjectileType.Normal, 4), new DSpread(700, EEnemyProjectileType.Normal, 4), new DSpread(800, EEnemyProjectileType.Normal, 4), new DSpread(900, EEnemyProjectileType.Normal, 4), new DCommon(1000, 4)),
                new(40, true, new DCommon(400, 4), new DCommon(500, 4), new DCommon(600, 4), new DCommon(700, 4), new DCommon(800, 4), new DCommon(900, 4), new DCommon(1000, 4)),


                new(80, false, new DSpreader(100, EEnemyProjectileType.Light, 8)
                             , new DSpreader(1300, EEnemyProjectileType.Light, 8)
                             , new DLighting(100)
                             , new DLighting(300)
                             , new DLighting(500)
                             , new DLighting(700)
                             , new DLighting(900)
                             , new DLighting(1100)
                             , new DLighting(1300)) { CheckpointId = 1 },
                
                new(80, false
                             , new DLighting(200)
                             , new DLighting(400)
                             , new DLighting(600)
                             , new DLighting(800)
                             , new DLighting(1000)
                             , new DLighting(1200)),

                new(80, false, new DSpreader(100, EEnemyProjectileType.Light, 8)
                             , new DSpreader(1300, EEnemyProjectileType.Light, 8)
                             , new DLighting(100)
                             , new DLighting(300)
                             , new DLighting(500)
                             , new DLighting(700)
                             , new DLighting(900)
                             , new DLighting(1100)
                             , new DLighting(1300)),
            
                new(80, false
                             , new DLighting(200)
                             , new DLighting(400)
                             , new DLighting(600)
                             , new DLighting(800)
                             , new DLighting(1000)
                             , new DLighting(1200)),
                
                new(80, false, new DSpreader(100, EEnemyProjectileType.Light, 8)
                             , new DSpreader(1300, EEnemyProjectileType.Light, 8)
                             , new DLighting(100)
                             , new DLighting(300)
                             , new DLighting(500)
                             , new DLighting(700)
                             , new DLighting(900)
                             , new DLighting(1100)
                             , new DLighting(1300)),
            
                new(80, false
                             , new DLighting(200)
                             , new DLighting(400)
                             , new DLighting(600)
                             , new DLighting(800)
                             , new DLighting(1000)
                             , new DLighting(1200)),
                
                new(80, false, new DSpreader(100, EEnemyProjectileType.Light, 8)
                             , new DSpreader(1300, EEnemyProjectileType.Light, 8)
                             , new DLighting(100)
                             , new DLighting(300)
                             , new DLighting(500)
                             , new DLighting(700)
                             , new DLighting(900)
                             , new DLighting(1100)
                             , new DLighting(1300)),
            
                new(50, false, new DLighting(200)
                             , new DLighting(400)
                             , new DLighting(600)
                             , new DLighting(800)
                             , new DLighting(1000)
                             , new DLighting(1200)),

                new(50, false, new DLighting(100)
                             , new DLighting(300)
                             , new DLighting(500)
                             , new DLighting(700)
                             , new DLighting(900)
                             , new DLighting(1100)
                             , new DLighting(1300)),

                new(50, false, new DLighting(200)
                             , new DLighting(400)
                             , new DLighting(600)
                             , new DLighting(800)
                             , new DLighting(1000)
                             , new DLighting(1200)),

                new(50, false, new DLighting(100)
                             , new DLighting(300)
                             , new DLighting(500)
                             , new DLighting(700)
                             , new DLighting(900)
                             , new DLighting(1100)
                             , new DLighting(1300)),

                new(50, false, new DLighting(200)
                             , new DLighting(400)
                             , new DLighting(600)
                             , new DLighting(800)
                             , new DLighting(1000)
                             , new DLighting(1200)),

                new(50, false, new DLighting(100)
                             , new DLighting(300)
                             , new DLighting(500)
                             , new DLighting(700)
                             , new DLighting(900)
                             , new DLighting(1100)
                             , new DLighting(1300)),

                new(50, false, new DLighting(200)
                             , new DLighting(400)
                             , new DLighting(600)
                             , new DLighting(800)
                             , new DLighting(1000)
                             , new DLighting(1200)),

                new(50, false, new DLighting(100)
                             , new DLighting(300)
                             , new DLighting(500)
                             , new DLighting(700)
                             , new DLighting(900)
                             , new DLighting(1100)
                             , new DLighting(1300)),

                new(50, false, new DCommon(100, 3)
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

                new(50, false, new DCommon(100, 3)
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

                new(50, false, new DCrusader(100, 3)
                             , new DCommon(200, 3)
                             , new DCommon(300, 3)
                             , new DCommon(400, 3)
                             , new DCommon(500, 3)
                             , new DCommon(600, 3)
                             , new DCrusader(700, 3)
                             , new DCommon(800, 3)
                             , new DCommon(900, 3)
                             , new DCommon(1000, 3)
                             , new DCommon(1100, 3)
                             , new DCommon(1200, 3)
                             , new DCrusader(1300, 3)),

                new(50, false, new DCommon(100, 3)
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

                new(50, false, new DCommon(100, 3)
                             , new DCrusader(200, 3)
                             , new DCommon(300, 3)
                             , new DCommon(400, 3)
                             , new DCrusader(500, 3)
                             , new DCommon(600, 3)
                             , new DCommon(700, 3)
                             , new DCommon(800, 3)
                             , new DCrusader(900, 3)
                             , new DCommon(1000, 3)
                             , new DCommon(1100, 3)
                             , new DCrusader(1200, 3)
                             , new DCommon(1300, 3)),

                new(50, false, new DCommon(100, 3)
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

                new(50, false, new DCommon(100, 3)
                             , new DCommon(200, 3)
                             , new DCrusader(300, 3)
                             , new DCommon(400, 3)
                             , new DCommon(500, 3)
                             , new DCommon(600, 3)
                             , new DCrusader(700, 3)
                             , new DCommon(800, 3)
                             , new DCommon(900, 3)
                             , new DCommon(1000, 3)
                             , new DCrusader(1100, 3)
                             , new DCommon(1200, 3)
                             , new DCommon(1300, 3)),

                new(50, false, new DCommon(100, 3)
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

                new(50, false, new DCommon(100, 3)
                             , new DCommon(200, 3)
                             , new DCommon(300, 3)
                             , new DCrusader(400, 3)
                             , new DCrusader(500, 3)
                             , new DCommon(600, 3)
                             , new DCommon(700, 3)
                             , new DCommon(800, 3)
                             , new DCrusader(900, 3)
                             , new DCrusader(1000, 3)
                             , new DCommon(1100, 3)
                             , new DCommon(1200, 3)
                             , new DCommon(1300, 3)),

                new(50, false, new DCommon(100, 3)
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

                new(50, false, new DCrusader(100, 3)
                             , new DCommon(200, 3)
                             , new DCommon(300, 3)
                             , new DCrusader(400, 3)
                             , new DCommon(500, 3)
                             , new DCommon(600, 3)
                             , new DCrusader(700, 3)
                             , new DCommon(800, 3)
                             , new DCommon(900, 3)
                             , new DCrusader(1000, 3)
                             , new DCommon(1100, 3)
                             , new DCommon(1200, 3)
                             , new DCrusader(1300, 3)),

                new(50, true, new DCommon(100, 3)
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
                             , new DCommon(1300, 3)) { CheckpointId = 2 },

                new(10, false, new DLighting(300)
                            , new DLighting(400)
                            , new DLighting(500)
                            , new DLighting(600)
                            , new DLighting(700)
                            , new DLighting(800)
                            , new DLighting(900)
                            , new DLighting(1000)
                            , new DLighting(1100)
                            , new DLighting(1200)
                            , new DLighting(1300)),

                new(15, false, new DCommon(100, 5), new DCommon(200, 5)),
                new(15, false, new DCommon(100, 5), new DCommon(200, 5)),
                new(15, false, new DCommon(100, 5), new DCommon(200, 5)),
                new(15, false, new DSpread(100, EEnemyProjectileType.Normal,5), new DSpread(200, EEnemyProjectileType.Light, 5)),
                new(15, false, new DSpread(100, EEnemyProjectileType.Normal,5), new DSpread(200, EEnemyProjectileType.Light, 5)),
                new(100, false, new DSpread(100, EEnemyProjectileType.Normal,5), new DSpread(200, EEnemyProjectileType.Light, 5)),

                new(10, false, new DLighting(300)
                            , new DLighting(400)
                            , new DLighting(500)
                            , new DLighting(600)
                            , new DLighting(700)
                            , new DLighting(800)
                            , new DLighting(900)
                            , new DLighting(1000)
                            , new DLighting(1100)
                            , new DLighting(100)
                            , new DLighting(200)),

                new(15, false, new DCommon(1300, 5), new DCommon(1200, 5)),
                new(15, false, new DCommon(1300, 5), new DCommon(1200, 5)),
                new(15, false, new DCommon(1300, 5), new DCommon(1200, 5)),
                new(15, false, new DSpread(1300, EEnemyProjectileType.Normal,5), new DSpread(1200, EEnemyProjectileType.Light, 5)),
                new(15, false, new DSpread(1300, EEnemyProjectileType.Normal,5), new DSpread(1200, EEnemyProjectileType.Light, 5)),
                new(100, false, new DSpread(1300, EEnemyProjectileType.Normal,5), new DSpread(1200, EEnemyProjectileType.Light, 5)),

                new(10, false, new DLighting(100)
                            , new DLighting(200)
                            , new DLighting(300)
                            , new DLighting(400)
                            , new DLighting(400)
                            , new DLighting(500)
                            , new DLighting(600)
                            , new DLighting(800)
                            , new DLighting(900)
                            , new DLighting(1000)
                            , new DLighting(1100)
                            , new DLighting(1200)
                            , new DLighting(1300)),
            };

        }
    }
}