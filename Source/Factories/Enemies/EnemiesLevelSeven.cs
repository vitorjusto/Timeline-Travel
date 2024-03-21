using System.Collections.Generic;
using System.Net;
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
                new EnemySection(10, false, new DCommon(100, 9), new DCommon(1400, 9)),
                new EnemySection(10, false, new DCommon(200, 9), new DCommon(1300, 9)),
                new EnemySection(10, false, new DCommon(300, 9), new DCommon(1200, 9)),
                new EnemySection(10, false, new DCommon(400, 9), new DCommon(1100, 9)),
                new EnemySection(10, false, new DCommon(500, 9), new DCommon(1000, 9)),
                new EnemySection(10, false, new DCommon(600, 9), new DCommon(900, 9)),
                new EnemySection(10, false, new DCommon(700, 9), new DCommon(800, 9)),
                new EnemySection(10, false, new DCommon(600, 9), new DCommon(900, 9)),
                new EnemySection(10, false, new DCommon(500, 9), new DCommon(1000, 9)),
                new EnemySection(10, false, new DCommon(400, 9), new DCommon(1100, 9)),
                new EnemySection(10, false, new DCommon(300, 9), new DCommon(1200, 9)),
                new EnemySection(10, false, new DCommon(200, 9), new DCommon(1300, 9)),
                new EnemySection(10, false, new DCommon(100, 9), new DCommon(1400, 9)),
                new EnemySection(150, false, new DCrusader(100, 1)
                                          , new DCrusader(300, 1.8f)
                                          , new DCrusader(500, 2.6f)
                                          , new DCrusader(700, 3.4f)
                                          , new DCrusader(900, 4.2f) 
                                          , new DCrusader(1100, 5f)
                                          , new DCrusader(1300, 5.8f)),
                new EnemySection(30, false, new DBomber(100), new DDasher(1400)),                                    
                new EnemySection(10, false, new DLazer(500), new DFollower(700, EEnemyProjectileType.Light)),
                new EnemySection(500, false, new DSpread(100, EEnemyProjectileType.Light), new DSpread(1400, EEnemyProjectileType.Light), new DSpread(750, EEnemyProjectileType.Normal)),                        
                new EnemySection(10, false, new DDasher(1100)),                              
                new EnemySection(10, false, new DDasher(1100)),                              
                new EnemySection(10, false, new DDasher(1100)),                              
                new EnemySection(10, false, new DDasher(1100)),                              
                new EnemySection(10, false, new DDasher(1100)),                              
                new EnemySection(10, false, new DDasher(1100)),                              
                new EnemySection(10, false, new DDasher(1100)),                              
                new EnemySection(10, false, new DDasher(1100)),                              
                new EnemySection(160, false, new DDasher(1100)), 


                new EnemySection(40, false, new DGooder(200, true), new DSniper(300, EEnemyProjectileType.Light)),                     
                new EnemySection(40, false, new DGooder(200, true), new DSniper(100, EEnemyProjectileType.Light)),                     
                new EnemySection(40, false, new DGooder(200, true), new DSniper(500, EEnemyProjectileType.Light)),                     
                new EnemySection(40, false, new DGooder(200, true), new DSniper(600, EEnemyProjectileType.Light)),                     
                new EnemySection(40, false, new DGooder(200, true), new DSniper(400, EEnemyProjectileType.Light)),                     
                new EnemySection(40, false, new DGooder(200, true), new DSniper(700, EEnemyProjectileType.Light)),     

                new EnemySection(10, false, new DFollower(100, EEnemyProjectileType.Normal)),                     
                new EnemySection(10, false, new DFollower(200, EEnemyProjectileType.Normal)),                     
                new EnemySection(10, false, new DFollower(300, EEnemyProjectileType.Normal)),                     
                new EnemySection(10, false, new DFollower(400, EEnemyProjectileType.Normal)),                     
                new EnemySection(10, false, new DFollower(500, EEnemyProjectileType.Normal)),

                new EnemySection(50, false, new DSniper(100, EEnemyProjectileType.Normal), 
                                            new DSniper(300, EEnemyProjectileType.Normal), 
                                            new DSniper(500, EEnemyProjectileType.Normal), 
                                            new DSniper(700, EEnemyProjectileType.Homing),
                                            new DSniper(900, EEnemyProjectileType.Normal),
                                            new DSniper(1100, EEnemyProjectileType.Normal),
                                            new DSniper(1300, EEnemyProjectileType.Normal)),
                                            
                new EnemySection(50, false, new DSniper(100, EEnemyProjectileType.Normal), 
                                            new DSniper(300, EEnemyProjectileType.Normal), 
                                            new DSniper(500, EEnemyProjectileType.Normal), 
                                            new DSniper(700, EEnemyProjectileType.Homing),
                                            new DSniper(900, EEnemyProjectileType.Normal),
                                            new DSniper(1100, EEnemyProjectileType.Normal),
                                            new DSniper(1300, EEnemyProjectileType.Normal)),
                
                new EnemySection(350, false, new DSniper(100, EEnemyProjectileType.Normal), 
                                            new DSniper(300, EEnemyProjectileType.Normal), 
                                            new DSniper(500, EEnemyProjectileType.Normal), 
                                            new DSniper(700, EEnemyProjectileType.Homing),
                                            new DSniper(900, EEnemyProjectileType.Normal),
                                            new DSniper(1100, EEnemyProjectileType.Normal),
                                            new DSniper(1300, EEnemyProjectileType.Normal)),

                new EnemySection(10, false, new DShoter(100, EEnemyProjectileType.Normal), new DShoter(1300, EEnemyProjectileType.Normal)),
                new EnemySection(10, false, new DStomper(200)),
                new EnemySection(10, false, new DStomper(400)),
                new EnemySection(10, false, new DShoter(300, EEnemyProjectileType.Normal), new DShoter(1100, EEnemyProjectileType.Normal)),
                new EnemySection(10, false, new DStomper(800)),
                new EnemySection(10, false, new DStomper(1000)),

            };

        }        
    }
}