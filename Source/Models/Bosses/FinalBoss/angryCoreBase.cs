using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.SpaceshipPredador;
using System;

public partial class angryCoreBase : Node2D
{
	private IState _state;
	private Node2D _destroingNode;
    private int _protectorIdDestroyed;
    private INextStateFinalBoss _nextState;

	public override void _Process(double delta)
	{
		if(_state is null)
			return;
			
		if(_state.Process())
		{
			_state = _state.NextState();
			_destroingNode.CallDeferred("queue_free");
		}
	}

	public void OnProtectorDestoyed(Node2D node)
	{
		_state = new Exploding(node, removeEnemy: false);
		_destroingNode = node;
        _protectorIdDestroyed = ((CoreProtector)node).Id;

        GetNode<MothershipCoreFirstState>("CharacterBody2D").Disable();
        _nextState.OnNextState();
	}

    public void AddNextState(INextStateFinalBoss nextState)
    {
        _nextState = nextState;
    }

    public int StopProcess()
    {
        return _protectorIdDestroyed;
    }

    public void RemoveProtector(int removeProtectorId)
    {
        if(removeProtectorId == 0)
            return;
        
        if(removeProtectorId == 1)
        {
            GetNode("CharacterBody2D2").CallDeferred("queue_free");
        }else if(removeProtectorId == 2)
        {
            GetNode("CharacterBody2D3").CallDeferred("queue_free");
        }
    }

}