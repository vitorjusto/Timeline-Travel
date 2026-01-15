using Godot;
using Shooter.Source.Dumies.Interfaces;
using Shooter.Source.Enums;
using Shooter.Source.Models.Enemies;
using TimelineTravel.Source.Managers;

namespace Shooter.Source.Dumies.Enemies
{
    public class DSpread : IEnemyDummy
    {
        private readonly int _x;
        private readonly EEnemyProjectileType _projectileType;
        private readonly int _speed;

		public DSpread(int x, EEnemyProjectileType projectileType, int speed =  2)
        {
            _x = x;
            _projectileType = projectileType;
            _speed = speed;
        }

        public Node2D GetInstance()
        {
            var instance = LoaderManager.GetEnemy<Spread>("Spread");

            instance.Position = new Vector2(_x, y: -30);

            instance.ProjectileType = _projectileType;
            instance.Speed = _speed;
            return instance;
        }
    }
}