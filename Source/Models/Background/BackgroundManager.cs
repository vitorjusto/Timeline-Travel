using Godot;
using System;

public partial class BackgroundManager : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var scene = GD.Load<PackedScene>("res://Scenes/Background/BackgroundLevelOne.tscn");

        var instance = scene.Instantiate();

		AddChild(instance);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
