using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shooter.Source.Models.Levels;
using Shooter.Source.Dumies.Enemies;

namespace Shooter.Source.Factories.Levels
{
    public static class EnemiesLevelOne
    {
        public static List<EnemySection> GetEnemies()
        {
            return new List<EnemySection>()
            {
                new EnemySection(10, true, new DBomber(300), new DCommon(1000)),
            };

        }
    }
}