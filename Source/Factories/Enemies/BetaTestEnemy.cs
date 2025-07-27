using System.Collections.Generic;
using Godot;
using Shooter.Source.Dumies.Enemies;
using Shooter.Source.Enums;
using Shooter.Source.Models.Levels;

namespace Shooter.Source.Factories.Enemies
{
    public static class BetaTestEnemy
    {
        public static List<EnemySection> GetEnemies()
        {
            return new List<EnemySection>()
            {
                new(30, false, new DWaver(100, 0)),
                new(30, false, new DWaver(200, 0)),
                new(30, false, new DWaver(300, 0)),
                new(30, false, new DWaver(400, 0)),
            };
        }
    }
}