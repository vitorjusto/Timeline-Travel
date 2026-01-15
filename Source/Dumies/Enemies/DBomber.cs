using Shooter.Source.Dumies.Interfaces;
using Godot;
using Shooter.Source.Models.Enemies;
using TimelineTravel.Source.Managers;

namespace Shooter.Source.Dumies.Enemies
{
    public class DBomber : IEnemyDummy
    {
        private readonly int _x;

		public DBomber(int x)
			=> _x = x;

        public Node2D GetInstance()
        {
            var instance = LoaderManager.GetEnemy<Bomber>("Bomber");

            instance.Position = new Vector2(_x, y: -30);

            return instance;
        }
    }
}