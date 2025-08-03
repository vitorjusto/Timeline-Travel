using Godot;
using Shooter.Source.Models.Misc;

public partial class GameOverScreen : Node2D
{
	private readonly QuickTimer _timer = new(500);
    
	public override void _Process(double delta)
	{
		if(_timer.Process(delta))
			GetTree().ChangeSceneToFile("res://Scenes/TitleScreen.tscn");
	}
}