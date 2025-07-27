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

	public override void _Process(double delta)
	{
		Position += new Vector2(x: 0, y: (float)(delta * 300));
	}

	public void OnScreenExited()
	{
		QueueFree();
	}
}
