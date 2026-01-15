using Godot;
using Shooter.Source.Dumies.Interfaces;
using Shooter.Source.Models.Enemies;
using TimelineTravel.Source.Managers;

namespace Shooter.Source.Dumies.Enemies
{
    public class DLazer : IEnemyDummy
    {
        private readonly int _x;
        private readonly int _maxTimer;
		private readonly PackedScene _scene;

		public DLazer(int x, int maxTimer)
        {
            _x = x;
            _maxTimer = maxTimer;
        }

        public Node2D GetInstance()
        {
            var instance = LoaderManager.GetEnemy<Lazer>("Lazer");

            instance.Position = new Vector2(_x, y: -30);
            instance.MaxTime = _maxTimer;

            return instance;
        }
    }
}