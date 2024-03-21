using Godot;

namespace Shooter.Source.Factories
{
    public class PowerUpFactory
    {
        public static Node2D GetPowerUp(string name, Vector2 position)
        {
            var scene = GD.Load<PackedScene>($"res://Scenes/PowerUp/{name}.tscn");

            var instance = (Node2D)scene.Instantiate();

            instance.Position = position;
            return instance;
        }
    }
}