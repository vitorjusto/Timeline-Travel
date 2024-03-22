using System;
using Godot;

public partial class SeasoningAdpter : Node2D
{
	private int _time = 0;
    private BackgroundLevelSeven _background;
    private Timer _timer;
    private Node2D _cope;

    public override void _Ready()
	{
		var backgroundManager = GetTree().Root.GetNode<BackgroundManager>("/root/Main/BackgroundManager");
		_background = (BackgroundLevelSeven)backgroundManager.GetBackground();

		_timer = _background.GetTimer();
		var time = Math.Abs(_timer.TimeLeft - 40);

		var animationPlayer = GetNode<AnimationPlayer>("ParallaxBackground/CanvasModulate/AnimationPlayer");
		animationPlayer.Seek(time, true);

		_cope = GetNode<Node2D>("ParallaxBackground/Cope");
	}

	public override void _Process(double delta)
	{
		if(_time < 20)
			_cope.Position = new Vector2(_cope.Position.X, _cope.Position.Y + 15);
		else if(_time == 20)
			_background.StopBackground();
		
		_time++;
	}
}
