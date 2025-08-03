using System;
using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Bosses.SpaceshipPredador
{
    public class Exploding : IState
    {
        public Node2D _node;
        private EnemySpawner _enemySpawner;
        public QuickTimer _time = new(300);
        private Vector2 _size;
        private bool _removeEnemy;
        private Vector2 _positionOffSet;
        private float _explosionCooldown;

        public Exploding(Node2D node, int size = 100, bool removeEnemy = true, Vector2 positionOffSet = default, bool continueMusicEvenWithoutEnemy = false)
        {
            _node = node;
            _enemySpawner = _node.GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
            _size = new Vector2(size, size);
            _removeEnemy = removeEnemy;
            _positionOffSet = positionOffSet;
            _enemySpawner.RemoveAllEnemies();

            if(removeEnemy && !continueMusicEvenWithoutEnemy && !_enemySpawner.isBossRush)   
                AudioManager.Stop();
        }

        public Exploding(Node2D node, Vector2 size, bool removeEnemy = true, Vector2 positionOffSet = default)
        {
            _node = node;
            _enemySpawner = _node.GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
            _size = size;
            _removeEnemy = removeEnemy;
            _positionOffSet = positionOffSet;
            _enemySpawner.RemoveAllEnemies();
            
            if(removeEnemy && !_enemySpawner.isBossRush)   
                AudioManager.Stop();
        }

        public IState NextState()
        {
            return null;
        }

        public bool Process(double delta)
        {
            if(_explosionCooldown <= 0)
            {
                _enemySpawner.AddExplosion(_node.Position.X + _positionOffSet.X + new Random().Next(-(int)_size.X, (int)_size.X), _node.Position.Y + _positionOffSet.Y + new Random().Next(-(int)_size.Y, (int)_size.Y));
                _explosionCooldown += 10;
            }else
            {
                _enemySpawner.AddExplosion(_node.Position.X + _positionOffSet.X + new Random().Next(-(int)_size.X, (int)_size.X), _node.Position.Y + _positionOffSet.Y + new Random().Next(-(int)_size.Y, (int)_size.Y), makeSound: false);
                _explosionCooldown -= (float)(delta * 60);
            }

		    if(_time.Process(delta))
		    {
                if(_removeEnemy)
                {
			        _enemySpawner.EndLevel();
			        _enemySpawner.RemoveEnemy(_node);
                }else
                    return true;

                _time.Stop();
            }

            return false;
        }
    }
}