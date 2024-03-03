using Godot;
using System;

public partial class BackgroundLevelFive : Node2D, IBackground
{
    private ParallaxLayer _parallaxLayer;
    private AnimationPlayer _animationPlayer;

    public override void _Ready()
	{
		_parallaxLayer = GetNode<ParallaxLayer>("ParallaxBackground/ParallaxLayer");
		_animationPlayer = GetNode<AnimationPlayer>("ParallaxBackground/ParallaxLayer/CanvasModulate/AnimationPlayer");
		_animationPlayer.Play("new_animation");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_parallaxLayer.MotionOffset = new Vector2(
    		x: 0,
    		y: _parallaxLayer.MotionOffset.Y + 2
		);

	}

    public void PauseBackground(bool isPaused)
    {
        SetProcess(!isPaused);
    }

}
