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
                new EnemySection(50, false, new DShoter(100, EEnemyProjectileType.Normal), new DShoter(300, EEnemyProjectileType.Light), new DShoter(500, EEnemyProjectileType.Strong)),
            };

        }
    }
}