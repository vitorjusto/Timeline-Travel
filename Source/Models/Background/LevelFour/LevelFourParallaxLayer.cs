using Godot;
using System;

public partial class LevelFourParallaxLayer : ParallaxLayer
{
	[Export]
	public int Speed = 2;
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		this.MotionOffset = new Vector2(
    		x: 0,
    		y: this.MotionOffset.Y + Speed
		);
	}
}
