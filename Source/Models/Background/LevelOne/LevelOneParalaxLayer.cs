using Godot;
using System;

public partial class LevelOneParalaxLayer : ParallaxLayer
{

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		this.MotionOffset = new Vector2(
    		x: 0,
    		y: this.MotionOffset.Y + 2
		);

	}
}
