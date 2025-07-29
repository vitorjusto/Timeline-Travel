using Godot;
using Shooter.Source.Models.Misc;
using System;

public partial class Timelinethree : Node2D
{
	private readonly QuickTimer _timer = new(20);
	private readonly QuickTimer _labelTimer = new(10);
    private INextStateFinalBoss _nextState;
    private bool _calledNextStage;

    public override void _Process(double delta)
    {
        if (!_calledNextStage && _timer.Process(delta))
        {
            _nextState.OnNextState();
            _calledNextStage = true;
        }

		if(_labelTimer.Process(delta))
			GetNode<Label>("Label").Visible = !GetNode<Label>("Label").Visible;
	}

    public void SetNextState(INextStateFinalBoss nextState)
    {
        _nextState = nextState;
    }
}
