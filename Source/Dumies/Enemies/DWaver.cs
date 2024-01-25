using Godot;
using Shooter.Source.Dumies.Interfaces;

namespace Shooter.Source.Dumies.Enemies
{
    public class DWaver: IEnemyDummy
    {
        private int _x;
        private int _waveCooldown;

        public DWaver(int x, int waveCooldown)
        {
            _x = x;
            _waveCooldown = waveCooldown;
        }

        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Enemies/Waver.tscn");

            var instance = (Waver)scene.Instantiate();

            instance.Position = new Vector2(_x, y: instance.GetStartPosition());
            instance.WaveCooldown = _waveCooldown;
            return instance;
        }
    }
}