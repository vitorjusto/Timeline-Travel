using Godot;
using Shooter.Source.Dumies.Interfaces;
using Shooter.Source.Enums;
using Shooter.Source.Models.Enemies;
using TimelineTravel.Source.Managers;

namespace Shooter.Source.Dumies.Enemies
{
    public class DShoter : IEnemyDummy
    {
        private readonly int _x;
        private readonly EEnemyProjectileType _projectileType;

		public DShoter(int x, EEnemyProjectileType projectileType)
        {
            _x = x;
            _projectileType = projectileType;
        }

        public Node2D GetInstance()
        {
            var instance = LoaderManager.GetEnemy<Shoter>("Shoter");

            instance.Position = new Vector2(_x, y: -30);

            instance.ProjectileType = _projectileType;

            return instance;
        }
    }
}