using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shooter.Source.Models.Levels;
using Shooter.Source.Dumies.Enemies;
using Shooter.Source.Enums;

namespace Shooter.Source.Factories.Levels
{
    public static class EnemiesLevelOne
    {
        public static List<EnemySection> GetEnemies()
        {
            return new List<EnemySection>()
            {
                new EnemySection(10, true, new DCrusader(200, 5f), new DCrusader(200, 4f), new DCrusader(200, 3f), new DCrusader(200, 2f), new DCrusader(200, 1f), new DCrusader(200, 6f)),
            };

        }
    }
}