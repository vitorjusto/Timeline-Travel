using Godot;
using Shooter.Source.Dumies.Interfaces;
using Shooter.Source.Models.Enemies;

namespace Shooter.Source.Dumies.Enemies
{
    public class DCurver : IEnemyDummy
    {
        private readonly float _x;
        public DCurver(float x)
        {
            _x = x;
        }

        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Enemies/Curver.tscn");

            var instance = (Curver)scene.Instantiate();

            instance.SetPosition(_x);

            return instance;
        }
    }
}