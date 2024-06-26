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
                new(50, false, new DCommon(300, 3), new DCommon(400, 3), new DCommon(500, 3), new DCommon(600, 3), new DCommon(700, 3), new DCommon(800, 3), new DCommon(900, 3), new DCommon(1000, 3), new DCommon(1100, 3)),
            };

        }
    }
}