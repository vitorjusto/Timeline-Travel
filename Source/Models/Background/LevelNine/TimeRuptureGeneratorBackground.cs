using System;
using Godot;

public partial class TimeRuptureGeneratorBackground : Node2D
{
	private int _timer;
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		_timer++;

		if(_timer > 70)
			GenerateTimeRupture();
	}

    private void GenerateTimeRupture()
    {
		var xPosition = new Random().Next(0, 1400);

        var scene = GD.Load<PackedScene>("res://Scenes/Misc/TimeRupture.tscn");
        var instance = (Node2D)scene.Instantiate();
        instance.Position = new Vector2(xPosition, y: -300);

		AddChild(instance);

		_timer = 0;
    }
}
