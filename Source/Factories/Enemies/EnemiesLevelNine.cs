using System.Collections.Generic;
using Shooter.Source.Dumies.Enemies;
using Shooter.Source.Dumies.Interfaces;
using Shooter.Source.Enums;
using Shooter.Source.Models.Levels;

namespace Shooter.Source.Factories.Enemies
{
    public class EnemiesLevelNine
    {
        public static List<EnemySection> GetEnemies()
        {
            
            return new List<EnemySection>()
            {
                new(10, false, new DFollower(10, EEnemyProjectileType.Normal)),
            };
            return new List<EnemySection>()
            {
                new(10, false, new DFollower(10, EEnemyProjectileType.Normal)),
                new(10, false, new DFollower(10, EEnemyProjectileType.Normal)),
                new(50, false, new DFollower(10, EEnemyProjectileType.Normal)),

                new(10, false, new DFollower(1390, EEnemyProjectileType.Normal)),
                new(10, false, new DFollower(1390, EEnemyProjectileType.Normal)),
                new(50, false, new DFollower(1390, EEnemyProjectileType.Normal)),

                new(10, false, new DFollower(10, EEnemyProjectileType.Normal)),
                new(10, false, new DFollower(10, EEnemyProjectileType.Normal)),
                new(50, false, new DFollower(10, EEnemyProjectileType.Normal)),

                new(10, false, new DFollower(1390, EEnemyProjectileType.Normal)),
                new(10, false, new DFollower(1390, EEnemyProjectileType.Normal)),
                new(50, false, new DFollower(1390, EEnemyProjectileType.Normal)),

                new(40, false, new DSniper(500, EEnemyProjectileType.Normal), new DSniper(900, EEnemyProjectileType.Normal)),
                new(40, false, new DSniper(500, EEnemyProjectileType.Normal), new DSniper(900, EEnemyProjectileType.Normal)),
                new(40, false, new DSniper(500, EEnemyProjectileType.Normal), new DSniper(900, EEnemyProjectileType.Normal)),
                new(40, false, new DSniper(500, EEnemyProjectileType.Normal), new DSniper(900, EEnemyProjectileType.Normal)),
                new(40, false, new DSniper(500, EEnemyProjectileType.Normal), new DSniper(900, EEnemyProjectileType.Normal)),
                new(40, false, new DSniper(500, EEnemyProjectileType.Normal), new DSniper(900, EEnemyProjectileType.Normal)),
                new(40, false, new DSniper(500, EEnemyProjectileType.Normal), new DSniper(900, EEnemyProjectileType.Normal)),
                new(40, false, new DSniper(500, EEnemyProjectileType.Normal), new DSniper(900, EEnemyProjectileType.Normal)),
                new(40, false, new DSniper(500, EEnemyProjectileType.Normal), new DSniper(900, EEnemyProjectileType.Normal)),
                new(40, false, new DSniper(500, EEnemyProjectileType.Normal), new DSniper(900, EEnemyProjectileType.Normal)),
                new(40, false, new DSniper(500, EEnemyProjectileType.Normal), new DSniper(900, EEnemyProjectileType.Normal)),

                new(150, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(180, 3)
                             , new DReinforcedCommon(260, 3)
                             , new DReinforcedCommon(340, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),

                new(150, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(180, 3)
                             , new DReinforcedCommon(260, 3)
                             , new DReinforcedCommon(340, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),

                new(300, false
                             , new DReinforcedCommon(260, 3)
                             , new DReinforcedCommon(340, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),

                new(150, false,
                              new DCrusader(700, 3),
                              new DCrusader(600, 2.5f),
                              new DCrusader(800, 2.5f),
                              new DCrusader(600, 3.5f),
                              new DCrusader(800, 3.5f)
                              ),

                new(30, false, new DReinforcedCommon(20, 4)
                             , new DReinforcedCommon(100, 4)
                             , new DReinforcedCommon(180, 4)
                             , new DReinforcedCommon(260, 4)
                             , new DReinforcedCommon(340, 4)
                             , new DReinforcedCommon(420, 4)
                             , new DReinforcedCommon(500, 4)
                             , new DReinforcedCommon(580, 4)
                             , new DReinforcedCommon(660, 4)
                             , new DReinforcedCommon(740, 4)
                             , new DReinforcedCommon(820, 4)
                             , new DReinforcedCommon(900, 4)
                             , new DReinforcedCommon(980, 4)
                             , new DReinforcedCommon(1060, 4)
                             , new DCommon(1140, 4)
                             , new DCommon(1220, 4)
                             , new DReinforcedCommon(1300, 4)
                             , new DReinforcedCommon(1380, 4)
                ),

                new(30, false, new DReinforcedCommon(20, 4)
                             , new DReinforcedCommon(100, 4)
                             , new DReinforcedCommon(180, 4)
                             , new DReinforcedCommon(260, 4)
                             , new DReinforcedCommon(340, 4)
                             , new DReinforcedCommon(420, 4)
                             , new DReinforcedCommon(500, 4)
                             , new DReinforcedCommon(580, 4)
                             , new DReinforcedCommon(660, 4)
                             , new DReinforcedCommon(740, 4)
                             , new DReinforcedCommon(820, 4)
                             , new DReinforcedCommon(900, 4)
                             , new DReinforcedCommon(980, 4)
                             , new DReinforcedCommon(1060, 4)
                             , new DSpread(1140, EEnemyProjectileType.Light, 4)
                             , new DSpread(1220, EEnemyProjectileType.Light, 4)
                             , new DReinforcedCommon(1300, 4)
                             , new DReinforcedCommon(1380, 4)
                ),

                new(30, false, new DReinforcedCommon(20, 4)
                             , new DReinforcedCommon(100, 4)
                             , new DReinforcedCommon(180, 4)
                ),

                new(30, false, new DReinforcedCommon(20, 4)
                             , new DSpread(100, EEnemyProjectileType.Normal, 4)
                             , new DReinforcedCommon(180, 4)
                ),

                new(30, false, new DReinforcedCommon(20, 4)
                             , new DReinforcedCommon(100, 4)
                             , new DReinforcedCommon(180, 4)
                ),

                new(30, false, new DReinforcedCommon(20, 4)
                             , new DReinforcedCommon(100, 4)
                             , new DReinforcedCommon(180, 4)
                             , new DCommon(260, 4)
                             , new DCommon(340, 4)
                             , new DReinforcedCommon(420, 4)
                             , new DReinforcedCommon(500, 4)
                             , new DReinforcedCommon(580, 4)
                             , new DReinforcedCommon(660, 4)
                             , new DReinforcedCommon(740, 4)
                             , new DReinforcedCommon(820, 4)
                             , new DReinforcedCommon(900, 4)
                             , new DReinforcedCommon(980, 4)
                             , new DReinforcedCommon(1060, 4)
                             , new DReinforcedCommon(1140, 4)
                             , new DReinforcedCommon(1220, 4)
                             , new DReinforcedCommon(1300, 4)
                             , new DReinforcedCommon(1380, 4)
                ),

                new(30, false, new DReinforcedCommon(20, 4)
                             , new DReinforcedCommon(100, 4)
                             , new DReinforcedCommon(180, 4)
                             , new DSpread(260, EEnemyProjectileType.Light, 4)
                             , new DSpread(340, EEnemyProjectileType.Light, 4)
                             , new DReinforcedCommon(420, 4)
                             , new DReinforcedCommon(500, 4)
                             , new DReinforcedCommon(580, 4)
                             , new DReinforcedCommon(660, 4)
                             , new DReinforcedCommon(740, 4)
                             , new DReinforcedCommon(820, 4)
                             , new DReinforcedCommon(900, 4)
                             , new DReinforcedCommon(980, 4)
                             , new DReinforcedCommon(1060, 4)
                             , new DReinforcedCommon(1140, 4)
                             , new DReinforcedCommon(1220, 4)
                             , new DReinforcedCommon(1300, 4)
                             , new DReinforcedCommon(1380, 4)
                ),

                new(30, false, new DReinforcedCommon(20, 4)
                             , new DReinforcedCommon(100, 4)
                             , new DReinforcedCommon(180, 4)
                ),

                new(30, false, new DReinforcedCommon(20, 4)
                             , new DSpread(100, EEnemyProjectileType.Normal, 4)
                             , new DReinforcedCommon(180, 4)
                ),

                new(30, false, new DReinforcedCommon(20, 4)
                             , new DReinforcedCommon(100, 4)
                             , new DReinforcedCommon(180, 4)
                ),                

                new(30, false, new DReinforcedCommon(20, 4)
                             , new DReinforcedCommon(100, 4)
                             , new DReinforcedCommon(180, 4)
                             , new DReinforcedCommon(260, 4)
                             , new DReinforcedCommon(340, 4)
                             , new DReinforcedCommon(420, 4)
                             , new DReinforcedCommon(500, 4)
                             , new DReinforcedCommon(580, 4)
                             , new DReinforcedCommon(660, 4)
                             , new DReinforcedCommon(740, 4)
                             , new DReinforcedCommon(820, 4)
                             , new DReinforcedCommon(900, 4)
                             , new DReinforcedCommon(980, 4)
                             , new DSpread(1060, EEnemyProjectileType.Light, 4)
                             , new DSpread(1140, EEnemyProjectileType.Light, 4)
                             , new DSpread(1220, EEnemyProjectileType.Light, 4)
                             , new DReinforcedCommon(1300, 4)
                             , new DReinforcedCommon(1380, 4)
                ),

                new(150, false, new DReinforcedCommon(20, 4)
                             , new DReinforcedCommon(100, 4)
                             , new DReinforcedCommon(180, 4)
                             , new DReinforcedCommon(260, 4)
                             , new DReinforcedCommon(340, 4)
                             , new DReinforcedCommon(420, 4)
                             , new DReinforcedCommon(500, 4)
                             , new DReinforcedCommon(580, 4)
                             , new DReinforcedCommon(660, 4)
                             , new DReinforcedCommon(740, 4)
                             , new DReinforcedCommon(820, 4)
                             , new DReinforcedCommon(900, 4)
                             , new DReinforcedCommon(980, 4)
                             , new DReinforcedCommon(1060, 4)
                             , new DSpread(1140, EEnemyProjectileType.Light, 4)
                             , new DSpread(1220, EEnemyProjectileType.Light, 4)
                             , new DSpread(1300, EEnemyProjectileType.Light, 4)
                             , new DReinforcedCommon(1380, 4)
                ),

                new(20, false, new DFollower(50, EEnemyProjectileType.Light)) { CheckpointId = 1 },
                new(20, false, new DFollower(100, EEnemyProjectileType.Light)),
                new(20, false, new DFollower(150, EEnemyProjectileType.Light)),
                new(20, false, new DFollower(200, EEnemyProjectileType.Light)),
                new(20, false, new DFollower(250, EEnemyProjectileType.Light)),
                new(20, false, new DFollower(300, EEnemyProjectileType.Light)),
                new(20, false, new DFollower(350, EEnemyProjectileType.Light)),
                new(20, false, new DFollower(400, EEnemyProjectileType.Light)),
                new(20, false, new DFollower(450, EEnemyProjectileType.Light)),
                new(20, false, new DFollower(500, EEnemyProjectileType.Light)),
                new(20, false, new DFollower(550, EEnemyProjectileType.Light)),
                new(20, false, new DFollower(600, EEnemyProjectileType.Light)),
                new(20, false, new DFollower(650, EEnemyProjectileType.Light)),
                new(20, false, new DFollower(700, EEnemyProjectileType.Light)),
                new(20, false, new DFollower(750, EEnemyProjectileType.Light)),
                new(20, false, new DFollower(800, EEnemyProjectileType.Light)),
                new(20, false, new DFollower(850, EEnemyProjectileType.Light)),
                new(20, false, new DFollower(900, EEnemyProjectileType.Light)),
                new(20, false, new DFollower(950, EEnemyProjectileType.Light)),
                new(20, false, new DFollower(1000, EEnemyProjectileType.Light)),
                new(20, false, new DFollower(1050, EEnemyProjectileType.Light)),
                new(20, false, new DFollower(1100, EEnemyProjectileType.Light)),
                new(20, false, new DFollower(1150, EEnemyProjectileType.Light)),
                new(20, false, new DFollower(1200, EEnemyProjectileType.Light)),
                new(20, false, new DFollower(1250, EEnemyProjectileType.Light)),
                new(20, false, new DFollower(1300, EEnemyProjectileType.Light)),
                new(70, false, new DFollower(1350, EEnemyProjectileType.Light)),

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(180, 3)
                             , new DReinforcedCommon(260, 3)
                             , new DReinforcedCommon(340, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(180, 3)
                             , new DReinforcedCommon(260, 3)
                             , new DReinforcedCommon(340, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(180, 3)
                             , new DReinforcedCommon(260, 3)
                             , new DReinforcedCommon(340, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),
                
                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(180, 3)
                             , new DReinforcedCommon(260, 3)
                             , new DReinforcedCommon(340, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(180, 3)
                             , new DReinforcedCommon(260, 3)
                             , new DReinforcedCommon(340, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(180, 3)
                             , new DReinforcedCommon(260, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(180, 3)
                             , new DReinforcedCommon(260, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(180, 3)
                             , new DReinforcedCommon(260, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(180, 3)
                             , new DReinforcedCommon(260, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(180, 3)
                             , new DReinforcedCommon(260, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(180, 3)
                             , new DReinforcedCommon(260, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(180, 3)
                             , new DReinforcedCommon(260, 3)
                             , new DReinforcedCommon(340, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(180, 3)
                             , new DReinforcedCommon(260, 3)
                             , new DReinforcedCommon(340, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),

                //**the S turn**//

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),  

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),   

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ), 

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ), 

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ), 

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ), 

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ), 

                //**the Straight path with projectiles**//

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),  

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),  

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DSpread(980, EEnemyProjectileType.Normal, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),  

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),  

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),   

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DSpread(660, EEnemyProjectileType.Normal, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),  

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),  

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DSpread(1220, EEnemyProjectileType.Normal, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),  

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),  

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),    

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),    

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DSpread(420, EEnemyProjectileType.Normal, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),    

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),    

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),  

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),  

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DSpread(1060, EEnemyProjectileType.Normal, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),  

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),    

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),  

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),    

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),  

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DSpread(660, EEnemyProjectileType.Normal, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),   

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),    

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ), 

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),    

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),  

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DSpread(500, EEnemyProjectileType.Normal, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),    

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),    

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),  

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ), 

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DSpread(1060, EEnemyProjectileType.Normal, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),    

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),    

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ), 

                new(300, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(500, 3)
                             , new DReinforcedCommon(580, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(820, 3)
                             , new DReinforcedCommon(900, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1140, 3)
                             , new DReinforcedCommon(1220, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ), 

                new(150, false, new DCrusader(400, 1f)
                              , new DCrusader(500, 2f)
                              , new DCrusader(600, 3f)
                              , new DCrusader(700, 3.5f)
                              , new DCrusader(600, 4f)
                              , new DCrusader(500, 5f)
                              , new DCrusader(400, 6f)

                              , new DCrusader(1000, 1f)
                              , new DCrusader(900, 2f)
                              , new DCrusader(800, 3f)
                              , new DCrusader(800, 4f)
                              , new DCrusader(900, 5f)
                              , new DCrusader(1000, 6f)
                   ),

                new(15, false, new DFollower(100, EEnemyProjectileType.Light)) { CheckpointId = 2 },
                new(15, false, new DFollower(200, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(300, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(400, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(500, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(600, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(700, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(800, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(900, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(1000, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(1100, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(1200, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(1300, EEnemyProjectileType.Light)),

                new(15, false, new DFollower(100, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(200, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(300, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(400, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(500, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(600, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(700, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(800, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(900, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(1000, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(1100, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(1200, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(1300, EEnemyProjectileType.Light)),

                new(15, false, new DFollower(100, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(200, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(300, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(400, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(500, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(600, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(700, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(800, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(900, EEnemyProjectileType.Light)),
                new(15, false, new DSniper(1000, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(1100, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(1200, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(1300, EEnemyProjectileType.Light)),

                new(15, false, new DFollower(100, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(200, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(300, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(400, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(500, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(600, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(700, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(800, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(900, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(1000, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(1100, EEnemyProjectileType.Light)),
                new(15, false, new DFollower(1200, EEnemyProjectileType.Light)),
                new(60, false, new DFollower(1300, EEnemyProjectileType.Light)),


                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(340, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(340, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),   
                
                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),  

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(340, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(340, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                             , new DBomber(1200)
                ),  

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),    

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(340, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),   

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(340, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                             , new DBomber(200)
                ),  

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),   

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(340, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ), 

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(340, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                             , new DBomber(1200)
                ),   

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),   

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(340, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(340, 3)
                             , new DReinforcedCommon(420, 3)
                             , new DReinforcedCommon(660, 3)
                             , new DReinforcedCommon(740, 3)
                             , new DReinforcedCommon(980, 3)
                             , new DReinforcedCommon(1060, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),

                new(30, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                             , new DBomber(200)
                ),  

                new(180, false, new DReinforcedCommon(20, 3)
                             , new DReinforcedCommon(100, 3)
                             , new DReinforcedCommon(1300, 3)
                             , new DReinforcedCommon(1380, 3)
                ),   

                new(100, false, new DReinforcedCommon(20, 4)
                             , new DReinforcedCommon(100, 4)
                             , new DReinforcedCommon(180, 4)
                             , new DReinforcedCommon(260, 4)
                             , new DReinforcedCommon(340, 4)
                             , new DReinforcedCommon(420, 4)
                             , new DReinforcedCommon(500, 4)
                             , new DReinforcedCommon(580, 4)
                             , new DReinforcedCommon(660, 4)
                             , new DReinforcedCommon(740, 4)
                             , new DReinforcedCommon(820, 4)
                             , new DReinforcedCommon(900, 4)
                             , new DReinforcedCommon(980, 4)
                             , new DReinforcedCommon(1060, 4)
                             , new DReinforcedCommon(1140, 4)
                             , new DReinforcedCommon(1220, 4)
                ),         

                new(100, false, new DReinforcedCommon(180, 4)
                             , new DReinforcedCommon(260, 4)
                             , new DReinforcedCommon(340, 4)
                             , new DReinforcedCommon(420, 4)
                             , new DReinforcedCommon(500, 4)
                             , new DReinforcedCommon(580, 4)
                             , new DReinforcedCommon(660, 4)
                             , new DReinforcedCommon(740, 4)
                             , new DReinforcedCommon(820, 4)
                             , new DReinforcedCommon(900, 4)
                             , new DReinforcedCommon(980, 4)
                             , new DReinforcedCommon(1060, 4)
                             , new DReinforcedCommon(1140, 4)
                             , new DReinforcedCommon(1220, 4)
                             , new DReinforcedCommon(1300, 4)
                             , new DReinforcedCommon(1380, 4)
                ),   

                new(100, false, new DReinforcedCommon(20, 4)
                             , new DReinforcedCommon(100, 4)
                             , new DReinforcedCommon(180, 4)
                             , new DReinforcedCommon(260, 4)
                             , new DReinforcedCommon(340, 4)
                             , new DReinforcedCommon(420, 4)
                             , new DReinforcedCommon(500, 4)
                             , new DReinforcedCommon(580, 4)
                             , new DReinforcedCommon(660, 4)
                             , new DReinforcedCommon(740, 4)
                             , new DReinforcedCommon(820, 4)
                             , new DReinforcedCommon(900, 4)
                             , new DReinforcedCommon(980, 4)
                             , new DReinforcedCommon(1060, 4)
                             , new DReinforcedCommon(1140, 4)
                             , new DReinforcedCommon(1220, 4)
                ),  

                new(100, false, new DReinforcedCommon(20, 4)
                             , new DReinforcedCommon(100, 4)
                             , new DReinforcedCommon(180, 4)
                             , new DReinforcedCommon(260, 4)
                             , new DReinforcedCommon(340, 4)
                             , new DReinforcedCommon(420, 4)
                             , new DReinforcedCommon(500, 4)
                             , new DReinforcedCommon(580, 4)
                             , new DReinforcedCommon(820, 4)
                             , new DReinforcedCommon(900, 4)
                             , new DReinforcedCommon(980, 4)
                             , new DReinforcedCommon(1060, 4)
                             , new DReinforcedCommon(1140, 4)
                             , new DReinforcedCommon(1220, 4)
                             , new DReinforcedCommon(1300, 4)
                             , new DReinforcedCommon(1380, 4)
                ),                  
            };
        }
    }
}