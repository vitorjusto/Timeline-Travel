using System;
using Godot;
using Shooter.Source.Models.Misc;
using TimelineTravel.Source.Managers;

public partial class TimeRuptureGeneratorBackground : Node2D
{
	private readonly QuickTimer _timer = new(70);
	private PackedScene _scene;

	public override void _Ready()
	{
		_scene = GD.Load<PackedScene>("res://Scenes/Misc/TimeRupture.tscn");
	}

	public override void _Process(double delta)
	{
		if(_timer.Process(delta))
			GenerateTimeRupture();
	}

    private void GenerateTimeRupture()
    {
		var xPosition = new Random().Next(0, 1400);
		
		var instance = _scene.Instantiate<Node2D>();
        instance.Position = new Vector2(xPosition, y: -300);

		AddChild(instance);
    }
}
