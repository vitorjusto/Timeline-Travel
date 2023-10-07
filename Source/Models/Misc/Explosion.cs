using Godot;
using System;

public partial class Explosion : AnimatedSprite2D
{
	// Called when the node enters the scene tree for the first time.
	private int _time = 0;
	public override void _Ready()
	{
		Play("default");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(_time == 14)
			QueueFree();

		_time++;
	}
}
