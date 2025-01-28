using Godot;

public partial class FirstStateBase : Node2D 
{
    private INextStateFinalBoss _nextState;
    private bool _powerUpDropped;

    public void OnFinalPowerUpGet()
	{
		_nextState.OnNextState();
	}

	public void OnWallEntered()
	{
		GetNode<MovingParallaxLayer>("ParallaxBackground/MovingParallaxLayer3").YSpeed = 0;
	}

    internal void SetNextState(INextStateFinalBoss nextState)
    {
        _nextState = nextState;
    }
}
