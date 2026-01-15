using Godot;
using Shooter.Source.Dumies.Interfaces;
using Shooter.Source.Models.Enemies;
using TimelineTravel.Source.Managers;

namespace Shooter.Source.Dumies.Enemies
{
    public class DLighting : IEnemyDummy
    {
        private readonly int _x;

		public DLighting(int x)
        	=>_x = x;

        public Node2D GetInstance()
        {
            var instance = LoaderManager.GetEnemy<Lighting>("Lighting");

            instance.Position = new Vector2(_x, y: 150);

            return instance;
        }
    }
}