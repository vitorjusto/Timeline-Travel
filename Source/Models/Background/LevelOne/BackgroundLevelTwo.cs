using Godot;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Background.LevelOne;
public partial class BackgroundLevelTwo : Node2D, IBackground
{
    private readonly QuickTimer _timer = new(10);
	private PackedScene _scene;

	public override void _Ready()
		=> _scene = GD.Load<PackedScene>("res://Scenes/Background/Ball.tscn");

	public override void _Process(double delta)
	{
		var paralax = GetNode<ParallaxLayer>("ParallaxBackground/ParallaxLayer3");

		paralax.MotionOffset = new Vector2(
    		x: paralax.MotionOffset.X + 0.5f * (float)(delta * 60),
    		y: paralax.MotionOffset.Y + 1 * (float)(delta * 60)
		);
		
		if(_timer.Process(delta))
		{

        	var instance = (Ball)_scene.Instantiate();

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