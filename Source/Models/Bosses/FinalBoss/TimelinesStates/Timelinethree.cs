using Godot;
using System;

public partial class Timelinethree : Node2D
{
	private int _timer = 0;
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		_timer++;
		if(_timer == 20)
			EmitSignal("OnNextStage");

		
		if(_timer % 10 == 0)
			GetNode<Label>("Label").Visible = !GetNode<Label>("Label").Visible;
	}

	[Signal]
	public delegate void OnNextStageEventHandler();
}
