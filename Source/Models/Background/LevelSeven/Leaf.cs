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

	public override void _Process(double delta)
	{
		Position += new Vector2(-_xSpeed, 5) * (float)(delta * 60);

		_xSpeed += _xSpeedModifier;

		if(Position.Y > 950)
			QueueFree();
	}
}
