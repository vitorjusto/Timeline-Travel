using Godot;
using Shooter.Source.Models.Misc;

public partial class BackgroundLevelTwo : Node2D, IBackground
{
    private readonly QuickTimer _timer = new(10);
	public override void _Process(double delta)
	{
		var paralax = GetNode<ParallaxLayer>("ParallaxBackground/ParallaxLayer3");

		paralax.MotionOffset = new Vector2(
    		x: paralax.MotionOffset.X + (0.5f * (float)(delta * 60)),
    		y: paralax.MotionOffset.Y + (1 * (float)(delta * 60))
		);
		
		if(_timer.Process(delta))
		{
			var scene = GD.Load<PackedScene>("res://Scenes/Background/Ball.tscn");

        	var instance = (Ball)scene.Instantiate();

			AddChild(instance);
		}
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