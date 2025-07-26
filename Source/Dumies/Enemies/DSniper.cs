using Godot;
using Shooter.Source.Dumies.Interfaces;
using Shooter.Source.Enums;
using Shooter.Source.Models.Enemies;

namespace Shooter.Source.Dumies.Enemies
{
    public class DSniper : IEnemyDummy
    {
        private readonly int _x;
        private readonly EEnemyProjectileType _projectileType;
        public DSniper(int x, EEnemyProjectileType projectileType)
        {
            _x = x;
            _projectileType = projectileType;
        }

        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Enemies/Sniper.tscn");

            var instance = (Sniper)scene.Instantiate();

            instance.Position = new Vector2(_x, y: -30);
            instance.ProjectileType = _projectileType;

            return instance;
        }
    }
}