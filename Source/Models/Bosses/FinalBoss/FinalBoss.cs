using Godot;
using Shooter.Source.Enums;
using Shooter.Source.Helpers;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.FinalBoss.States;

public partial class FinalBoss : Node2D
{
	private EFinalBossState _bossLevelState = EFinalBossState.TheWall;
	private IState _state;

	public override void _Ready()
	{
		DisableNodeHelpers.DisableNodeIncludingChildren(GetNode("MotherShipCore1"));
	}

	public override void _Process(double delta)
	{
		if(_state is null)
			return;
		
		if(_state.Process())
		{
			_state = _state.NextState();

			if(_state is null)
				OnNextState();
		}
	}

	public void OnNextState()
	{
		_bossLevelState += 1;

		if(_bossLevelState == EFinalBossState.FinalPowerUpGetTransition)
			_state = new FinalPowerUpGetTransitionState(GetNode<Panel>("PanelContainer"));
		if(_bossLevelState == EFinalBossState.MothershipCore)
		{
			GetNode("FirstState").QueueFree();
			DisableNodeHelpers.EnableNodeIncludingChildren(GetNode("MotherShipCore1"));
			GetNode<Node2D>("MotherShipCore1").Visible = true;
			GetNode<Panel>("PanelContainer").Modulate = Color.Color8(255, 255, 255, 0);
		}
	}
}
