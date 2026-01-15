using Godot;
using Shooter.Source.Dumies.Interfaces;
using Shooter.Source.Models.Enemies;
using TimelineTravel.Source.Managers;

namespace Shooter.Source.Dumies.Enemies
{
    public class DSurpriser : IEnemyDummy
    {
        private Vector2 _initialPosition;
        private readonly bool _startNextToPlayer = true;

		public DSurpriser(Vector2 initialPosition)
        {
            _initialPosition = initialPosition;
            _startNextToPlayer = false;
        }

        public DSurpriser() {}

        public Node2D GetInstance()
        {
            var instance = LoaderManager.GetEnemy<Surpriser>("Surpriser");

            instance.Position = _initialPosition;
            instance.StartNextToPlayer = _startNextToPlayer;

            return instance;
        }
    }
}