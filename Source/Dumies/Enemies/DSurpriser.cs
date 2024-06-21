using Godot;
using Shooter.Source.Dumies.Interfaces;

namespace Shooter.Source.Dumies.Enemies
{
    public class DSurpriser : IEnemyDummy
    {
        private Vector2 _initialPosition;
        private bool _startNextToPlayer = true;

        public DSurpriser(Vector2 initialPosition)
        {
            _initialPosition = initialPosition;
            _startNextToPlayer = false;
        }


        public DSurpriser()
        {
        }

        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Enemies/Surpriser.tscn");

            var instance = (Surpriser)scene.Instantiate();

            instance.Position = _initialPosition;
            instance.StartNextToPlayer = _startNextToPlayer;

            return instance;
        }
    }
}