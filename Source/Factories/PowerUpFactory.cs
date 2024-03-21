using Godot;

namespace Shooter.Source.Factories
{
    public class PowerUpFactory
    {
        public static Node2D GetHpUp(Vector2 position)
        {
            var scene = GD.Load<PackedScene>("res://Scenes/PowerUp/HpUp.tscn");

            var instance = (Node2D)scene.Instantiate();

            instance.Position = position;
            return instance;
        }
    }
}