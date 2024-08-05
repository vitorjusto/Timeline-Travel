using System.Collections.Generic;
using Shooter.Source.Dumies.Enemies;
using Shooter.Source.Enums;
using Shooter.Source.Models.Levels;

namespace Shooter.Source.Factories.Enemies
{
    public class EnemiesLevelEight
    {
        public static List<EnemySection> GetEnemies()
        {
            return new List<EnemySection>()
            {
                new(60, false, new DShoter(100, EEnemyProjectileType.Light), new DShoter(1300, EEnemyProjectileType.Light)),
                new(60, false, new DSpreader(700, EEnemyProjectileType.Strong, 4)),
                
                new(60, false, new DSpreader(600, EEnemyProjectileType.Strong, 4)
                             , new DSpreader(800, EEnemyProjectileType.Strong, 4)
                             , new DCommon(700, 4)),

                new(60, false, new DSpreader(500, EEnemyProjectileType.Strong, 4)
                             , new DSpreader(900, EEnemyProjectileType.Strong, 4)
                             , new DCommon(700, 4)
                             , new DCommon(600, 4)
                             , new DCommon(800, 4)),

                new(60, false, new DSpreader(400, EEnemyProjectileType.Strong, 4)
                             , new DSpreader(1000, EEnemyProjectileType.Strong, 4)
                             , new DCommon(700, 4)
                             , new DCommon(500, 4)
                             , new DCommon(900, 4)
                             , new DCommon(600, 4)
                             , new DCommon(800, 4)),                                          

                new(60, false, new DSpreader(300, EEnemyProjectileType.Strong, 4)
                             , new DSpreader(1100, EEnemyProjectileType.Strong, 4)
                             , new DCommon(700, 4)
                             , new DCommon(500, 4)
                             , new DCommon(400, 4)
                             , new DCommon(1000, 4)
                             , new DCommon(900, 4)
                             , new DCommon(600, 4)
                             , new DCommon(800, 4)), 

                new(60, false, new DSpreader(200, EEnemyProjectileType.Strong, 4)
                             , new DSpreader(1200, EEnemyProjectileType.Strong, 4)
                             , new DCommon(700, 4)
                             , new DCommon(500, 4)
                             , new DCommon(400, 4)
                             , new DCommon(300, 4)
                             , new DCommon(1000, 4)
                             , new DCommon(1100, 4)
                             , new DCommon(900, 4)
                             , new DCommon(600, 4)
                             , new DCommon(800, 4)), 
                
                new(60, false, new DSpreader(100, EEnemyProjectileType.Strong, 4)
                             , new DSpreader(1300, EEnemyProjectileType.Strong, 4)
                             , new DCommon(700, 4)
                             , new DCommon(500, 4)
                             , new DCommon(400, 4)
                             , new DCommon(200, 4)
                             , new DCommon(300, 4)
                             , new DCommon(1000, 4)
                             , new DCommon(1100, 4)
                             , new DCommon(1200, 4)
                             , new DCommon(900, 4)
                             , new DCommon(600, 4)
                             , new DCommon(800, 4)), 

                new(60, true, new DCommon(100, 4)
                             , new DCommon(1200, 4)
                             , new DCommon(700, 4)
                             , new DCommon(500, 4)
                             , new DCommon(400, 4)
                             , new DCommon(200, 4)
                             , new DCommon(300, 4)
                             , new DCommon(1000, 4)
                             , new DCommon(1100, 4)
                             , new DCommon(1300, 4)
                             , new DCommon(900, 4)
                             , new DCommon(600, 4)
                             , new DCommon(800, 4)),    

                new(50, false, new DBlackHole(700, false, 4)),

                new(30, false, new DSniper(100, EEnemyProjectileType.Light), new DSniper(200, EEnemyProjectileType.Normal), new DSniper(1200, EEnemyProjectileType.Normal), new DSniper(1300, EEnemyProjectileType.Light)),
                new(30, false, new DSniper(100, EEnemyProjectileType.Light), new DSniper(200, EEnemyProjectileType.Normal), new DSniper(1200, EEnemyProjectileType.Normal), new DSniper(1300, EEnemyProjectileType.Light)),
                new(30, false, new DSniper(100, EEnemyProjectileType.Light), new DSniper(200, EEnemyProjectileType.Normal), new DSniper(1200, EEnemyProjectileType.Normal), new DSniper(1300, EEnemyProjectileType.Light)),
                new(30, false, new DSniper(100, EEnemyProjectileType.Light), new DSniper(200, EEnemyProjectileType.Normal), new DSniper(1200, EEnemyProjectileType.Normal), new DSniper(1300, EEnemyProjectileType.Light)),
                new(30, false, new DSniper(100, EEnemyProjectileType.Light), new DSniper(200, EEnemyProjectileType.Normal), new DSniper(1200, EEnemyProjectileType.Normal), new DSniper(1300, EEnemyProjectileType.Light)),
                new(30, false, new DSniper(100, EEnemyProjectileType.Light), new DSniper(200, EEnemyProjectileType.Normal), new DSniper(1200, EEnemyProjectileType.Normal), new DSniper(1300, EEnemyProjectileType.Light)),
                new(30, false, new DSniper(100, EEnemyProjectileType.Light), new DSniper(200, EEnemyProjectileType.Normal), new DSniper(1200, EEnemyProjectileType.Normal), new DSniper(1300, EEnemyProjectileType.Light)),
                new(30, false, new DSniper(100, EEnemyProjectileType.Light), new DSniper(200, EEnemyProjectileType.Normal), new DSniper(1200, EEnemyProjectileType.Normal), new DSniper(1300, EEnemyProjectileType.Light)),
                new(30, false, new DSniper(100, EEnemyProjectileType.Light), new DSniper(200, EEnemyProjectileType.Normal), new DSniper(1200, EEnemyProjectileType.Normal), new DSniper(1300, EEnemyProjectileType.Light)),
                new(30, false, new DSniper(100, EEnemyProjectileType.Light), new DSniper(200, EEnemyProjectileType.Normal), new DSniper(1200, EEnemyProjectileType.Normal), new DSniper(1300, EEnemyProjectileType.Light)),
                new(30, false, new DBlackHole(700, false, 4), new DSniper(100, EEnemyProjectileType.Light), new DSniper(200, EEnemyProjectileType.Normal), new DSniper(1200, EEnemyProjectileType.Normal), new DSniper(1300, EEnemyProjectileType.Light)),
                new(30, false, new DSniper(100, EEnemyProjectileType.Light), new DSniper(200, EEnemyProjectileType.Normal), new DSniper(1200, EEnemyProjectileType.Normal), new DSniper(1300, EEnemyProjectileType.Light)),
                new(30, false, new DSniper(100, EEnemyProjectileType.Light), new DSniper(200, EEnemyProjectileType.Normal), new DSniper(1200, EEnemyProjectileType.Normal), new DSniper(1300, EEnemyProjectileType.Light)),
                new(30, false, new DSniper(100, EEnemyProjectileType.Light), new DSniper(200, EEnemyProjectileType.Normal), new DSniper(1200, EEnemyProjectileType.Normal), new DSniper(1300, EEnemyProjectileType.Light)),
                new(30, false, new DSniper(100, EEnemyProjectileType.Light), new DSniper(200, EEnemyProjectileType.Normal), new DSniper(1200, EEnemyProjectileType.Normal), new DSniper(1300, EEnemyProjectileType.Light)),
                new(30, false, new DSniper(100, EEnemyProjectileType.Light), new DSniper(200, EEnemyProjectileType.Normal), new DSniper(1200, EEnemyProjectileType.Normal), new DSniper(1300, EEnemyProjectileType.Light)),
                new(30, false, new DSniper(100, EEnemyProjectileType.Light), new DSniper(200, EEnemyProjectileType.Normal), new DSniper(1200, EEnemyProjectileType.Normal), new DSniper(1300, EEnemyProjectileType.Light)),
                new(30, false, new DSniper(100, EEnemyProjectileType.Light), new DSniper(200, EEnemyProjectileType.Normal), new DSniper(1200, EEnemyProjectileType.Normal), new DSniper(1300, EEnemyProjectileType.Light)),
                new(30, true, new DSniper(100, EEnemyProjectileType.Light), new DSniper(200, EEnemyProjectileType.Normal), new DSniper(1200, EEnemyProjectileType.Normal), new DSniper(1300, EEnemyProjectileType.Light)),


                new(30, false, new DCrusader(900, 3)),
                new(30, false, new DCrusader(800, 3), new DBlackHole(900, false, 3), new DCrusader(1000, 3)),
                new(30, false, new DCrusader(900, 3)),

                new(30, false, new DCrusader(400, 3)),
                new(30, false, new DCrusader(300, 3), new DBlackHole(400, false, 3), new DCrusader(500, 3)),
                new(30, true, new DCrusader(400, 3)),

                new(20, false, new DCommon(600, 5), new DCommon(700, 5), new DCommon(800, 5)),
                new(20, false, new DCommon(600, 5), new DSpreader(700, EEnemyProjectileType.Normal,5), new DCommon(800, 5)),
                new(20, false, new DCommon(600, 5), new DCommon(700, 5), new DCommon(800, 5)),

                new(20, false, new DCommon(400, 5), new DCommon(500, 5), new DCommon(600, 5), new DCommon(800, 5), new DCommon(900, 5), new DCommon(1000, 5)),
                new(20, false, new DCommon(400, 5), new DSpreader(500, EEnemyProjectileType.Normal,5), new DCommon(600, 5), new DCommon(800, 5), new DSpreader(900, EEnemyProjectileType.Normal,5), new DCommon(1000, 5)),
                new(20, false, new DCommon(400, 5), new DSpreader(500, EEnemyProjectileType.Normal,5), new DCommon(600, 5), new DCommon(800, 5), new DSpreader(900, EEnemyProjectileType.Normal,5), new DCommon(1000, 5)),
                new(20, false, new DCommon(400, 5), new DCommon(500, 5), new DCommon(600, 5), new DCommon(800, 5), new DCommon(900, 5), new DCommon(1000, 5)),

                new(20, false, new DCommon(200, 5), new DCommon(300, 5), new DCommon(400, 5), new DCommon(1000, 5), new DCommon(1100, 5), new DCommon(1200, 5)),
                new(20, false, new DCommon(200, 5), new DSpreader(300, EEnemyProjectileType.Normal,5), new DCommon(400, 5), new DCommon(1000, 5), new DSpreader(1100, EEnemyProjectileType.Normal,5), new DCommon(1200, 5)),
                new(20, false, new DCommon(200, 5), new DSpreader(300, EEnemyProjectileType.Normal,5), new DCommon(400, 5), new DCommon(1000, 5), new DSpreader(1100, EEnemyProjectileType.Normal,5), new DCommon(1200, 5)),
                new(20, true, new DCommon(200, 5), new DCommon(300, 5), new DCommon(400, 5), new DCommon(1000, 5), new DCommon(1100, 5), new DCommon(1200, 5)),

                new(100, false, new DLazer(700, 150)),
                new(100, false, new DLazer(600, 1400), new DLazer(500, 1400), new DLazer(800, 1400), new DLazer(900, 1400)),

                new(60, false, new DBlackHole(700, false, 3)),
                new(60, false, new DBlackHole(700, false, 3)),
                new(60, false, new DBlackHole(700, false, 3)),
                new(60, false, new DBlackHole(700, false, 3)),
                new(60, false, new DBlackHole(700, false, 3)),
                new(150, false, new DBlackHole(700, false, 3)),

                new(200, false, new DShoter(300, EEnemyProjectileType.Normal), new DShoter(1200, EEnemyProjectileType.Normal), new DBlackHole(700, false, 3)),
                new(150, false, new DBlackHole(700, false, 3)),
                new(70, false, new DBlackHole(700, false, 3), new DSniper(100, EEnemyProjectileType.Strong), new DSniper(1300, EEnemyProjectileType.Strong)),
                new(70, false, new DBlackHole(700, false, 3), new DSniper(100, EEnemyProjectileType.Strong), new DSniper(1300, EEnemyProjectileType.Strong)),
                new(70, true, new DBlackHole(700, false, 3), new DSniper(100, EEnemyProjectileType.Strong), new DSniper(1300, EEnemyProjectileType.Strong)),

                new(200, false, new DBlackHole(700, false, 4)),
                new(10, false, new DFollower(10, EEnemyProjectileType.Light)),
                new(10, false, new DFollower(10, EEnemyProjectileType.Light)),
                new(10, false, new DFollower(10, EEnemyProjectileType.Light)),

                new(200, false, new DBlackHole(400, false, 4), new DBlackHole(1000, false, 4)),
                new(10, false, new DFollower(1390, EEnemyProjectileType.Light)),
                new(10, false, new DFollower(1390, EEnemyProjectileType.Light)),
                new(10, false, new DFollower(1390, EEnemyProjectileType.Light)),

                new(200, false, new DBlackHole(700, false, 4), new DBlackHole(100, false, 4), new DBlackHole(1300, false, 4)),
                new(10, false, new DFollower(10, EEnemyProjectileType.Light)),
                new(10, false, new DFollower(10, EEnemyProjectileType.Light)),
                new(10, false, new DFollower(10, EEnemyProjectileType.Light)),

                new(200, false, new DBlackHole(400, false, 4), new DBlackHole(1000, false, 4), new DBlackHole(100, false, 4), new DBlackHole(1300, false, 4)),
                new(10, false, new DFollower(1390, EEnemyProjectileType.Light)),
                new(10, false, new DFollower(1390, EEnemyProjectileType.Light)),
                new(10, true, new DFollower(1390, EEnemyProjectileType.Light)),

                new(40, false, new DCommon(700, 3)),
                new(40, false, new DCommon(700, 3), new DCommon(600, 3), new DCommon(800, 3)),
                new(40, false, new DCommon(700, 3), new DCommon(600, 3), new DCommon(800, 3), new DCommon(500, 3), new DCommon(900, 3)),
                new(40, false, new DSpread(700, EEnemyProjectileType.Normal ,3), new DCommon(600, 3), new DCommon(800, 3), new DCommon(500, 3), new DCommon(900, 3), new DCommon(400, 3), new DCommon(1000, 3)),
                new(40, false, new DBlackHole(700, false, 3), new DSpread(600, EEnemyProjectileType.Normal ,3), new DSpread(800, EEnemyProjectileType.Normal ,3), new DCommon(500, 3), new DCommon(900, 3), new DCommon(400, 3), new DCommon(1000, 3), new DCommon(300, 3), new DCommon(1100, 3)),
                new(40, false, new DSpread(700, EEnemyProjectileType.Normal ,3), new DCommon(600, 3), new DCommon(800, 3), new DCommon(500, 3), new DCommon(900, 3), new DCommon(400, 3), new DCommon(1000, 3)),
                new(40, false, new DCommon(700, 3), new DCommon(600, 3), new DCommon(800, 3), new DCommon(500, 3), new DCommon(900, 3)),
                new(40, false, new DCommon(700, 3), new DCommon(600, 3), new DCommon(800, 3)),
                new(40, true, new DCommon(700, 3)),


                new(40, false, new DBlackHole(700, true, 4)),
                new(40, false, new DSpread(1300, EEnemyProjectileType.Normal, 4)),
                new(40, false, new DSpread(100, EEnemyProjectileType.Normal, 4)),

                new(40, false, new DSpread(1300, EEnemyProjectileType.Normal, 4)),
                new(40, false, new DSpread(1300, EEnemyProjectileType.Normal, 4), new DSpread(1200, EEnemyProjectileType.Normal, 4)),
                new(40, false, new DSpread(1300, EEnemyProjectileType.Normal, 4)),

                new(40, false, new DBlackHole(700, true, 4)),
                new(40, false, new DSpread(100, EEnemyProjectileType.Normal, 4)),
                new(40, false, new DSpread(100, EEnemyProjectileType.Normal, 4), new DSpread(200, EEnemyProjectileType.Normal, 4)),
                new(40, true, new DSpread(100, EEnemyProjectileType.Normal, 4)),    

                new(100, false, new DBlackHole(700, true, 4)),   
                new(100, false, new DBlackHole(700, true, 4)),   
                new(100, false, new DBlackHole(700, true, 4), new DShoter(700, EEnemyProjectileType.Normal)),   
                new(100, false, new DBlackHole(700, true, 4)),   
                new(100, false, new DBlackHole(700, true, 4)),   
                new(100, false, new DBlackHole(700, true, 4)),   
                new(100, false, new DBlackHole(700, true, 4)),   
                new(100, false, new DBlackHole(700, true, 4)),   
                new(100, true, new DBlackHole(700, true, 4)), 

                new(60, false, new DLazer(50, 1000), new DLazer(150, 1000), new DLazer(1250, 1000), new DLazer(1350, 1000)),
                new(80, false, new DCommon(300, 3), new DCommon(400, 3), new DCommon(500, 3), new DCommon(600, 3), new DCommon(700, 3), new DCommon(800, 3), new DCommon(900, 3), new DCommon(1000, 3), new DCommon(1100, 3)),
                new(80, false, new DCommon(300, 3), new DCommon(400, 3), new DCommon(500, 3), new DCommon(600, 3), new DCommon(700, 3), new DCommon(800, 3), new DCommon(900, 3), new DCommon(1000, 3), new DCommon(1100, 3)),
                new(80, false, new DCommon(300, 3), new DCommon(400, 3), new DCommon(500, 3), new DCommon(600, 3), new DCommon(700, 3), new DCommon(800, 3), new DCommon(900, 3), new DCommon(1000, 3), new DCommon(1100, 3)),
                new(80, false, new DCommon(300, 3), new DCommon(400, 3), new DCommon(500, 3), new DCommon(600, 3), new DCommon(700, 3), new DCommon(800, 3), new DCommon(900, 3), new DCommon(1000, 3), new DCommon(1100, 3)),
                new(80, false, new DCommon(300, 3), new DCommon(400, 3), new DCommon(500, 3), new DCommon(600, 3), new DCommon(700, 3), new DCommon(800, 3), new DCommon(900, 3), new DCommon(1000, 3), new DCommon(1100, 3)),
                new(140, false, new DCommon(300, 3), new DCommon(400, 3), new DCommon(500, 3), new DCommon(600, 3), new DCommon(700, 3), new DCommon(800, 3), new DCommon(900, 3), new DCommon(1000, 3), new DCommon(1100, 3)),

                new(100, false, new DBlackHole(700, true, 3)),   
                new(100, true, new DBlackHole(700, true, 3)),   

            };
        }
    }
}