using Godot;
using Shooter.Source.Models.Misc;
using System;

public partial class TimelineEleven : Node2D
{
	private QuickTimer _timer = new(200);
	private QuickTimer _labelTimer = new(10);
    private INextStateFinalBoss _nextState;
    private bool _labelDisposed;

    public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
        if(_labelDisposed)
            return;

        if(_timer.Process(delta))
		{
			GetNode<Label>("Label").Visible = false;
			_labelDisposed = true;
            return;
		}

		if(_labelTimer.Process(delta))
			GetNode<Label>("Label").Visible = !GetNode<Label>("Label").Visible;
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
