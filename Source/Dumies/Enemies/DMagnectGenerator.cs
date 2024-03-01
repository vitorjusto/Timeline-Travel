using Godot;
using Shooter.Source.Dumies.Interfaces;

namespace Shooter.Source.Dumies.Enemies
{
    public class DMagnectGenerator: IEnemyDummy
    {
        private int _x;
        private int _id;
        public DMagnectGenerator(int x, int id)
        {
            _x = x;
            _id = id;
        }

        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Bosses/BossLevelFive/MagnectGenerator.tscn");

            var instance = (MagnectGenerator)scene.Instantiate();

            instance.Position = new Vector2(_x, y: -30);
            instance.Id = _id;

            return instance;
        }
    }
}