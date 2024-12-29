using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shooter.Source.Dumies.Interfaces;

namespace Shooter.Source.Models.Levels
{
    public class EnemySection
    {
        public List<IEnemyDummy> Enemies;
        public int Time = 0;
        public bool WaitForEveryEnemy = false;
        public int CheckpointId = 0;

        public EnemySection(int time, bool waitForEveryEnemy, params IEnemyDummy[] enemies)
        {
            Time = time;
            WaitForEveryEnemy = waitForEveryEnemy;
            Enemies = enemies.ToList();
        }
    }
}