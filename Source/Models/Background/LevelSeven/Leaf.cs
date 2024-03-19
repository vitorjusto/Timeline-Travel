using Godot;
using System;

public partial class Leaf : Node2D
{
	private float _xSpeed = 1;
	private float _xSpeedModifier;
	public override void _Ready()
	{
		_xSpeedModifier = new Random().Next(1, 10) * 0.01f;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position = new Vector2(Position.X - _xSpeed, Position.Y + 5);

		_xSpeed += _xSpeedModifier;

		if(Position.Y > 950)
			QueueFree();
	}
}
