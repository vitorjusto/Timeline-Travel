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

        public bool Process()
        {
            _node.Scale -= new Vector2(0.001f, 0.001f);

            if(_node.Scale.X < 0.08)
            {
                var enemySpawner = _node.GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
                enemySpawner.EndLevel();
			    enemySpawner.RemoveEnemy(_node);
            }
            
            return false;
        }
    }
}