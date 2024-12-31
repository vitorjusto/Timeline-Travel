using Godot;
using System;

public partial class TimelineEleven : Node2D
{
	private int _timer;
    private INextStateFinalBoss _nextState;

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

	public void OnBossDestroyed()
	{
		_nextState.OnNextState();
	}

    internal void SetNextState(INextStateFinalBoss nextState)
    {
        _nextState = nextState;
    }
}
