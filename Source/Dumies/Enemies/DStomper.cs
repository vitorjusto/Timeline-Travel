using Godot;
using Shooter.Source.Dumies.Interfaces;
using Shooter.Source.Models.Enemies;
using TimelineTravel.Source.Managers;

namespace Shooter.Source.Dumies.Enemies
{
    public class DStomper : IEnemyDummy
    {        
        private readonly int _x;

		public DStomper(int x)
        	=> _x = x;

        public Node2D GetInstance()
        {
            var instance = LoaderManager.GetEnemy<Stomper>("Stomper");

            instance.Position = new Vector2(_x, y: -30);

            return instance;
        }
        
    }
}