using Godot;
using System;

public partial class TimeRupture : Node2D
{
	public override void _Ready()
	{
		Rotation = new Random().Next(0, 359);

		var scale = new Random().Next(0, 10);
		Scale = new Vector2(scale, scale);
	}

	public override void _Process(double delta)
	{
		Position += new Vector2(0, 7);
	}

	public void OnScreenExited()
	{
		CallDeferred("queue_free");
	}
}
