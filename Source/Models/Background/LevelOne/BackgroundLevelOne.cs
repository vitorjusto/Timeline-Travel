using Godot;
using System;

public partial class BackgroundLevelOne : Node2D
{
	private int _time;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
		if(_time % 10 == 0)
		{
			var scene = GD.Load<PackedScene>("res://Scenes/Background/Stars.tscn");

        	var instance = (Stars)scene.Instantiate();

			AddChild(instance);
		}


		_time++;

	}
}
