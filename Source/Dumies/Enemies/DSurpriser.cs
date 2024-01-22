using Godot;
using Shooter.Source.Dumies.Interfaces;

namespace Sooter.Source.Dumies.Enemies
{
    public class DSurpriser : IEnemyDummy
    {
        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Enemies/Surpriser.tscn");

            var instance = (Surpriser)scene.Instantiate();

            return instance;
        }
    }
}