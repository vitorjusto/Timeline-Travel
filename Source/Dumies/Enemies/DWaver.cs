using Godot;
using Shooter.Source.Dumies.Interfaces;
using TimelineTravel.Source.Managers;

namespace Shooter.Source.Dumies.Enemies
{
    public class DWaver: IEnemyDummy
    {
        private readonly int _x;
        private readonly int _waveCooldown;

		public DWaver(int x, int waveCooldown)
        {
            _x = x;
            _waveCooldown = waveCooldown;
        }

        public Node2D GetInstance()
        {
            var instance = LoaderManager.GetEnemy<Waver>("Waver");

            instance.Position = new Vector2(_x, y: instance.GetStartPosition());
            instance.WaveCooldown = _waveCooldown;
            return instance;
        }
    }
}