using System;
using Godot;

public partial class StarLevelThree : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var width = (int)ProjectSettings.GetSetting("display/window/size/viewport_width");

		Position = new Vector2(x: new Random().Next(0, width), y: -30);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position = new Vector2(x: Position.X, y: Position.Y + 5);
	}

	public void OnScreenExited()
	{
		QueueFree();
	}
}
