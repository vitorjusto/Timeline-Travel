using System.Collections.Generic;
using Shooter.Source.Dumies.Enemies;
using Shooter.Source.Enums;
using Shooter.Source.Models.Levels;

namespace Shooter.Source.Factories.Enemies
{
    public class EnemiesLevelTen
    {
        public static List<EnemySection> GetEnemies()
        {
            return new List<EnemySection>()
            {
                new EnemySection(50, false, new DCommon(100, 2)
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
                                          , new DCommon(1300, 2)
                ),

                new EnemySection(50, false, new DCommon(100, 2)
                                          , new DSpread(200, EEnemyProjectileType.Normal, 2)
                                          , new DCommon(300, 2)
                                          , new DSpread(400, EEnemyProjectileType.Normal, 2)
                                          , new DCommon(500, 2)
                                          , new DSpread(600, EEnemyProjectileType.Normal, 2)
                                          , new DCommon(700, 2)
                                          , new DSpread(800, EEnemyProjectileType.Normal, 2)
                                          , new DCommon(900, 2)
                                          , new DSpread(1000, EEnemyProjectileType.Normal, 2)
                                          , new DCommon(1100, 2)
                                          , new DSpread(1200, EEnemyProjectileType.Normal, 2)
                                          , new DCommon(1300, 2)
                ),

                new EnemySection(50, false, new DCommon(100, 2)
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
                                          , new DCommon(1300, 2)
                ),

                new EnemySection(50, false, new DCommon(100, 2)
                                          , new DCommon(200, 2)
                                          , new DCommon(300, 2)
                ),

                new EnemySection(50, false, new DCommon(100, 2)
                                          , new DSpread(200, EEnemyProjectileType.Normal, 2)
                                          , new DCommon(300, 2)
                ),

                new EnemySection(50, false, new DCommon(100, 2)
                                          , new DCommon(200, 2)
                                          , new DCommon(300, 2)
                ),

                new EnemySection(50, false, new DCommon(100, 2)
                                          , new DSpread(200, EEnemyProjectileType.Normal, 2)
                                          , new DCommon(300, 2)
                ),

                new EnemySection(50, false, new DCommon(100, 2)
                                          , new DCommon(200, 2)
                                          , new DCommon(300, 2)
                ),

                new EnemySection(50, false, new DCommon(100, 2)
                                          , new DSpread(200, EEnemyProjectileType.Normal, 2)
                                          , new DCommon(300, 2)
                ),

                new EnemySection(50, false, new DCommon(100, 2)
                                          , new DCommon(200, 2)
                                          , new DCommon(300, 2)
                ),

                new EnemySection(50, false, new DCommon(100, 2)
                                          , new DSpread(200, EEnemyProjectileType.Normal, 2)
                                          , new DCommon(300, 2)
                ),

                new EnemySection(50, false, new DCommon(100, 2)
                                          , new DCommon(200, 2)
                                          , new DCommon(300, 2)
                ),

                new EnemySection(50, false, new DCommon(100, 2)
                                          , new DSpread(200, EEnemyProjectileType.Normal, 2)
                                          , new DCommon(300, 2)
                ),

                new EnemySection(50, false, new DCommon(100, 2)
                                          , new DCommon(200, 2)
                                          , new DCommon(300, 2)
                ),

                new EnemySection(50, false, new DCommon(100, 2)
                                          , new DSpread(200, EEnemyProjectileType.Normal, 2)
                                          , new DCommon(300, 2)
                ),

                new EnemySection(50, true, new DCommon(100, 2)
                                          , new DCommon(200, 2)
                                          , new DCommon(300, 2)
                ),

                //**Level 5**//

                new(30, false, new DReinforcedCommon(700, 4), new DCommon(800, 4), new DReinforcedCommon(900, 4)),
                new(30, false, new DCommon(700, 4), new DSpread(800, EEnemyProjectileType.Normal, 4), new DCommon(900, 4)),
                new(60, false, new DReinforcedCommon(700, 4), new DCommon(800, 4), new DReinforcedCommon(900, 4)),

                new(30, false, new DReinforcedCommon(100, 4), new DCommon(200, 4), new DReinforcedCommon(300, 4)),
                new(30, false, new DCommon(100, 4), new DSpread(200, EEnemyProjectileType.Normal, 4), new DCommon(300, 4)),
                new(60, false, new DReinforcedCommon(100, 4), new DCommon(200, 4), new DReinforcedCommon(300, 4)),

                new(30, false, new DReinforcedCommon(200, 4), new DCommon(300, 4), new DReinforcedCommon(400, 4)),
                new(30, false, new DCommon(200, 4), new DSpread(300, EEnemyProjectileType.Normal, 4), new DCommon(400, 4)),
                new(60, false, new DReinforcedCommon(200, 4), new DCommon(300, 4), new DReinforcedCommon(400, 4)),

                new(30, false, new DReinforcedCommon(400, 4), new DCommon(500, 4), new DReinforcedCommon(600, 4)),
                new(30, false, new DCommon(400, 4), new DSpread(500, EEnemyProjectileType.Normal, 4), new DCommon(600, 4)),
                new(60, false, new DReinforcedCommon(400, 4), new DCommon(500, 4), new DReinforcedCommon(600, 4)),

                new(30, false, new DReinforcedCommon(600, 4), new DCommon(700, 4), new DReinforcedCommon(800, 4)),
                new(30, false, new DCommon(600, 4), new DSpread(700, EEnemyProjectileType.Normal, 4), new DCommon(800, 4)),
                new(60, false, new DReinforcedCommon(600, 4), new DCommon(700, 4), new DReinforcedCommon(800, 4)),

                new(30, false, new DReinforcedCommon(900, 4), new DCommon(1000, 4), new DReinforcedCommon(1100, 4)),
                new(30, false, new DCommon(900, 4), new DSpread(1000, EEnemyProjectileType.Normal, 4), new DCommon(1100, 4)),
                new(60, false, new DReinforcedCommon(900, 4), new DCommon(1000, 4), new DReinforcedCommon(1100, 4)),

                ////**Level 6//

                new(100, false, new DLighting(50)
                             , new DLighting(150)
                             , new DLighting(250)
                             , new DLighting(350)
                             , new DLighting(450)
                             , new DLighting(550)
                             , new DLighting(850)
                             , new DLighting(950)
                             , new DLighting(1050)
                             , new DLighting(1150)
                             , new DLighting(1250)
                             , new DLighting(1350)
                ),

                new(30, false, new DLazer(650, 650), new DLazer(750, 650)),

                new(100, false, new DLighting(50)
                             , new DLighting(150)
                             , new DLighting(450)
                             , new DLighting(550)
                             , new DLighting(850)
                             , new DLighting(950)
                             , new DLighting(1250)
                             , new DLighting(1350)
                ),

                new(30, false, new DLazer(250, 1400), new DLazer(350, 1400), new DLazer(1050,1400), new DLazer(1150, 1400)),

                new(50, false, new DCrusader(150, 3)
                             , new DCrusader(550, 3)
                             , new DCrusader(950, 3)
                             , new DCrusader(1350, 3)
                ),

                new(60, false, new DLighting(50)
                             , new DLighting(450)
                             , new DLighting(850)
                             , new DLighting(1250)
                ),

                new(60, false, new DLighting(150)
                             , new DLighting(550)
                             , new DLighting(950)
                             , new DLighting(1350)
                ),

                new(60, false, new DLighting(50)
                             , new DLighting(450)
                             , new DLighting(850)
                             , new DLighting(1250)
                ),

                new(70, false, new DLighting(150)
                             , new DLighting(550)
                             , new DLighting(950)
                             , new DLighting(1350)
                ),

                new(70, false, new DCrusader(50, 4)
                             , new DCrusader(450, 4)
                             , new DCrusader(850, 4)
                             , new DCrusader(1250, 4)
                             , new DCrusader(150, 4)
                             , new DCrusader(550, 4)
                             , new DCrusader(950, 4)
                             , new DCrusader(1350, 4)
                ),

                ////**Level 9//
                
                new(40, false, new DReinforcedCommon(450, 4), new DReinforcedCommon(950, 4)),
                new(40, false, new DReinforcedCommon(450, 4), new DReinforcedCommon(950, 4), new DShoter(1350, EEnemyProjectileType.Normal), new DShoter(50, EEnemyProjectileType.Normal)),
                new(40, false, new DReinforcedCommon(450, 4), new DReinforcedCommon(950, 4)),
                new(40, false, new DReinforcedCommon(450, 4), new DReinforcedCommon(950, 4), new DReinforcedCommon(550, 4), new DReinforcedCommon(850, 4), new DReinforcedCommon(50, 4), new DReinforcedCommon(1350, 4)),
                new(40, false, new DReinforcedCommon(450, 4), new DReinforcedCommon(950, 4), new DReinforcedCommon(550, 4), new DReinforcedCommon(850, 4), new DReinforcedCommon(50, 4), new DReinforcedCommon(1350, 4)),
                new(40, false, new DReinforcedCommon(450, 4), new DReinforcedCommon(950, 4), new DReinforcedCommon(550, 4), new DReinforcedCommon(850, 4)),
                new(40, false, new DReinforcedCommon(450, 4), new DReinforcedCommon(950, 4), new DReinforcedCommon(550, 4), new DReinforcedCommon(850, 4), new DCrusader(1350, 3)),
                new(40, false, new DReinforcedCommon(450, 4), new DReinforcedCommon(950, 4), new DReinforcedCommon(550, 4), new DReinforcedCommon(850, 4), new DReinforcedCommon(150, 4), new DReinforcedCommon(1250, 4)),
                new(40, false, new DReinforcedCommon(450, 4), new DReinforcedCommon(950, 4), new DReinforcedCommon(550, 4), new DReinforcedCommon(850, 4), new DReinforcedCommon(150, 4), new DReinforcedCommon(1250, 4)),
                new(40, false, new DReinforcedCommon(450, 4), new DReinforcedCommon(950, 4), new DReinforcedCommon(550, 4), new DReinforcedCommon(850, 4)),
                new(40, false, new DReinforcedCommon(450, 4), new DReinforcedCommon(950, 4), new DReinforcedCommon(550, 4), new DReinforcedCommon(850, 4), new DCrusader(50, 5)),
                new(40, false, new DReinforcedCommon(450, 4), new DReinforcedCommon(950, 4), new DReinforcedCommon(550, 4), new DReinforcedCommon(850, 4), new DReinforcedCommon(50, 4), new DReinforcedCommon(1350, 4)),
                new(40, false, new DReinforcedCommon(450, 4), new DReinforcedCommon(950, 4), new DReinforcedCommon(550, 4), new DReinforcedCommon(850, 4), new DReinforcedCommon(50, 4), new DReinforcedCommon(1350, 4)),
                new(40, false, new DReinforcedCommon(450, 4), new DReinforcedCommon(950, 4), new DReinforcedCommon(550, 4), new DReinforcedCommon(850, 4)),
                new(40, false, new DReinforcedCommon(450, 4), new DReinforcedCommon(950, 4), new DReinforcedCommon(550, 4), new DReinforcedCommon(850, 4)),
                new(40, false, new DReinforcedCommon(450, 4), new DReinforcedCommon(950, 4), new DReinforcedCommon(550, 4), new DReinforcedCommon(850, 4), new DReinforcedCommon(150, 4), new DReinforcedCommon(1250, 4)),
                new(40, false, new DReinforcedCommon(450, 4), new DReinforcedCommon(950, 4), new DReinforcedCommon(550, 4), new DReinforcedCommon(850, 4), new DReinforcedCommon(150, 4), new DReinforcedCommon(1250, 4)),
                new(40, false, new DReinforcedCommon(450, 4), new DReinforcedCommon(950, 4), new DReinforcedCommon(550, 4), new DReinforcedCommon(850, 4)),
                new(40, false, new DReinforcedCommon(450, 4), new DReinforcedCommon(950, 4), new DReinforcedCommon(550, 4), new DReinforcedCommon(850, 4), new DCrusader(1250, 3), new DCrusader(150, 5)),
                new(40, false, new DReinforcedCommon(450, 4), new DReinforcedCommon(950, 4), new DReinforcedCommon(550, 4), new DReinforcedCommon(850, 4), new DReinforcedCommon(50, 4), new DReinforcedCommon(1350, 4)),
                new(120, false, new DReinforcedCommon(450, 4), new DReinforcedCommon(950, 4), new DReinforcedCommon(550, 4), new DReinforcedCommon(850, 4), new DReinforcedCommon(50, 4), new DReinforcedCommon(1350, 4)),

                new(40, false, new DReinforcedCommon(450, 4), new DReinforcedCommon(650, 4), new DReinforcedCommon(750, 4), new DReinforcedCommon(950, 4), new DReinforcedCommon(550, 4), new DReinforcedCommon(850, 4), new DReinforcedCommon(150, 4), new DReinforcedCommon(50, 4), new DReinforcedCommon(1350, 4), new DReinforcedCommon(1250, 4)),
                new(40, false, new DReinforcedCommon(450, 4), new DReinforcedCommon(650, 4), new DReinforcedCommon(750, 4), new DReinforcedCommon(950, 4), new DReinforcedCommon(550, 4), new DReinforcedCommon(850, 4), new DReinforcedCommon(150, 4), new DReinforcedCommon(50, 4), new DReinforcedCommon(1350, 4), new DReinforcedCommon(1250, 4)),
                new(40, false, new DReinforcedCommon(450, 4), new DSpread(650, EEnemyProjectileType.Light, 4), new DReinforcedCommon(750, 4), new DReinforcedCommon(950, 4), new DReinforcedCommon(550, 4), new DReinforcedCommon(850, 4), new DReinforcedCommon(150, 4), new DReinforcedCommon(50, 4), new DReinforcedCommon(1350, 4), new DReinforcedCommon(1250, 4)),
                new(40, false, new DReinforcedCommon(450, 4), new DReinforcedCommon(650, 4), new DReinforcedCommon(750, 4), new DReinforcedCommon(950, 4), new DReinforcedCommon(550, 4), new DReinforcedCommon(850, 4), new DReinforcedCommon(150, 4), new DReinforcedCommon(50, 4), new DReinforcedCommon(1350, 4), new DReinforcedCommon(1250, 4)),
                new(40, false, new DReinforcedCommon(450, 4), new DReinforcedCommon(650, 4), new DReinforcedCommon(750, 4), new DReinforcedCommon(950, 4), new DReinforcedCommon(550, 4), new DReinforcedCommon(850, 4), new DReinforcedCommon(150, 4), new DReinforcedCommon(50, 4), new DReinforcedCommon(1350, 4), new DReinforcedCommon(1250, 4)),
                new(40, false, new DReinforcedCommon(450, 4), new DReinforcedCommon(650, 4), new DReinforcedCommon(750, 4), new DSpread(950, EEnemyProjectileType.Light, 4), new DReinforcedCommon(550, 4), new DReinforcedCommon(850, 4), new DReinforcedCommon(150, 4), new DReinforcedCommon(50, 4), new DReinforcedCommon(1350, 4), new DReinforcedCommon(1250, 4)),
                new(40, false, new DReinforcedCommon(450, 4), new DReinforcedCommon(650, 4), new DReinforcedCommon(750, 4), new DReinforcedCommon(950, 4), new DReinforcedCommon(550, 4), new DReinforcedCommon(850, 4), new DReinforcedCommon(150, 4), new DReinforcedCommon(50, 4), new DReinforcedCommon(1350, 4), new DReinforcedCommon(1250, 4)),
                new(40, false, new DReinforcedCommon(450, 4), new DReinforcedCommon(650, 4), new DSpread(750, EEnemyProjectileType.Strong, 4), new DReinforcedCommon(950, 4), new DReinforcedCommon(550, 4), new DReinforcedCommon(850, 4), new DReinforcedCommon(150, 4), new DReinforcedCommon(50, 4), new DReinforcedCommon(1350, 4), new DReinforcedCommon(1250, 4)),
                new(40, true, new DReinforcedCommon(450, 4), new DReinforcedCommon(650, 4), new DReinforcedCommon(750, 4), new DReinforcedCommon(950, 4), new DReinforcedCommon(550, 4), new DReinforcedCommon(850, 4), new DReinforcedCommon(150, 4), new DReinforcedCommon(50, 4), new DReinforcedCommon(1350, 4), new DReinforcedCommon(1250, 4)),

                ////**Level 7//
                
                new(60, false, new DGooder(100, true, 1500)) { CheckpointId = 1 },
                new(40, false, new DCommon(100, 4)
                             , new DCommon(200, 4)
                             , new DCommon(300, 4)
                             , new DCommon(400, 4)
                             , new DCommon(500, 4)
                             , new DCommon(600, 4)
                             , new DCommon(700, 4)
                             , new DCommon(800, 4)
                             , new DCommon(900, 4)
                             , new DCommon(1000, 4)
                             , new DCommon(1100, 4)
                             , new DCommon(1200, 4)
                             , new DCommon(1300, 4)),
                
                new(40, false, new DCommon(100, 4), new DGooder(200, true, 1500)
                             , new DCommon(200, 4)
                             , new DSpread(300, EEnemyProjectileType.Normal, 4)
                             , new DCommon(400, 4)
                             , new DCommon(500, 4)
                             , new DCommon(600, 4)
                             , new DCommon(700, 4)
                             , new DCommon(800, 4)
                             , new DCommon(900, 4)
                             , new DCommon(1000, 4)
                             , new DSpread(1100, EEnemyProjectileType.Normal, 4)
                             , new DCommon(1200, 4)
                             , new DCommon(1300, 4)),

                new(40, false, new DCommon(100, 4), new DGooder(300, true, 1500)
                             , new DCommon(200, 4)
                             , new DCommon(300, 4)
                             , new DCommon(400, 4)
                             , new DCommon(500, 4)
                             , new DCommon(600, 4)
                             , new DCommon(700, 4)
                             , new DCommon(800, 4)
                             , new DCommon(900, 4)
                             , new DCommon(1000, 4)
                             , new DCommon(1100, 4)
                             , new DCommon(1200, 4)
                             , new DCommon(1300, 4)),

                new(40, false, new DCommon(100, 4)
                             , new DCommon(200, 4)
                             , new DCommon(300, 4)
                             , new DCommon(400, 4)
                             , new DCommon(500, 4)
                             , new DCommon(600, 4)
                             , new DSpread(700, EEnemyProjectileType.Normal, 4)
                             , new DCommon(800, 4)
                             , new DCommon(900, 4)
                             , new DCommon(1000, 4)
                             , new DCommon(1100, 4)
                             , new DCommon(1200, 4)
                             , new DCommon(1300, 4)),

                new(200, false, new DCommon(100, 4)
                             , new DCommon(200, 4)
                             , new DCommon(300, 4)
                             , new DCommon(400, 4)
                             , new DCommon(500, 4)
                             , new DCommon(600, 4)
                             , new DCommon(700, 4)
                             , new DCommon(800, 4)
                             , new DCommon(900, 4)
                             , new DCommon(1000, 4)
                             , new DCommon(1100, 4)
                             , new DCommon(1200, 4)
                             , new DCommon(1300, 4)),

                //**Level 2 & 6
                new(20, false, new DStomper(100), new DStomper(1300)),
                new(20, false, new DStomper(100), new DStomper(1300)),
                new(20, false, new DStomper(100), new DStomper(1300)),
                new(20, false, new DStomper(100), new DStomper(1300)),
                new(20, false, new DStomper(100), new DStomper(1300), new DSniper(700, EEnemyProjectileType.Homing)),
                new(20, false, new DStomper(100), new DStomper(1300)),
                new(20, false, new DStomper(100), new DStomper(1300)),
                new(20, false, new DStomper(100), new DStomper(1300)),
                new(20, false, new DStomper(100), new DStomper(1300)),
                new(20, false, new DStomper(100), new DStomper(1300)),
                new(20, false, new DStomper(100), new DStomper(1300)),
                new(20, false, new DStomper(100), new DStomper(1300)),
                new(20, false, new DStomper(100), new DStomper(1300)),
                new(20, false, new DStomper(100), new DStomper(1300)),
                new(20, false, new DStomper(100), new DStomper(1300)),
                new(20, false, new DStomper(100), new DStomper(1300)),
                new(20, false, new DStomper(100), new DStomper(1300)),
                new(20, false, new DStomper(100), new DStomper(1300)),
                new(20, false, new DStomper(100), new DStomper(1300)),
                new(80, false, new DStomper(100), new DStomper(1300)),

                new(30, false, new DFollower(100, EEnemyProjectileType.Light), new DFollower(1300, EEnemyProjectileType.Light)),
                new(30, false, new DFollower(100, EEnemyProjectileType.Light), new DFollower(1300, EEnemyProjectileType.Light)),
                new(30, true, new DFollower(100, EEnemyProjectileType.Light), new DFollower(1300, EEnemyProjectileType.Light)),

                //**Level 2
                                
                new(20, false, new DReinforcedCommon(188, 5), new DReinforcedCommon(841, 9), new DReinforcedCommon(117, 9), new DReinforcedCommon(1010, 10), new DReinforcedCommon(206, 8)),
                new(20, false, new DReinforcedCommon(420, 10), new DReinforcedCommon(514, 7), new DReinforcedCommon(931, 8), new DReinforcedCommon(1110, 9), new DReinforcedCommon(260, 5)),
                new(20, false, new DReinforcedCommon(558, 10), new DReinforcedCommon(1243, 7), new DReinforcedCommon(835, 9), new DReinforcedCommon(758, 5), new DReinforcedCommon(1035, 6)),
                new(20, false, new DReinforcedCommon(1337, 7), new DReinforcedCommon(1062, 9), new DReinforcedCommon(952, 8), new DReinforcedCommon(388, 5), new DReinforcedCommon(890, 6)),
                new(20, false, new DReinforcedCommon(86, 9), new DReinforcedCommon(1279, 10), new DReinforcedCommon(580, 9), new DReinforcedCommon(187, 8), new DReinforcedCommon(560, 7)),
                new(20, false, new DReinforcedCommon(1064, 6), new DReinforcedCommon(90, 8), new DReinforcedCommon(625, 10), new DReinforcedCommon(185, 5), new DReinforcedCommon(278, 6)),
                new(20, false, new DReinforcedCommon(1143, 9), new DReinforcedCommon(1323, 7), new DReinforcedCommon(281, 5), new DReinforcedCommon(565, 10), new DReinforcedCommon(137, 8)),
                new(20, false, new DReinforcedCommon(341, 10), new DReinforcedCommon(1156, 5), new DReinforcedCommon(811, 7), new DReinforcedCommon(1214, 9), new DReinforcedCommon(313, 6)),
                new(20, false, new DReinforcedCommon(752, 8), new DReinforcedCommon(354, 6), new DReinforcedCommon(1033, 9), new DReinforcedCommon(430, 7), new DReinforcedCommon(1067, 5)),
                new(20, false, new DReinforcedCommon(322, 6), new DReinforcedCommon(747, 9), new DReinforcedCommon(1127, 6), new DReinforcedCommon(1182, 8), new DReinforcedCommon(701, 10)),
                new(20, false, new DReinforcedCommon(893, 9), new DReinforcedCommon(744, 7), new DReinforcedCommon(621, 5), new DReinforcedCommon(1347, 10), new DReinforcedCommon(714, 9)),
                new(20, false, new DReinforcedCommon(368, 7), new DReinforcedCommon(1166, 8), new DReinforcedCommon(902, 10), new DReinforcedCommon(1308, 5), new DReinforcedCommon(944, 7)),
                new(20, false, new DReinforcedCommon(69, 5), new DReinforcedCommon(943, 6), new DReinforcedCommon(1204, 9), new DReinforcedCommon(458, 7), new DReinforcedCommon(351, 5)),
                new(20, false, new DReinforcedCommon(214, 10), new DReinforcedCommon(969, 9), new DReinforcedCommon(886, 6), new DReinforcedCommon(916, 8), new DReinforcedCommon(606, 10)),
                new(20, false, new DReinforcedCommon(579, 8), new DReinforcedCommon(84, 7), new DReinforcedCommon(906, 5), new DReinforcedCommon(345, 10), new DReinforcedCommon(795, 8)),
                new(20, false, new DReinforcedCommon(182, 6), new DReinforcedCommon(1175, 5), new DReinforcedCommon(673, 7), new DReinforcedCommon(888, 9), new DReinforcedCommon(955, 6)),
                new(20, false, new DReinforcedCommon(1266, 9), new DReinforcedCommon(481, 10), new DReinforcedCommon(1017, 8), new DReinforcedCommon(206, 6), new DReinforcedCommon(811, 9)),
                new(20, false, new DReinforcedCommon(130, 7), new DReinforcedCommon(1107, 8), new DReinforcedCommon(423, 10), new DReinforcedCommon(355, 5), new DReinforcedCommon(858, 7)),
                new(20, false, new DReinforcedCommon(529, 5), new DReinforcedCommon(80, 6), new DReinforcedCommon(421, 9), new DReinforcedCommon(1303, 7), new DReinforcedCommon(539, 5)),
                new(20, false, new DReinforcedCommon(752, 10), new DReinforcedCommon(697, 9), new DReinforcedCommon(1114, 6), new DReinforcedCommon(630, 8), new DReinforcedCommon(462, 10)),
                new(20, false, new DReinforcedCommon(515, 8), new DReinforcedCommon(607, 7), new DReinforcedCommon(1313, 5), new DReinforcedCommon(793, 10), new DReinforcedCommon(696, 8)),
                new(20, false, new DReinforcedCommon(303, 6), new DReinforcedCommon(111, 5), new DReinforcedCommon(1306, 7), new DReinforcedCommon(1070, 9), new DReinforcedCommon(294, 6)),
                new(20, false, new DReinforcedCommon(1060, 9), new DReinforcedCommon(575, 10), new DReinforcedCommon(231, 8), new DReinforcedCommon(785, 6), new DReinforcedCommon(1256, 9)),
                new(20, false, new DReinforcedCommon(1116, 7), new DReinforcedCommon(632, 8), new DReinforcedCommon(752, 10), new DReinforcedCommon(1090, 5), new DReinforcedCommon(954, 7)),
                new(20, false, new DReinforcedCommon(309, 5), new DReinforcedCommon(630, 6), new DReinforcedCommon(1289, 9), new DReinforcedCommon(270, 7), new DReinforcedCommon(883, 5)),
                new(20, false, new DReinforcedCommon(702, 10), new DReinforcedCommon(153, 9), new DReinforcedCommon(988, 6), new DReinforcedCommon(292, 8), new DReinforcedCommon(998, 10)),
                new(20, false, new DReinforcedCommon(540, 8), new DReinforcedCommon(952, 7), new DReinforcedCommon(1098, 5), new DReinforcedCommon(202, 10), new DReinforcedCommon(1214, 8)),
                new(100, false, new DReinforcedCommon(659, 6), new DReinforcedCommon(1315, 5), new DReinforcedCommon(627, 7), new DReinforcedCommon(231, 9), new DReinforcedCommon(524, 6)),
                new(20, false, new DReinforcedCommon(1060, 9), new DReinforcedCommon(575, 10), new DReinforcedCommon(231, 8), new DReinforcedCommon(785, 6), new DReinforcedCommon(1256, 9)),
                new(20, false, new DReinforcedCommon(1116, 7), new DReinforcedCommon(632, 8), new DReinforcedCommon(752, 10), new DReinforcedCommon(1090, 5), new DReinforcedCommon(954, 7)),
                new(20, false, new DReinforcedCommon(309, 5), new DReinforcedCommon(630, 6), new DReinforcedCommon(1289, 9), new DReinforcedCommon(270, 7), new DReinforcedCommon(883, 5)),
                new(20, false, new DReinforcedCommon(702, 10), new DReinforcedCommon(153, 9), new DReinforcedCommon(988, 6), new DReinforcedCommon(292, 8), new DReinforcedCommon(998, 10)),
                new(20, false, new DReinforcedCommon(540, 8), new DReinforcedCommon(952, 7), new DReinforcedCommon(1098, 5), new DReinforcedCommon(202, 10), new DReinforcedCommon(1214, 8)),
                new(20, true, new DReinforcedCommon(659, 6), new DReinforcedCommon(1315, 5), new DReinforcedCommon(627, 7), new DReinforcedCommon(231, 9), new DReinforcedCommon(524, 6)),

                new(20, false, new DBlackHole(700, false, 3)),
                new(20, false, new DDasher(100), new DDasher(1300)),
                new(20, false, new DDasher(100), new DDasher(1300)),
                new(20, false, new DDasher(100), new DDasher(1300)),
                new(20, false, new DDasher(100), new DDasher(1300)),
                new(20, false, new DDasher(100), new DDasher(1300)),
                new(20, false, new DDasher(100), new DDasher(1300)),
                new(20, false, new DDasher(100), new DDasher(1300)),
                new(20, false, new DDasher(100), new DDasher(1300)),
                new(20, false, new DDasher(100), new DDasher(1300)),
                new(20, false, new DDasher(100), new DDasher(1300)),
                new(20, false, new DDasher(100), new DDasher(1300)),
                new(20, false, new DDasher(100), new DDasher(1300)),
                new(20, false, new DDasher(100), new DDasher(1300)),
                new(20, false, new DDasher(100), new DDasher(1300)),
                new(20, false, new DDasher(100), new DDasher(1300)),
                new(20, false, new DDasher(100), new DDasher(1300)),
                new(20, false, new DDasher(100), new DDasher(1300)),
                new(80, false, new DDasher(100), new DDasher(1300)),

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
                new(50, false,  new DCommon(100, 4)),

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
            };
        }
    }
}