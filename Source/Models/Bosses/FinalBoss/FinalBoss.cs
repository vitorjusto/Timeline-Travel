using System;
using Godot;
using shooter.Source.Models.Bosses.FinalBoss.States;
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
		DisableNodeHelpers.DisableNodeIncludingChildren(GetNode("TimelineEightFinalBoss"));
		DisableNodeHelpers.DisableNodeIncludingChildren(GetNode("TimelineTwoFourBoss"));
		DisableNodeHelpers.DisableNodeIncludingChildren(GetNode("AngryMotherShipCore"));
		DisableNodeHelpers.DisableNodeIncludingChildren(GetNode("TimelineEleven"));
		DisableNodeHelpers.DisableNodeIncludingChildren(GetNode("Timelinethree"));
		DisableNodeHelpers.DisableNodeIncludingChildren(GetNode("FinalStage"));

        VerifyFinalPowerUp();
	}

    private void VerifyFinalPowerUp()
    {
		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");

        if(!player.GetFinalPowerUp)
		{
			player.SetSizeLimit(462, 944);
			return;
		}

		_bossLevelState = EFinalBossState.FinalPowerUpGetTransition;
		FinalPowerUp.GiveFinalPowerUpStatus(player);
		player.EmitSignal("PlayerHpUpdated", player.Hp);
		OnNextState();
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

		if(_bossLevelState == EFinalBossState.FinalPowerUpGetTransition || _bossLevelState == EFinalBossState.TransitionToTimelineEight || _bossLevelState == EFinalBossState.TransitionToMothershipCore2 || _bossLevelState == EFinalBossState.TransitionToTimelineTwoFour || _bossLevelState == EFinalBossState.TransitionToAngryCore || _bossLevelState == EFinalBossState.TransitionToTimeLineEleven || _bossLevelState == EFinalBossState.TransitionToAngryCore2 || _bossLevelState == EFinalBossState.TransitionToTimelineThree || _bossLevelState == EFinalBossState.TransitionToFinalStage)
		{
			_state = new FinalPowerUpGetTransitionState(GetNode<Panel>("ParallaxBackground/PanelContainer"));
			GetNode<MotherShipCore1Base>("MotherShipCore1").StopProcess();
		}
		else if(_bossLevelState == EFinalBossState.MothershipCore)
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
			GetNode<MotherShipCore1Base>("MotherShipCore1").StartProcess();
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

		}else if(_bossLevelState == EFinalBossState.TimelineThree)
		{
			GetNode("AngryMotherShipCore").QueueFree();
			DisableNodeHelpers.EnableNodeIncludingChildren(GetNode("Timelinethree"));
			GetNode<Panel>("ParallaxBackground/PanelContainer").Modulate = Color.Color8(255, 255, 255, 0);
		}else if(_bossLevelState == EFinalBossState.FinalStage)
		{
			GetNode("Timelinethree").QueueFree();
			DisableNodeHelpers.EnableNodeIncludingChildren(GetNode("FinalStage"));
			GetNode<Panel>("ParallaxBackground/PanelContainer").Modulate = Color.Color8(255, 255, 255, 0);
		}else if(_bossLevelState == EFinalBossState.EndingTransition)
		{
			_state = new FinalTransitionState(GetTree().Root.GetNode<Player>("/root/Main/Player"), GetNode<Panel>("ParallaxBackground/PanelContainer"));
		}
	}
}
