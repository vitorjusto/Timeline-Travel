using Godot;
using System;

public partial class TimelineEleven : Node2D
{
	private int _timer;
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		if(_timer == 200)
		{
			GetNode<Label>("Label").Visible = false;
			return;
		}

		if(_timer % 10 == 0)
			GetNode<Label>("Label").Visible = !GetNode<Label>("Label").Visible;

		_timer++;
	}

	[Signal]
	public delegate void OnNextStageEventHandler();

	public void OnBossDestroyed()
	{
		EmitSignal("OnNextStage");
	}
}
