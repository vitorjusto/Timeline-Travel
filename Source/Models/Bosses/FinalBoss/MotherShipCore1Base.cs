using System;
using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.SpaceshipPredador;

public partial class MotherShipCore1Base : Node2D, IDisableNotifier
{
	private IState _state; 
	private Node2D _destroingNode;
	private bool _nextStateCalled;
    private int _destroyedPuncherId;
    private INextStateFinalBoss _nextState;
	
	public override void _Process(double delta)
	{
		if(_state is null)
		{
			_nextStateCalled = false;
			return;
		}

		if(!_nextStateCalled)
		{
            _nextState.OnNextState();
			_nextStateCalled = true;
		}

		_state.Process();
	}

	public void OnPuncherDestroing(Node2D node)
	{
		_state = new Exploding(node, removeEnemy: true);
		node.SetProcess(false);
		_destroingNode = node;
        _destroyedPuncherId = ((MothershipCorePuncher)node).Id;
	}

    public void OnDisable()
    {
		if(_destroingNode is null)
			return;

        _state = null;
		_destroingNode.QueueFree();
		_destroingNode = null;

		GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner").RemoveAllExplosions();
    }

    public int StopProcess()
    {
		GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager").RemoveAllProjectiles();

        GetNode<MothershipCoreFirstState>("CharacterBody2D").Disable();
        GetNode<MothershipCore1>("CharacterBody2D2").Disable();
        GetNode<MothershipCore1>("CharacterBody2D3").Disable();

        return _destroyedPuncherId;
    }

	public void StartProcess()
    {
        GetNode<MothershipCoreFirstState>("CharacterBody2D").Enable();
        GetNode<MothershipCore1>("CharacterBody2D2").Enable();
        GetNode<MothershipCore1>("CharacterBody2D3").Enable();
    }

    public void RemovePuncher(int removePuncherId)
    {
        if(removePuncherId == 0)
            return;

        GetNode<MothershipCoreFirstState>("CharacterBody2D").EnterOnFinalPosition();
        
        GetNode<MothershipCore1>("CharacterBody2D2").EnterOnFinalPosition();
        GetNode<MothershipCore1>("CharacterBody2D3").EnterOnFinalPosition();

        if(removePuncherId == 1)
        {
            GetNode<MothershipCorePuncher>("CharacterBody2D4").CallDeferred("queue_free");
            GetNode<MothershipCorePuncher>("CharacterBody2D6").EnterOnFinalPosition();
        }
        else if(removePuncherId == 2)
        {
            GetNode<MothershipCorePuncher>("CharacterBody2D6").CallDeferred("queue_free");
            GetNode<MothershipCorePuncher>("CharacterBody2D4").EnterOnFinalPosition();
        }
    }

    public void AddNextState(INextStateFinalBoss nextState)
    {
        _nextState = nextState;
    }
}