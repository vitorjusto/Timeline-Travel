using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.SpaceshipPredador;
using System;

public partial class angryCoreBase : Node2D
{
	private IState _state;
	private Node2D _destroingNode;
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		if(_state is null)
			return;
			
		if(_state.Process())
		{
			EmitSignal("OnNextStage");
			_state = _state.NextState();
			_destroingNode.CallDeferred("queue_free");
		}
	}

	public void OnProtectorDestoyed(Node2D node)
	{
		_state = new Exploding(node, removeEnemy: false);
		_destroingNode = node;

        GetNode<MothershipCoreFirstState>("CharacterBody2D").Disable();
	}

    public void EnableCore()
    {
		try
		{
        	GetNode<CoreProtector>("CharacterBody2D2").EnableProtector();

		}catch(Exception){ }

		try
		{
        	GetNode<CoreProtector>("CharacterBody2D3").EnableProtector();

		}catch(Exception){ }

        GetNode<MothershipCoreFirstState>("CharacterBody2D").Enable();
    }

    [Signal]
	public delegate void OnNextStageEventHandler();
}
