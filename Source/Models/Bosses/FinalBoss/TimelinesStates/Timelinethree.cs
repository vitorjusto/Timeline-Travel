using Godot;
using System;

public partial class Timelinethree : Node2D
{
	private int _timer = 0;
    private INextStateFinalBoss _nextState;

    public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		_timer++;
		if(_timer == 20)
            _nextState.OnNextState();

		if(_timer % 10 == 0)
			GetNode<Label>("Label").Visible = !GetNode<Label>("Label").Visible;
	}

    public void SetNextState(INextStateFinalBoss nextState)
    {
        _nextState = nextState;
    }
}
