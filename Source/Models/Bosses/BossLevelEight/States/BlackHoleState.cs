using System;
using Godot;
using Shooter.Source.Dumies.Enemies;
using Shooter.Source.Enums;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Bosses.BossLevelEight.States
{
    public class BlackHoleState : IState
    {
        public Node2D _node;
        private Player _player;
        private QuickTimer _timer = new(20);
        private QuickTimer _stateTimer = new(1000);

        public BlackHoleState(Node2D node)
        {
            _node = node;
            _player = _node.GetTree().Root.GetNode<Player>("/root/Main/Player");
        }

        public IState NextState()
        {
            return new ShinkingState(_node);
        }

        public bool Process(double delta)
        {
		    var angle = Math.Atan2(_node.Position.X - _player.Position.X, _node.Position.Y - _player.Position.Y);

		    _player.SetSpeed((float)Math.Sin(angle) * (float)(delta * 300), (float)Math.Cos(angle) * (float)(delta * 300));

            if(_timer.Process(delta))
                GenerateScrap();
            
            return _stateTimer.Process(delta);
        }

        private void GenerateScrap()
        {
            var enemySpawner = _node.GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

            var xPosition = new Random().Next(-220, 1664);

            var angle = Math.Atan2(_node.Position.X - xPosition, _node.Position.Y + 32);

            var number = new Random().Next(0, 100);

            if(number % 25 == 0)
		        enemySpawner.AddEnemy(new DSpaceScrap((float)Math.Sin(angle) * (4), (float)Math.Cos(angle) * (4), xPosition, ESpaceScrapType.Bomber));
            else if(number % 10 == 0)
		        enemySpawner.AddEnemy(new DSpaceScrap((float)Math.Sin(angle) * (4), (float)Math.Cos(angle) * (4), xPosition, ESpaceScrapType.Sniper));
            else
		        enemySpawner.AddEnemy(new DSpaceScrap((float)Math.Sin(angle) * (4), (float)Math.Cos(angle) * (4), xPosition, GameManager.IsSpecialMode? ESpaceScrapType.Sniper: ESpaceScrapType.Common));
        }
    }
}