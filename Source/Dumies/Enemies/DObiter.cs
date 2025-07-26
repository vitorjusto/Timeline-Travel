using Godot;
using Shooter.Source.Dumies.Interfaces;
using Shooter.Source.Models.Enemies;

namespace Shooter.Source.Dumies.Enemies
{
    public class DOrbiter : IEnemyDummy
    {
        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Enemies/Orbiter.tscn");

            var instance = (Orbiter)scene.Instantiate();

            return instance;
        }
    }
}