using Godot;
using Shooter.Source.Enums;
using Shooter.Source.Helpers;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.FinalBoss.States;

public partial class FinalBoss : Node2D
{
	private EFinalBossState _bossLevelState = EFinalBossState.AngryCore;
	private IState _state;

	public override void _Ready()
	{
		DisableNodeHelpers.DisableNodeIncludingChildren(GetNode("MotherShipCore1"));
		DisableNodeHelpers.DisableNodeIncludingChildren(GetNode("TimelineEightFinalBoss"));
		DisableNodeHelpers.DisableNodeIncludingChildren(GetNode("TimelineTwoFourBoss"));
		DisableNodeHelpers.DisableNodeIncludingChildren(GetNode("AngryMotherShipCore"));
		DisableNodeHelpers.DisableNodeIncludingChildren(GetNode("TimelineEleven"));
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

		if(_bossLevelState == EFinalBossState.FinalPowerUpGetTransition || _bossLevelState == EFinalBossState.TransitionToTimelineEight || _bossLevelState == EFinalBossState.TransitionToMothershipCore2 || _bossLevelState == EFinalBossState.TransitionToTimelineTwoFour || _bossLevelState == EFinalBossState.TransitionToAngryCore || _bossLevelState == EFinalBossState.TransitionToTimeLineEleven || _bossLevelState == EFinalBossState.TransitionToAngryCore2)
			_state = new FinalPowerUpGetTransitionState(GetNode<Panel>("ParallaxBackground/PanelContainer"));
		if(_bossLevelState == EFinalBossState.MothershipCore)
		{
			GetNode("FirstState").QueueFree();
			DisableNodeHelpers.EnableNodeIncludingChildren(GetNode("MotherShipCore1"));
			GetNode<Node2D>("MotherShipCore1").Visible = true;
			GetNode<Panel>("ParallaxBackground/PanelContainer").Modulate = Color.Color8(255, 255, 255, 0);

		}else if(_bossLevelState == EFinalBossState.TimelineEight)
		{
			DisableNodeHelpers.DisableNodeIncludingChildren(GetNode("MotherShipCore1"));
			DisableNodeHelpers.EnableNodeIncludingChildren(GetNode("TimelineEightFinalBoss"));
			
			GetNode<Panel>("ParallaxBackground/PanelContainer").Modulate = Color.Color8(255, 255, 255, 0);

		}else if(_bossLevelState == EFinalBossState.MothershipCore2)
		{
			GetNode("TimelineEightFinalBoss").QueueFree();

			DisableNodeHelpers.EnableNodeIncludingChildren(GetNode("MotherShipCore1"));
			GetNode<Node2D>("MotherShipCore1").Visible = true;
			GetNode<Panel>("ParallaxBackground/PanelContainer").Modulate = Color.Color8(255, 255, 255, 0);

		}else if(_bossLevelState == EFinalBossState.TimelineTwoFour)
		{
			DisableNodeHelpers.DisableNodeIncludingChildren(GetNode("MotherShipCore1"));
			DisableNodeHelpers.EnableNodeIncludingChildren(GetNode("TimelineTwoFourBoss"));
			
			GetNode<Panel>("ParallaxBackground/PanelContainer").Modulate = Color.Color8(255, 255, 255, 0);
		}else if(_bossLevelState == EFinalBossState.AngryCore)
		{
			GetNode("TimelineTwoFourBoss").QueueFree();

			DisableNodeHelpers.EnableNodeIncludingChildren(GetNode("AngryMotherShipCore"));
			GetNode<Node2D>("AngryMotherShipCore").Visible = true;
			GetNode<Panel>("ParallaxBackground/PanelContainer").Modulate = Color.Color8(255, 255, 255, 0);

		}else if(_bossLevelState == EFinalBossState.TimeLineEleven)
		{
			DisableNodeHelpers.DisableNodeIncludingChildren(GetNode("AngryMotherShipCore"));
			DisableNodeHelpers.EnableNodeIncludingChildren(GetNode("TimelineEleven"));
			
			GetNode<Panel>("ParallaxBackground/PanelContainer").Modulate = Color.Color8(255, 255, 255, 0);
		}else if(_bossLevelState == EFinalBossState.AngryCore2)
		{
			GetNode("TimelineEleven").QueueFree();

			DisableNodeHelpers.EnableNodeIncludingChildren(GetNode("AngryMotherShipCore"));
			GetNode<Node2D>("AngryMotherShipCore").Visible = true;
			GetNode<Panel>("ParallaxBackground/PanelContainer").Modulate = Color.Color8(255, 255, 255, 0);

		}
	}
}
