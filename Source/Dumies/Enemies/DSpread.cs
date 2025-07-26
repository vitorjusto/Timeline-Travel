using Godot;
using Shooter.Source.Dumies.Interfaces;
using Shooter.Source.Enums;
using Shooter.Source.Models.Enemies;

namespace Shooter.Source.Dumies.Enemies
{
    public class DSpread : IEnemyDummy
    {
        private int _x;
        private EEnemyProjectileType _projectileType;
        private int _speed;

        public DSpread(int x, EEnemyProjectileType projectileType, int speed =  2)
        {
            _x = x;
            _projectileType = projectileType;
            _speed = speed;
        }

        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Enemies/Spread.tscn");

            var instance = (Spread)scene.Instantiate();

            instance.Position = new Vector2(_x, y: -30);

            instance.ProjectileType = _projectileType;
            instance.Speed = _speed;
            return instance;
        }
    }
}