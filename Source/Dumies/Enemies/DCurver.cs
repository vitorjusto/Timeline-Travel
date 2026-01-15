using Godot;
using Shooter.Source.Dumies.Interfaces;
using Shooter.Source.Models.Enemies;
using TimelineTravel.Source.Managers;

namespace Shooter.Source.Dumies.Enemies
{
    public class DCurver : IEnemyDummy
    {
        private readonly float _x;

		public DCurver(float x)
        	=>_x = x;

        public Node2D GetInstance()
        {
            var instance = LoaderManager.GetEnemy<Curver>("Curver");

            instance.SetPosition(_x);

            return instance;
        }
    }
}