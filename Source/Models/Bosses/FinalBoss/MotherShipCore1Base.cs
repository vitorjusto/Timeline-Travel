using System;
using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.SpaceshipPredador;

public partial class MotherShipCore1Base : Node2D, IDisableNotifier
{
	private IState _state; 
	private Node2D _destroingNode;
	private bool _nextStateCalled;
	
	public override void _Process(double delta)
	{
		if(_state is null)
		{
			_nextStateCalled = false;
			return;
		}

		if(!_nextStateCalled)
		{
			EmitSignal("OnNextState");
			_nextStateCalled = true;
		}

		_state.Process();
	}

	public void OnPuncherDestroing(Node2D node)
	{
		_state = new Exploding(node, removeEnemy: true);
		node.SetProcess(false);
		_destroingNode = node;
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

    public void StopProcess()
    {
        GetNode<MothershipCoreFirstState>("CharacterBody2D").Disable();
        GetNode<MothershipCore1>("CharacterBody2D2").Disable();
        GetNode<MothershipCore1>("CharacterBody2D3").Disable();
    }

	public void StartProcess()
    {
        GetNode<MothershipCoreFirstState>("CharacterBody2D").Enable();
        GetNode<MothershipCore1>("CharacterBody2D2").Enable();
        GetNode<MothershipCore1>("CharacterBody2D3").Enable();
    }

    [Signal]
	public delegate void OnNextStateEventHandler();
}
