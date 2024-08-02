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
                new(60, false, new DSniper(100, EEnemyProjectileType.Normal)
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

                new(60, false, new DSniper(100, EEnemyProjectileType.Normal)
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


                new(60, false, new DSniper(100, EEnemyProjectileType.Normal)
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


                new(60, false, new DSniper(100, EEnemyProjectileType.Normal)
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

                new(60, false, new DSniper(100, EEnemyProjectileType.Normal)
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

                new(40, false, new DBomber(100)),
                new(40, false, new DBomber(300)),
                new(40, false, new DBomber(500)),
                new(40, false, new DBomber(700)),
                new(40, false, new DBomber(900)),
                new(40, false, new DBomber(1100)),
                new(40, true, new DBomber(1300)),

                new(200, false, new DGooder(600, false)
                             , new DGooder(700, false)
                             , new DGooder(800, false)),

                new(40, false, new DFollower(100, EEnemyProjectileType.Light)
                             , new DFollower(200, EEnemyProjectileType.Light)
                             , new DFollower(300, EEnemyProjectileType.Light)
                             , new DFollower(400, EEnemyProjectileType.Light)
                             , new DFollower(500, EEnemyProjectileType.Light)
                             , new DFollower(900, EEnemyProjectileType.Light)
                             , new DFollower(1000, EEnemyProjectileType.Light)
                             , new DFollower(1100, EEnemyProjectileType.Light)
                             , new DFollower(1200, EEnemyProjectileType.Light)
                             , new DFollower(1300, EEnemyProjectileType.Light)),
                    
                new(20, false, new DCommon(600, 5)
                             , new DCommon(700, 5)
                             , new DCommon(800, 5)),
                
                new(20, false, new DCommon(600, 5)
                             , new DSpread(700, EEnemyProjectileType.Light, 5)
                             , new DCommon(800, 5)),
                
                new(20, false, new DCommon(600, 5)
                             , new DSpread(700, EEnemyProjectileType.Light, 5)
                             , new DCommon(800, 5)),

                new(20, false, new DCommon(600, 5)
                             , new DSpread(700, EEnemyProjectileType.Light, 5)
                             , new DCommon(800, 5)), 

                new(20, false, new DCommon(600, 5)
                             , new DSpread(700, EEnemyProjectileType.Light, 5)
                             , new DCommon(800, 5)), 
                
                new(20, false, new DCommon(600, 5)
                             , new DSpread(700, EEnemyProjectileType.Light, 5)
                             , new DCommon(800, 5)), 

                new(20, false, new DCommon(600, 5)
                             , new DSpread(700, EEnemyProjectileType.Light, 5)
                             , new DCommon(800, 5)), 

                new(100, false, new DCommon(600, 5)
                             , new DCommon(700, 5)
                             , new DCommon(800, 5)),   

                new(40, false, new DFollower(100, EEnemyProjectileType.Light)),     
                new(40, false, new DFollower(1300, EEnemyProjectileType.Light)),     
                new(40, false, new DFollower(1000, EEnemyProjectileType.Light)),     
                new(40, false, new DFollower(1300, EEnemyProjectileType.Light)),     

                new(60, false, new DSniper(100, EEnemyProjectileType.Light)
                             , new DSniper(200, EEnemyProjectileType.Light)
                             , new DSniper(300, EEnemyProjectileType.Light)
                             , new DSniper(400, EEnemyProjectileType.Light)
                             , new DSniper(500, EEnemyProjectileType.Light)
                             , new DSniper(900, EEnemyProjectileType.Light)
                             , new DSniper(1000, EEnemyProjectileType.Light)
                             , new DSniper(1100, EEnemyProjectileType.Light)
                             , new DSniper(1200, EEnemyProjectileType.Light)
                             , new DSniper(1300, EEnemyProjectileType.Light)),
                
                new(60, false, new DSniper(100, EEnemyProjectileType.Light)
                             , new DSniper(200, EEnemyProjectileType.Light)
                             , new DSniper(300, EEnemyProjectileType.Light)
                             , new DSniper(400, EEnemyProjectileType.Light)
                             , new DSniper(500, EEnemyProjectileType.Light)
                             , new DSniper(900, EEnemyProjectileType.Light)
                             , new DSniper(1000, EEnemyProjectileType.Light)
                             , new DSniper(1100, EEnemyProjectileType.Light)
                             , new DSniper(1200, EEnemyProjectileType.Light)
                             , new DSniper(1300, EEnemyProjectileType.Light)),

                 new(60, true, new DSniper(100, EEnemyProjectileType.Light)
                             , new DSniper(200, EEnemyProjectileType.Light)
                             , new DSniper(300, EEnemyProjectileType.Light)
                             , new DSniper(400, EEnemyProjectileType.Light)
                             , new DSniper(500, EEnemyProjectileType.Light)
                             , new DSniper(900, EEnemyProjectileType.Light)
                             , new DSniper(1000, EEnemyProjectileType.Light)
                             , new DSniper(1100, EEnemyProjectileType.Light)
                             , new DSniper(1200, EEnemyProjectileType.Light)
                             , new DSniper(1300, EEnemyProjectileType.Light)),    


                new(20, false, new DLazer(50, 2580)),                                 
                new(20, false, new DLazer(150, 2560)),                                 
                new(20, false, new DLazer(250, 2540)),                                 
                new(20, false, new DLazer(350, 2520)),                                 
                new(20, false, new DLazer(450, 660)),                                 
                new(20, false, new DLazer(550, 620)),                                 
                new(20, false, new DLazer(650, 580)),                                 
                new(20, false, new DLazer(750, 540)),                                 
                new(20, false, new DLazer(850, 500)),                                 
                new(20, false, new DLazer(950, 460)),                                 
                new(20, false, new DLazer(1050, 420)),                                 
                new(20, false, new DLazer(1150, 380)),                                 
                new(80, false, new DLazer(1250, 320)), 

                new(60, false, new DBomber(350)),
                new(60, false, new DBomber(250)),
                new(60, false, new DBomber(150)),
                new(120, false, new DBomber(50)),

                new(20, false, new DLazer(1350, 1960)),  
                new(20, false, new DLazer(1250, 1940)),  
                new(20, false, new DLazer(1150, 1920)),  
                new(20, false, new DLazer(1050, 1900)),  
                new(20, false, new DLazer(950, 780)),  
                new(20, false, new DLazer(850, 1860)),  
                new(20, false, new DLazer(750, 540)),  
                new(20, false, new DLazer(650, 460)),  
                new(100, false, new DLazer(550, 420)),  

                new(60, false, new DGooder(450, false, 450)),

                new(20, false, new DCommon(450, 5)),
                new(20, false, new DCommon(450, 5)),
                new(20, false, new DCommon(450, 5)),
                new(20, false, new DCommon(450, 5)),
                new(20, false, new DCommon(450, 5)),
                new(120, false, new DCommon(450, 5)),

                new(20, false, new DCommon(450, 10)),
                new(20, false, new DCommon(450, 10)),
                new(20, false, new DCommon(450, 10)),

                new(20, false, new DFollower(750, EEnemyProjectileType.Normal)),
                new(20, false, new DFollower(850, EEnemyProjectileType.Normal)),

                new(20, false, new DLazer(450, 1320)),  
                new(20, false, new DLazer(550, 200)),  
                new(80, false, new DLazer(650, 1280)), 

                new(20, false, new DCommon(750, 20)), 
                new(20, false, new DCommon(750, 20)), 
                new(100, false, new DCommon(750, 20)), 

                new(250, false, new DCrusader(950, 1f), new DCrusader(550, 1f)
                              , new DCrusader(950, 2f), new DCrusader(550, 2f)
                              , new DCrusader(950, 3f), new DCrusader(550, 3f)
                              , new DCrusader(950, 4f), new DCrusader(550, 4f)
                              , new DCrusader(950, 5f), new DCrusader(550, 5f)
                              , new DCrusader(950, 6f), new DCrusader(550, 6f)
                   ),

                new(70, false, new DSpread(950,EEnemyProjectileType.Normal, 5)),
                new(70, false, new DSpread(550,EEnemyProjectileType.Normal, 5)),
                new(70, false, new DSpread(950,EEnemyProjectileType.Normal, 5)),
                new(70, false, new DSpread(550,EEnemyProjectileType.Normal, 5)),
                new(70, false, new DSpread(950,EEnemyProjectileType.Normal, 5)),
                new(70, false, new DSpread(550,EEnemyProjectileType.Normal, 5)),
                new(70, false, new DCrusader(950, 5)),
                new(70, false, new DSpread(550,EEnemyProjectileType.Normal, 5)),
                new(280, true, new DSpread(950,EEnemyProjectileType.Normal, 5)),

                new(100, false, new DGooder(100, true, 500)
                              , new DGooder(700, true, 500)
                              , new DGooder(500, true, 500)
                              , new DGooder(900, true, 500)
                              , new DGooder(1300, true, 500)),
                
                new(30, false, new DCommon(300, 5), new DCommon(400, 5), new DCommon(500, 5), new DCommon(1100, 5), new DCommon(1000, 5), new DCommon(900, 5)),
                new(30, false, new DCommon(300, 5), new DCommon(400, 5), new DCommon(500, 5), new DCommon(1100, 5), new DCommon(1000, 5), new DCommon(900, 5)),
                new(30, false, new DCommon(300, 5), new DCommon(400, 5), new DCommon(500, 5), new DCommon(1100, 5), new DCommon(1000, 5), new DCommon(900, 5), new DCommon(600, 5), new DCommon(700, 5), new DCommon(800, 5)),
                new(30, false, new DCommon(300, 5), new DCommon(400, 5), new DCommon(500, 5), new DCommon(1100, 5), new DCommon(1000, 5), new DCommon(900, 5), new DSpread(600, EEnemyProjectileType.Light, 5), new DSpread(700, EEnemyProjectileType.Light, 5), new DSpread(800, EEnemyProjectileType.Light, 5)),
                new(30, false, new DCommon(300, 5), new DCommon(400, 5), new DCommon(500, 5), new DCommon(1100, 5), new DCommon(1000, 5), new DCommon(900, 5), new DCommon(600, 5), new DCommon(700, 5), new DCommon(800, 5)),
                new(30, false, new DCommon(300, 5), new DCommon(400, 5), new DCommon(500, 5), new DCommon(1100, 5), new DCommon(1000, 5), new DCommon(900, 5)),
                new(30, false, new DCommon(300, 5), new DCommon(400, 5), new DCommon(500, 5), new DCommon(1100, 5), new DCommon(1000, 5), new DCommon(900, 5), new DSpread(600, EEnemyProjectileType.Light, 5), new DSpread(700, EEnemyProjectileType.Light, 5), new DSpread(800, EEnemyProjectileType.Light, 5)),
                new(30, true, new DCommon(300, 5), new DCommon(400, 5), new DCommon(500, 5), new DCommon(1100, 5), new DCommon(1000, 5), new DCommon(900, 5), new DCommon(600, 5), new DCommon(700, 5), new DCommon(800, 5)),

                new(30, false, new DGooder(100, false)
                             , new DGooder(200, false)
                             , new DGooder(300, false)
                             , new DGooder(400, false)
                             , new DGooder(500, false)
                             , new DGooder(600, false)
                             , new DGooder(700, false)
                             , new DGooder(800, false)
                             , new DGooder(900, false)
                             , new DGooder(1000, false)
                             , new DGooder(1100, false)
                             , new DGooder(1200, false)
                             , new DGooder(1300, false)),

                new(30, false, new DOrbiter()),
                new(30, false, new DOrbiter()),
                new(30, false, new DOrbiter()),
                new(150, false, new DOrbiter()),

                new(10, false, new DOrbiter()),
                new(10, false, new DOrbiter()),
                new(10, false, new DOrbiter()),
                new(10, false, new DOrbiter()),
                new(100, false, new DOrbiter()),

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
            };
        }        
    }
}