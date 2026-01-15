using Godot;
using Shooter.Source.Dumies.Interfaces;
using Shooter.Source.Enums;
using Shooter.Source.Models.Enemies;
using TimelineTravel.Source.Managers;

namespace Shooter.Source.Dumies.Enemies
{
    public class DSpreader : IEnemyDummy
    {
        private readonly int _x;
        private readonly EEnemyProjectileType _projectileType;
        private readonly int _speed;

		public DSpreader(int x, EEnemyProjectileType projectileType, int speed = 1)
        {
            _x = x;
            _projectileType = projectileType;
            _speed = speed;
        }

        public Node2D GetInstance()
        {
            var instance = LoaderManager.GetEnemy<Spreader>("Spreader");

            instance.Position = new Vector2(_x, y: -50);

            instance.ProjectileType = _projectileType;
            instance.Speed = _speed;

            return instance;
        }
    }
}