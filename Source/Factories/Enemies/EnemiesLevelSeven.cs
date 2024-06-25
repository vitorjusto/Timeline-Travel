using System.Collections.Generic;
using System.Net;
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
                new EnemySection(10, false, new DCommon(100, 9), new DCommon(1300, 9)),
                new EnemySection(40, false, new DGooder(200, true), new DSniper(300, EEnemyProjectileType.Light)),                     
                

            };

        }        
    }
}