using Godot;
using Shooter.Source.Interfaces;

namespace Shooter.Source.Models.Bosses.BossLevelNine.States
{
    public class BackInTimeState : IState
    {
        private FourDWarMachine _boss;

        public BackInTimeState(Node2D boss)
        {
            _boss = (FourDWarMachine)boss;
            _boss.EmitSignal("ChangeShootingState", true);

            var enemySpawner = _boss.GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
            var currentLevel = enemySpawner.CurrentLevel;

            enemySpawner.CurrentLevel = 9;
			enemySpawner.StartLevel();
            enemySpawner.CurrentLevel = currentLevel;

            _boss.TransitionEnded();
        }

        public IState NextState()
        {
            return null;
        }

        public bool Process(double delta)
        {
            return false;
        }
    }
}