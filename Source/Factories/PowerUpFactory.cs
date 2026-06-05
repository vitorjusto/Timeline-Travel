using Godot;
using TimelineTravel.Source.Managers;

namespace Shooter.Source.Factories;
public class PowerUpFactory
{
	public static Node2D GetPowerUp(string name, Vector2 position)
	{
		var instance = LoaderManager.GetObjectPool<Node2D>($"res://Scenes/PowerUp/{name}.tscn");
		
		instance.Position = position;
		return instance;
	}
}