using Godot;
using System;

public partial class BackgroundLevelTwo : Node2D, IBackground
{
    private int _time;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
		var paralax = GetNode<ParallaxLayer>("ParallaxBackground/ParallaxLayer3");

		paralax.MotionOffset = new Vector2(
    		x: paralax.MotionOffset.X + 0.5f,
    		y: paralax.MotionOffset.Y + 1
		);
		
		if(_time % 10 == 0)
		{
			var scene = GD.Load<PackedScene>("res://Scenes/Background/Ball.tscn");

        	var instance = (Ball)scene.Instantiate();

			AddChild(instance);
		}
		
		_time++;

	}

    public void PauseBackground(bool isPaused)
    {
		foreach(var efect in GetChildren())
		{
			efect.SetProcess(!isPaused);
		}

		SetProcess(!isPaused);
    }
}