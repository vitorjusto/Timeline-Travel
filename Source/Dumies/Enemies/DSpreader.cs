using Godot;
using Shooter.Source.Dumies.Interfaces;
using Shooter.Source.Enums;

namespace Shooter.Source.Dumies.Enemies
{
    public class DSpreader : IEnemyDummy
    {
        private int _x;
        private EEnemyProjectileType _projectileType;
        private int _speed;

        public DSpreader(int x, EEnemyProjectileType projectileType, int speed = 1)
        {
            _x = x;
            _projectileType = projectileType;
            _speed = speed;
        }

        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Enemies/Spreader.tscn");

            var instance = (Spreader)scene.Instantiate();

            instance.Position = new Vector2(_x, y: -30);

            instance.ProjectileType = _projectileType;
            instance.Speed = _speed;

            return instance;
        }
    }
}