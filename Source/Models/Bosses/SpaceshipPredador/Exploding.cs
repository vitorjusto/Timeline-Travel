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
        private bool _removeEnemy;
        private Vector2 _positionOffSet;

        public Exploding(Node2D node, int size = 100, bool removeEnemy = true, Vector2 positionOffSet = default)
        {
            _node = node;
            _enemySpawner = _node.GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
            _size = size;
            _removeEnemy = removeEnemy;
            _positionOffSet = positionOffSet;
        }

        public IState NextState()
        {
            return null;
        }

        public bool Process()
        {
            if(_time == 0)
                _enemySpawner.RemoveAllEnemies();

            _enemySpawner.AddExplosion(_node.Position.X + _positionOffSet.X + new Random().Next(-_size, _size), _node.Position.Y + _positionOffSet.Y + (new Random().Next(-_size, _size)));

		    if(_time == 300)
		    {
                if(_removeEnemy)
                {
			        _enemySpawner.EndLevel();
			        _enemySpawner.RemoveEnemy(_node);
                }else
                    return true;
		    }

            _time++;
            
            return false;
        }
    }
}