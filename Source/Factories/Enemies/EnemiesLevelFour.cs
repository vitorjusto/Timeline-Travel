using System.Collections.Generic;
using Shooter.Source.Dumies.Enemies;
using Shooter.Source.Models.Levels;

namespace Shooter.Source.Factories.Enemies
{
    public class EnemiesLevelFour
    {
        public static List<EnemySection> GetEnemies()
        {
            return new List<EnemySection>()
            {
                new EnemySection(50, false, new DWaver(100, 5), new DWaver(200, 10), new DWaver(300, 15), new DWaver(400, 20), new DWaver(500, 25), new DWaver(600, 30), new DWaver(700, 35), new DWaver(800, 40), new DWaver(900, 45), new DWaver(1000, 50), new DWaver(1100, 55), new DWaver(1200, 60))
            };

        }
        
    }
}