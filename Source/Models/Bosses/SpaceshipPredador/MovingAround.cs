using System;
using Godot;
using Shooter.Source.Dumies.Enemies;
using Shooter.Source.Interfaces;

namespace Shooter.Source.Models.Bosses.SpaceshipPredador
{
    public class MovingAround : IState
    {
        private Node2D _node;
        private int _speed = 5;

        private int _time = 383;
        private int _enemiesSpawned = 0;
        private EnemySpawner _enemySpawner;

        public MovingAround(Node2D node)
        {
            _node = node;
            _enemySpawner = _node.GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
        }

        public IState NextState()
        {
            return new Hunting(_node); 
        }

        public bool Process()
        {
            _node.Position = new Vector2(x: _node.Position.X + _speed, y: _node.Position.Y);

			if(_node.Position.X > 1412 || _node.Position.X < 32)
				_speed *= -1;

            if(_enemiesSpawned < 4)
            {
                if(_time > 383)
                    AddEnemies();

                _time++;
            }

            

            return ((SpaceshipPredadorModel)_node).Hp < 15 && _enemiesSpawned == 4;
        }

        private void AddEnemies()
        {
            _enemySpawner.AddEnemy(new DWaver(100, 5));
            _enemySpawner.AddEnemy(new DWaver(200, 10));
            _enemySpawner.AddEnemy(new DWaver(300, 15));
            _enemySpawner.AddEnemy(new DWaver(400, 20));
            _enemySpawner.AddEnemy(new DWaver(500, 25));
            _enemySpawner.AddEnemy(new DWaver(600, 30));
            _enemySpawner.AddEnemy(new DWaver(700, 35));
            _enemySpawner.AddEnemy(new DWaver(800, 40));
            _enemySpawner.AddEnemy(new DWaver(900, 45));
            _enemySpawner.AddEnemy(new DWaver(1000, 50));
            _enemySpawner.AddEnemy(new DWaver(1100, 55));
            _enemySpawner.AddEnemy(new DWaver(1200, 60));

            _time = 0;
            _enemiesSpawned++;
        }
    }
}