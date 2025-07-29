using System;
using Godot;
using Shooter.Source.Dumies.Enemies;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Bosses.BossLevelEight.States
{
    public class ShootingBlackholeState : IState
    {
        private Node2D _node;
        private EnemySpawner _enemiesManager;
        private WaveSpeed _xSpeed;
        private QuickTimer _timer = new(200);

        public ShootingBlackholeState(Node2D node)
        {
            _node = node;
            _enemiesManager = _node.GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

            _xSpeed = new WaveSpeed(-1, 6, _node.Position.Y);
        }

        public IState NextState()
        {
            return new ShootingProjectileState(_node, this);
        }

        public bool Process(double delta)
        {
            if(_timer.Process(delta))
            {
                _enemiesManager.AddEnemy(new DBlackHole((int)_node.Position.X, (int)_node.Position.Y, new Random().Next(0, 2) == 1));
            }
            
            _node.Position = new Vector2(_node.Position.X, _xSpeed.Update(delta));
            return false;
        }
    }
}