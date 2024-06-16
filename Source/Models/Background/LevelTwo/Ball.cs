using Godot;
using System;

public partial class Ball : AnimatedSprite2D
{
	private int _speed;
	public override void _Ready()
	{
		Position = new Vector2(x: new Random().Next(0, 1444), y: -100);

		_speed = new Random().Next(1, 10);
	}

	public override void _Process(double delta)
	{
		Position = new Vector2(x: Position.X, y: Position.Y + _speed);
	}

	public void OnScreenExited()
	{
		QueueFree();
	}
}
