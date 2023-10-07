using Godot;
using System;

public partial class BackgroundManager : Node2D
{
	// Called when the node enters the scene tree for the first time.

	private IBackground _currentBackground;
	public override void _Ready()
	{
		var scene = GD.Load<PackedScene>("res://Scenes/Background/BackgroundLevelOne.tscn");

        var instance = (BackgroundLevelOne)scene.Instantiate();

		_currentBackground = instance;

		AddChild(instance);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnGamePaused(bool isPaused)
	{
		_currentBackground.PauseBackground(isPaused);
	}
}
