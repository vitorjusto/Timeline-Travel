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
                                          , new DCrusader(1300, 5.8f), new DDasher(1400)),
                new EnemySection(5, false, new DBomber(100), new DBomber(1000)),                                    
                new EnemySection(10, false, new DStomper(600), new DLazer(500), new DFollower(700, EEnemyProjectileType.Light)),
                new EnemySection(10, false, new DSpread(100, EEnemyProjectileType.Light), new DSpread(1400, EEnemyProjectileType.Light), new DSpreader(750, EEnemyProjectileType.Normal))                                    
            };

        }        
    }
}