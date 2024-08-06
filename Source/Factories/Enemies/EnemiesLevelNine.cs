using System.Collections.Generic;
using Shooter.Source.Dumies.Enemies;
using Shooter.Source.Models.Levels;

namespace Shooter.Source.Factories.Enemies
{
    public class EnemiesLevelNine
    {
        public static List<EnemySection> GetEnemies()
        {
            return new List<EnemySection>()
            {
                new EnemySection(50, true, new DReinforcedCommon(50, 3)
                                         , new DReinforcedCommon(100, 3)
                                         , new DReinforcedCommon(150, 3)
                                         , new DReinforcedCommon(200, 3)
                                         , new DReinforcedCommon(250, 3)
                                         , new DReinforcedCommon(300, 3)
                                         , new DReinforcedCommon(350, 3)
                                         , new DReinforcedCommon(400, 3)
                                         , new DReinforcedCommon(450, 3)
                                         , new DReinforcedCommon(500, 3)
                                         , new DReinforcedCommon(550, 3)
                                         , new DReinforcedCommon(900, 3)
                                         , new DReinforcedCommon(950, 3)
                                         , new DReinforcedCommon(1000, 3)
                                         , new DReinforcedCommon(1050, 3)
                                         , new DReinforcedCommon(1100, 3)
                                         , new DReinforcedCommon(1150, 3)
                                         , new DReinforcedCommon(1200, 3)
                                         , new DReinforcedCommon(1250, 3)
                                         , new DReinforcedCommon(1350, 3)
                                         , new DReinforcedCommon(1300, 3)),
            };

        }
    }
}