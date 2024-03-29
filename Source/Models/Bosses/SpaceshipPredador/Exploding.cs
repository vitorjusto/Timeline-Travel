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
        private int _size;

        public Exploding(Node2D node, int size = 100)
        {
            _node = node;
            _enemySpawner = _node.GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
            _size = size;
        }

        public IState NextState()
        {
            return null;
        }

        public bool Process()
        {
            if(_time == 0)
                _enemySpawner.RemoveAllEnemies();

            _enemySpawner.AddExplosion(_node.Position.X + (new Random().Next(-_size, _size)), _node.Position.Y + (new Random().Next(-_size, _size)));

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