using System;
using Godot;
using Shooter.Source.Interfaces;

namespace Shooter.Source.Models.Bosses.SpaceshipPredador
{
    public class Exploding : IState
    {
        public Node2D _node;
        private EnemySpawner _enemySpawner;
        public int _time = 0;

        public Exploding(Node2D node)
        {
            _node = node;
            _enemySpawner = _node.GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
        }

        public IState NextState()
        {
            return null;
        }

        public bool Process()
        {
            if(_time == 0)
                _enemySpawner.RemoveAllEnemies();

            _enemySpawner.AddExplosion(_node.Position.X + (new Random().Next(-100, 100)), _node.Position.Y + (new Random().Next(-100, 100)));

		    if(_time == 300)
		    {
			    _enemySpawner.EndLevel();
			    _enemySpawner.RemoveEnemy(_node);

		    }

            _time++;
            
            return false;
        }
    }
}