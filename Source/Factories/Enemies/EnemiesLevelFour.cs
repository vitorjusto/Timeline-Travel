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

                
                new(30, false, new DLazer(700, 1400), new DLazer(600, 1400), new DLazer(800, 1400)),

                new(100, false, new DDasher(100), new DDasher(1300)),

                new(50, false, new DDasher(100), new DDasher(1300)),
                new(50, false, new DDasher(200), new DDasher(1200)),
                new(50, false, new DDasher(300), new DDasher(1100)),

                new(10, false, new DSniper(100, EEnemyProjectileType.Light)
                             , new DSniper(200, EEnemyProjectileType.Light)
                             , new DSniper(300, EEnemyProjectileType.Light)
                             , new DSniper(400, EEnemyProjectileType.Light)
                             , new DSniper(500, EEnemyProjectileType.Light)
                             , new DSniper(900, EEnemyProjectileType.Light)
                             , new DSniper(1000, EEnemyProjectileType.Light)
                             , new DSniper(1100, EEnemyProjectileType.Light)
                             , new DSniper(1200, EEnemyProjectileType.Light)
                             , new DSniper(1300, EEnemyProjectileType.Light)),

                new(50, false, new DSpread(300, EEnemyProjectileType.Normal, 4), new DSpread(1100, EEnemyProjectileType.Normal, 4)),
                new(50, false, new DSpread(200, EEnemyProjectileType.Normal, 4), new DSpread(400, EEnemyProjectileType.Normal, 4), new DSpread(1000, EEnemyProjectileType.Normal, 4), new DSpread(1200, EEnemyProjectileType.Normal, 4)),
                new(150, false, new DSpread(300, EEnemyProjectileType.Normal, 4), new DSpread(100, EEnemyProjectileType.Normal, 4), new DSpread(500, EEnemyProjectileType.Normal, 4), new DSpread(900, EEnemyProjectileType.Normal, 4), new DSpread(1300, EEnemyProjectileType.Normal, 4), new DSpread(1100, EEnemyProjectileType.Normal, 4)),

                new(100, false, new DFollower(100, EEnemyProjectileType.Light)
                             , new DFollower(200, EEnemyProjectileType.Light)
                             , new DFollower(300, EEnemyProjectileType.Light)
                             , new DFollower(400, EEnemyProjectileType.Light)
                             , new DFollower(500, EEnemyProjectileType.Light)
                             , new DFollower(900, EEnemyProjectileType.Light)
                             , new DFollower(1000, EEnemyProjectileType.Light)
                             , new DFollower(1100, EEnemyProjectileType.Light)
                             , new DFollower(1200, EEnemyProjectileType.Light)
                             , new DFollower(1300, EEnemyProjectileType.Light)),
                
                new(10, true, new DShoter(100, EEnemyProjectileType.Light), new DShoter(500, EEnemyProjectileType.Normal), new DShoter(900, EEnemyProjectileType.Normal), new DShoter(1300, EEnemyProjectileType.Light)),

                new(60, false, new DCommon(100, 5), new DCommon(200, 5), new DCommon(300, 5), new DCommon(400, 5), new DCommon(500, 5), new DCommon(600, 5), new DCommon(700, 5), new DCommon(800, 5), new DCommon(900, 5), new DCommon(1000, 5), new DCommon(1100, 5), new DCommon(1200, 5), new DCommon(1300, 5)),
                new(60, false, new DCommon(100, 5), new DSpread(200, EEnemyProjectileType.Light, 5), new DSpread(300, EEnemyProjectileType.Light, 5), new DSpread(400, EEnemyProjectileType.Light, 5), new DSpread(500, EEnemyProjectileType.Light, 5), new DSpread(600, EEnemyProjectileType.Light, 5), new DSpread(700, EEnemyProjectileType.Light, 5), new DSpread(800, EEnemyProjectileType.Light, 5), new DSpread(900, EEnemyProjectileType.Light, 5), new DSpread(1000, EEnemyProjectileType.Light, 5), new DSpread(1100, EEnemyProjectileType.Light, 5), new DSpread(1200, EEnemyProjectileType.Light, 5), new DCommon(1300, 5)),
                new(60, false, new DCommon(100, 5), new DSpread(200, EEnemyProjectileType.Light, 5), new DCommon(300, 5), new DCommon(400, 5), new DCommon(500, 5), new DCommon(600, 5), new DCommon(700, 5), new DCommon(800, 5), new DCommon(900, 5), new DCommon(1000, 5), new DCommon(1100, 5), new DCommon(1200, 5), new DCommon(1300, 5)),
                new(60, false, new DCommon(100, 5), new DSpread(200, EEnemyProjectileType.Light, 5), new DCommon(300, 5)),

                new(60, false, new DCommon(100, 5), new DSpread(200, EEnemyProjectileType.Light, 5), new DCommon(300, 5), new DSpread(400, EEnemyProjectileType.Light, 5), new DCommon(500, 5), new DSpread(600, EEnemyProjectileType.Light, 5), new DCommon(700, 5), new DSpread(800, EEnemyProjectileType.Light, 5), new DCommon(900, 5), new DSpread(1000, EEnemyProjectileType.Light, 5), new DCommon(1100, 5), new DSpread(1200, EEnemyProjectileType.Light, 5), new DCommon(1300, 5)),
                new(60, false, new DCommon(100, 5), new DCommon(200, 5), new DSpread(300, EEnemyProjectileType.Light, 5), new DCommon(400, 5), new DSpread(500, EEnemyProjectileType.Light, 5), new DCommon(600, 5), new DSpread(700, EEnemyProjectileType.Light, 5), new DCommon(800, 5), new DSpread(900, EEnemyProjectileType.Light, 5), new DCommon(1000, 5), new DSpread(1100, EEnemyProjectileType.Light, 5), new DCommon(1200, 5), new DSpread(1300, EEnemyProjectileType.Light, 5)),

                new(60, false, new DCommon(100, 5), new DSpread(200, EEnemyProjectileType.Light, 5), new DCommon(300, 5)),
                new(60, false, new DCommon(100, 5), new DSpread(200, EEnemyProjectileType.Light, 5), new DCommon(300, 5), new DCommon(400, 5), new DCommon(500, 5), new DCommon(600, 5), new DCommon(700, 5), new DCommon(800, 5), new DCommon(900, 5), new DCommon(1000, 5), new DCommon(1100, 5), new DCommon(1200, 5), new DCommon(1300, 5)),
                new(60, false, new DCommon(100, 5), new DSpread(200, EEnemyProjectileType.Light, 5), new DSpread(300, EEnemyProjectileType.Light, 5), new DSpread(400, EEnemyProjectileType.Light, 5), new DSpread(500, EEnemyProjectileType.Light, 5), new DSpread(600, EEnemyProjectileType.Light, 5), new DSpread(700, EEnemyProjectileType.Light, 5), new DSpread(800, EEnemyProjectileType.Light, 5), new DSpread(900, EEnemyProjectileType.Light, 5), new DSpread(1000, EEnemyProjectileType.Light, 5), new DSpread(1100, EEnemyProjectileType.Light, 5), new DSpread(1200, EEnemyProjectileType.Light, 5), new DCommon(1300, 5)),
                new(60, true, new DCommon(100, 5), new DCommon(200, 5), new DCommon(300, 5), new DCommon(400, 5), new DCommon(500, 5), new DCommon(600, 5), new DCommon(700, 5), new DCommon(800, 5), new DCommon(900, 5), new DCommon(1000, 5), new DCommon(1100, 5), new DCommon(1200, 5), new DCommon(1300, 5)),

                new(10, false, new DDasher(100)),
                new(10, false, new DDasher(200)),
                new(10, false, new DDasher(300)),
                new(10, false, new DDasher(400)),
                new(10, false, new DDasher(500)),
                new(10, false, new DDasher(600)),
                new(10, false, new DDasher(700)),
                new(10, false, new DDasher(800)),
                new(10, false, new DDasher(900)),
                new(10, false, new DDasher(1000)),
                new(10, false, new DDasher(1100)),
                new(10, false, new DDasher(1200)),
                new(10, false, new DDasher(1300)),

                new(10, false, new DDasher(100)),
                new(10, false, new DDasher(200)),
                new(10, false, new DDasher(300)),
                new(10, false, new DDasher(400)),
                new(10, false, new DDasher(500)),
                new(10, false, new DDasher(600)),
                new(10, false, new DDasher(700)),
                new(10, false, new DDasher(800)),
                new(10, false, new DDasher(900)),
                new(10, false, new DDasher(1000)),
                new(10, false, new DDasher(1100)),
                new(10, false, new DDasher(1200)),
                new(10, false, new DDasher(1300)),

                new(10, false, new DDasher(100)),
                new(10, false, new DDasher(200)),
                new(10, false, new DDasher(300)),
                new(10, false, new DDasher(400)),
                new(10, false, new DDasher(500)),
                new(10, false, new DDasher(600)),
                new(10, false, new DDasher(700)),
                new(10, false, new DDasher(800)),
                new(10, false, new DDasher(900)),
                new(10, false, new DDasher(1000)),
                new(10, false, new DDasher(1100)),
                new(10, false, new DDasher(1200)),
                new(10, false, new DDasher(1300)),

                new(10, false, new DDasher(100)),
                new(10, false, new DDasher(200)),
                new(10, false, new DDasher(300)),
                new(10, false, new DDasher(400)),
                new(10, false, new DDasher(500)),
                new(10, false, new DDasher(600)),
                new(10, false, new DSniper(700, EEnemyProjectileType.Light)),
                new(10, false, new DDasher(800)),
                new(10, false, new DDasher(900)),
                new(10, false, new DDasher(1000)),
                new(10, false, new DDasher(1100)),
                new(10, false, new DDasher(1200)),
                new(10, true, new DDasher(1300)),    


                new(50, false, new DSpread(100, EEnemyProjectileType.Normal, 3), new DSpread(1300, EEnemyProjectileType.Normal, 3)),

                new(50, false, new DSpread(200, EEnemyProjectileType.Normal, 3), new DSpread(1200, EEnemyProjectileType.Normal, 3), new DCommon(100, 3), 
                                                                                                                                    new DCommon(1300, 3)),
            
                new(50, false, new DSpread(300, EEnemyProjectileType.Normal, 3), new DSpread(1100, EEnemyProjectileType.Normal, 3), new DCommon(100, 3),
                                                                                                                                    new DCommon(200, 3), 
                                                                                                                                    new DCommon(1200, 3), 
                                                                                                                                    new DCommon(1300, 3)),
                
                new(50, false, new DSpread(400, EEnemyProjectileType.Normal, 3), new DSpread(1000, EEnemyProjectileType.Normal, 3), new DCommon(100, 3),
                                                                                                                                    new DCommon(200, 3), 
                                                                                                                                    new DCommon(300, 3), 
                                                                                                                                    new DCommon(1100, 3), 
                                                                                                                                    new DCommon(1200, 3), 
                                                                                                                                    new DCommon(1300, 3)),
            
                new(50, false, new DSpread(500, EEnemyProjectileType.Normal, 3), new DSpread(900, EEnemyProjectileType.Normal, 3), new DCommon(100, 3),
                                                                                                                                    new DCommon(200, 3), 
                                                                                                                                    new DCommon(300, 3), 
                                                                                                                                    new DCommon(400, 3), 
                                                                                                                                    new DCommon(1000, 3), 
                                                                                                                                    new DCommon(1100, 3), 
                                                                                                                                    new DCommon(1200, 3), 
                                                                                                                                    new DCommon(1300, 3)),
            
                new(50, false, new DSpread(600, EEnemyProjectileType.Normal, 3), new DSpread(800, EEnemyProjectileType.Normal, 3), new DCommon(100, 3),
                                                                                                                                    new DCommon(200, 3), 
                                                                                                                                    new DCommon(300, 3), 
                                                                                                                                    new DCommon(400, 3), 
                                                                                                                                    new DCommon(500, 3), 
                                                                                                                                    new DCommon(900, 3), 
                                                                                                                                    new DCommon(1000, 3), 
                                                                                                                                    new DCommon(1100, 3), 
                                                                                                                                    new DCommon(1200, 3), 
                                                                                                                                    new DCommon(1300, 3)),

                new(50, false, new DSpread(700, EEnemyProjectileType.Normal, 3),new DCommon(100, 3),
                                                                                new DCommon(200, 3), 
                                                                                new DCommon(300, 3), 
                                                                                new DCommon(400, 3), 
                                                                                new DCommon(500, 3), 
                                                                                new DCommon(600, 3), 
                                                                                new DCommon(800, 3), 
                                                                                new DCommon(900, 3), 
                                                                                new DCommon(1000, 3), 
                                                                                new DCommon(1100, 3), 
                                                                                new DCommon(1200, 3), 
                                                                                new DCommon(1300, 3)),

                new(50, false, new DSpread(600, EEnemyProjectileType.Normal, 3), new DSpread(800, EEnemyProjectileType.Normal, 3), new DCommon(100, 3),
                                                                                                                                    new DCommon(200, 3), 
                                                                                                                                    new DCommon(300, 3), 
                                                                                                                                    new DCommon(400, 3), 
                                                                                                                                    new DCommon(500, 3), 
                                                                                                                                    new DCommon(900, 3), 
                                                                                                                                    new DCommon(1000, 3), 
                                                                                                                                    new DCommon(1100, 3), 
                                                                                                                                    new DCommon(1200, 3), 
                                                                                                                                    new DCommon(1300, 3)),
                                                        
                new(50, false, new DSpread(500, EEnemyProjectileType.Normal, 3), new DSpread(900, EEnemyProjectileType.Normal, 3), new DCommon(100, 3),
                                                                                                                                    new DCommon(200, 3), 
                                                                                                                                    new DCommon(300, 3), 
                                                                                                                                    new DCommon(400, 3), 
                                                                                                                                    new DCommon(1000, 3), 
                                                                                                                                    new DCommon(1100, 3), 
                                                                                                                                    new DCommon(1200, 3), 
                                                                                                                                    new DCommon(1300, 3)),
            
                new(50, false, new DSpread(400, EEnemyProjectileType.Normal, 3), new DSpread(1000, EEnemyProjectileType.Normal, 3), new DCommon(100, 3),
                                                                                                                                    new DCommon(200, 3), 
                                                                                                                                    new DCommon(300, 3), 
                                                                                                                                    new DCommon(1100, 3), 
                                                                                                                                    new DCommon(1200, 3), 
                                                                                                                                    new DCommon(1300, 3)),

                new(50, false, new DSpread(300, EEnemyProjectileType.Normal, 3), new DSpread(1100, EEnemyProjectileType.Normal, 3), new DCommon(100, 3),
                                                                                                                                    new DCommon(200, 3), 
                                                                                                                                    new DCommon(1200, 3), 
                                                                                                                                    new DCommon(1300, 3)),

                new(50, false, new DSpread(200, EEnemyProjectileType.Normal, 3), new DSpread(1200, EEnemyProjectileType.Normal, 3), new DCommon(100, 3), 
                                                                                                                                    new DCommon(1300, 3)),
                           
                new(50, true, new DSpread(100, EEnemyProjectileType.Normal, 3), new DSpread(1300, EEnemyProjectileType.Normal, 3)),

                new(20, false, new DLazer(200, 400), new DLazer(700, 400), new DLazer(1200, 400)),

                new(20, false, new DCommon(300, 5), new DCommon(400, 5), new DCommon(500, 5), new DCommon(600, 5), new DCommon(800, 5), new DCommon(900, 5), new DCommon(1000, 5), new DCommon(1100, 5)),
                new(20, false, new DCommon(300, 5), new DCommon(400, 5), new DCommon(500, 5), new DCommon(600, 5), new DCommon(800, 5), new DCommon(900, 5), new DCommon(1000, 5), new DCommon(1100, 5)),
                new(20, false, new DCommon(300, 5), new DCommon(400, 5), new DCommon(500, 5), new DCommon(600, 5), new DCommon(800, 5), new DCommon(900, 5), new DCommon(1000, 5), new DCommon(1100, 5)),
                new(20, false, new DCommon(300, 5), new DCommon(400, 5), new DCommon(500, 5), new DCommon(600, 5), new DCommon(800, 5), new DCommon(900, 5), new DCommon(1000, 5), new DCommon(1100, 5)),
                new(20, false, new DCommon(300, 5), new DCommon(400, 5), new DCommon(500, 5), new DCommon(600, 5), new DCommon(800, 5), new DCommon(900, 5), new DCommon(1000, 5), new DCommon(1100, 5)),
                new(20, false, new DCommon(300, 5), new DCommon(400, 5), new DCommon(500, 5), new DCommon(600, 5), new DCommon(800, 5), new DCommon(900, 5), new DCommon(1000, 5), new DCommon(1100, 5)),
                new(20, false, new DCommon(300, 5), new DCommon(400, 5), new DCommon(500, 5), new DCommon(600, 5), new DCommon(800, 5), new DCommon(900, 5), new DCommon(1000, 5), new DCommon(1100, 5)),
            };

        }
        
    }
}