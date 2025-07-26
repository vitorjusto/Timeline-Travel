using Godot;
using Shooter.Source.Interfaces;

namespace Shooter.Source.Models.Bosses.BossLevelEight.States
{
    public class ShinkingState : IState
    {
        private Node2D _node;

        public ShinkingState(Node2D node)
        {
            _node = node;
        }

        public IState NextState()
        {
            return null;
        }

        public bool Process(double delta)
        {
            _node.Scale -= new Vector2(0.003f, 0.003f);

            if(_node.Scale.X < 0.08)
            {
                EnemySpawner.GetEnemySpawner().EndLevel();
			    EnemySpawner.GetEnemySpawner().RemoveEnemy(_node);
            }
            
            return false;
        }
    }
}