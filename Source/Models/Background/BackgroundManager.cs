using Godot;
using Shooter.Source.Factories.Levels;
using System;

public partial class BackgroundManager : Node2D
{
	// Called when the node enters the scene tree for the first time.

	private Node2D _currentBackground;
	public override void _Ready()
	{
		_currentBackground = LevelsFactory.GetBackground(1);

		AddChild(_currentBackground);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void SetNewBackgroundLevel(int level)
	{
		QueueFree();
		_currentBackground = LevelsFactory.GetBackground(level);

		AddChild(_currentBackground);
	}

	public void OnGamePaused(bool isPaused)
	{
		((IBackground)_currentBackground).PauseBackground(isPaused);
	}
}
