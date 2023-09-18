using Godot;
using Shooter.Source.Dumies.Interfaces;
using Shooter.Source.Enums;

namespace Shooter.Source.Dumies.Enemies
{
    public class DFollower : IEnemyDummy
    {
        private int _x;
        private EEnemyProjectileType _projectileType;
        public DFollower(int x, EEnemyProjectileType projectileType)
        {
            _x = x;
            _projectileType = projectileType;
        }

        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Enemies/Follower.tscn");

            var instance = (Follower)scene.Instantiate();

            instance.Position = new Vector2(_x, y: -30);
            instance.ProjectileType = _projectileType;

            return instance;
        }
    }
}