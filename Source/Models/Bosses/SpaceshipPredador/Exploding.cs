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
        private Vector2 _size;
        private bool _removeEnemy;
        private Vector2 _positionOffSet;
        private int _explosionCooldown;

        public Exploding(Node2D node, int size = 100, bool removeEnemy = true, Vector2 positionOffSet = default, bool continueMusicEvenWithoutEnemy = false)
        {
            _node = node;
            _enemySpawner = _node.GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
            _size = new Vector2(size, size);
            _removeEnemy = removeEnemy;
            _positionOffSet = positionOffSet;
            if(removeEnemy && !continueMusicEvenWithoutEnemy)   
                AudioManager.Stop();
        }

        public Exploding(Node2D node, Vector2 size, bool removeEnemy = true, Vector2 positionOffSet = default)
        {
            _node = node;
            _enemySpawner = _node.GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
            _size = size;
            _removeEnemy = removeEnemy;
            _positionOffSet = positionOffSet;
            
            if(removeEnemy)   
                AudioManager.Stop();
        }

        public IState NextState()
        {
            return null;
        }

        public bool Process()
        {
            if(_time == 0)
                _enemySpawner.RemoveAllEnemies();

            if(_explosionCooldown == 0)
            {
                _enemySpawner.AddExplosion(_node.Position.X + _positionOffSet.X + new Random().Next(-(int)_size.X, (int)_size.X), _node.Position.Y + _positionOffSet.Y + new Random().Next(-(int)_size.Y, (int)_size.Y));
                _explosionCooldown = 10;
            }else
            {
                _enemySpawner.AddExplosion(_node.Position.X + _positionOffSet.X + new Random().Next(-(int)_size.X, (int)_size.X), _node.Position.Y + _positionOffSet.Y + new Random().Next(-(int)_size.Y, (int)_size.Y), makeSound: false);
                _explosionCooldown--;
            }

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