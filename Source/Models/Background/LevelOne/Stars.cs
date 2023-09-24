using Godot;
using System;

public partial class Stars : AnimatedSprite2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Position = new Vector2(x: new Random().Next(0, 1444), y: -30);

		var animation = new Random().Next(1, 7);
		if(animation == 1)
			Play("Green1");
		else if(animation == 2)
			Play("Blue1");
		else if(animation == 3)
			Play("Yellow1");
		if(animation == 4)
			Play("Green2");
		else if(animation == 5)
			Play("Blue2");
		else
			Play("Yellow2");
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
