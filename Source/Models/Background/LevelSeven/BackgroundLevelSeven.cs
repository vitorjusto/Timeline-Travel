using Godot;
using System;

public partial class BackgroundLevelSeven : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void StopBackground()
	{
		GetNode<MovingParallaxLayer>("ParallaxBackground6/MovingParallaxLayer").SetSpeed(0f, 0f);
		GetNode<MovingParallaxLayer>("ParallaxBackground5/MovingParallaxLayer").SetSpeed(0f, 0f);
		GetNode<MovingParallaxLayer>("ParallaxBackground4/MovingParallaxLayer").SetSpeed(0f, 0f);
		GetNode<MovingParallaxLayer>("ParallaxBackground3/MovingParallaxLayer").SetSpeed(0f, 0f);
		GetNode<MovingParallaxLayer>("ParallaxBackground2/MovingParallaxLayer").SetSpeed(0f, 0f);
		GetNode<MovingParallaxLayer>("ParallaxBackground/MovingParallaxLayer").SetSpeed(0f, 0f);
	}

	public Timer GetTimer()
	{
		return GetNode<Timer>("Timer");
	}
}
