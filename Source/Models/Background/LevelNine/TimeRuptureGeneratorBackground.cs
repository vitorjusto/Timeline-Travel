using System;
using Godot;
using Shooter.Source.Models.Misc;

public partial class TimeRuptureGeneratorBackground : Node2D
{
	private readonly QuickTimer _timer = new(70);
	public override void _Process(double delta)
	{
		if(_timer.Process(delta))
			GenerateTimeRupture();
	}

    private void GenerateTimeRupture()
    {
		var xPosition = new Random().Next(0, 1400);

        var scene = GD.Load<PackedScene>("res://Scenes/Misc/TimeRupture.tscn");
        var instance = (Node2D)scene.Instantiate();
        instance.Position = new Vector2(xPosition, y: -300);

		AddChild(instance);
    }
}
