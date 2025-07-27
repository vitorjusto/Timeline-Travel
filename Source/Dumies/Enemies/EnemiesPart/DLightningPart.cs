using Godot;
using Shooter.Source.Dumies.Interfaces;
using Shooter.Source.Models.Enemies.Parts;

namespace Shooter.Source.Dumies.Enemies.EnemiesPart
{
    public class DLightningPart: IEnemyDummy
    {
        private readonly float _x;
        private readonly float _y;
        public DLightningPart(float x, float y)
        {
            _x = x;
            _y = y;
        }

        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Enemies/EnemiesPart/LightningPart.tscn");

            var instance = (LightningPart)scene.Instantiate();

            instance.Position = new Vector2(_x, _y);

            return instance;
        }
    }
}