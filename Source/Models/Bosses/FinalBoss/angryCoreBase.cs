using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.SpaceshipPredador;
using System;

public partial class angryCoreBase : Node2D
{
	private IState _state;
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
		}
	}

	public void OnProtectorDestoyed(Node2D node)
	{
		_state = new Exploding(node, removeEnemy: false);
	}

	[Signal]
	public delegate void OnNextStageEventHandler();
}
