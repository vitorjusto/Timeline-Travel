using Godot;
using Shooter.Source.Dumies.Interfaces;
using Shooter.Source.Models.Enemies;
using TimelineTravel.Source.Managers;

namespace Shooter.Source.Dumies.Enemies
{
    public class DDasher : IEnemyDummy
    {
        private readonly int _x;

		public DDasher(int x)
        	=> _x = x;

        public Node2D GetInstance()
        {
            var instance = LoaderManager.GetEnemy<Dasher>("Dasher");

            instance.Position = new Vector2(_x, y: -30);

            return instance;
        }
    }
}