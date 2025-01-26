using Godot;
using System;

public partial class GameOverScreen : Node2D
{
	private int _timer;
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		_timer++;

		if(_timer == 500)
			GetTree().ChangeSceneToFile("res://Scenes/TitleScreen.tscn");
	}
}