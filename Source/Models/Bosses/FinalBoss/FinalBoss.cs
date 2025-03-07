using System;
using Godot;
using shooter.Source.Models.Bosses.FinalBoss.States;
using Shooter.Source.Dumies.FinalBoss;
using Shooter.Source.Enums;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.FinalBoss.States;

public partial class FinalBoss : Node2D, INextStateFinalBoss
{
	private EFinalBossState _bossLevelState = EFinalBossState.TheWall;
	private IState _state;
    private int removeIdPuncher;
    private int removeIdProtector;

	public override void _Ready()
	{
        VerifyFinalPowerUp();
		GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner").ClearEnemySection();
	}

    private void VerifyFinalPowerUp()
    {
		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");

        if(!player.GetFinalPowerUp)
		{
			player.SetSizeLimit(462, 944);
            AddChild(new DFistState(this).GetInstance());
            AudioManager.SetCustonMusic("res://Assets/Songs/FinalBoss/TheWall.wav");
			return;
		}

		_bossLevelState = EFinalBossState.FinalPowerUpGetTransition;
        
        if(!GameManager.IsSpecialMode)
        {
		    FinalPowerUp.GiveFinalPowerUpStatus(player);
		    player.EmitSignal("PlayerHpUpdated", player.Hp);
        }

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
        GetTree().Root.GetNode<Player>("/root/Main/Player").ResetTargetCount();
		GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager").RemoveAllProjectiles();
		_bossLevelState += 1;

		if(_bossLevelState == EFinalBossState.FinalPowerUpGetTransition || _bossLevelState == EFinalBossState.TransitionToTimelineEight || _bossLevelState == EFinalBossState.TransitionToMothershipCore2 || _bossLevelState == EFinalBossState.TransitionToTimelineTwoFour || _bossLevelState == EFinalBossState.TransitionToAngryCore || _bossLevelState == EFinalBossState.TransitionToTimeLineEleven || _bossLevelState == EFinalBossState.TransitionToAngryCore2 || _bossLevelState == EFinalBossState.TransitionToTimelineThree || _bossLevelState == EFinalBossState.TransitionToFinalStage)
		{
			_state = new FinalPowerUpGetTransitionState(GetNode<Panel>("ParallaxBackground/PanelContainer"), AudioManager.AudioStreamPlayer);
            
            try
            {
			    removeIdPuncher = GetNode<MotherShipCore1Base>("MotherShipCore1").StopProcess();

            }catch{}

            try
            {
			    removeIdProtector = GetNode<angryCoreBase>("AngryMotherShipCore").StopProcess();

            }catch{}
		}
		else if(_bossLevelState == EFinalBossState.MothershipCore)
		{
            
            AudioManager.SetCustonMusic("res://Assets/Songs/FinalBoss/Core.wav");

            try
            {
			    GetNode("FirstState").QueueFree();
            }catch{}

            AddChild(new DMotherShipCore1(this).GetInstance());

			GetNode<Panel>("ParallaxBackground/PanelContainer").Modulate = Color.Color8(255, 255, 255, 0);

		}else if(_bossLevelState == EFinalBossState.TimelineEight)
		{
            
            AudioManager.SetCustonMusic("res://Assets/Songs/Timeline8.wav");
            GetNode<MotherShipCore1Base>("MotherShipCore1").QueueFree();
            AddChild(new DTimelineEightFinalBoss(this).GetInstance());
			
			GetNode<Panel>("ParallaxBackground/PanelContainer").Modulate = Color.Color8(255, 255, 255, 0);

		}else if(_bossLevelState == EFinalBossState.MothershipCore2)
		{
            
            AudioManager.SetCustonMusic("res://Assets/Songs/FinalBoss/Core.wav");
            AddChild(new DMotherShipCore1(this, removeIdPuncher).GetInstance());
			GetNode("TimelineEightFinalBoss").QueueFree();

			GetNode<Panel>("ParallaxBackground/PanelContainer").Modulate = Color.Color8(255, 255, 255, 0);

		}else if(_bossLevelState == EFinalBossState.TimelineTwoFour)
		{
            
            AudioManager.SetCustonMusic("res://Assets/Songs/Timeline4.wav");
            GetNode<MotherShipCore1Base>("MotherShipCore1").QueueFree();
            AddChild(new DTimelineTwoFourBoss(this).GetInstance());
			
			GetNode<Panel>("ParallaxBackground/PanelContainer").Modulate = Color.Color8(255, 255, 255, 0);
		}else if(_bossLevelState == EFinalBossState.AngryCore)
		{
            
            AudioManager.SetCustonMusic("res://Assets/Songs/FinalBoss/AngryCore.wav");
			GetNode("TimelineTwoFourBoss").QueueFree();

            AddChild(new DAngryMotherShipCore(this).GetInstance());
			GetNode<Panel>("ParallaxBackground/PanelContainer").Modulate = Color.Color8(255, 255, 255, 0);

		}else if(_bossLevelState == EFinalBossState.TimeLineEleven)
		{
            
            AudioManager.SetCustonMusic("res://Assets/Songs/Timeline7.wav");
			GetNode("AngryMotherShipCore").QueueFree();
            AddChild(new DTimelineEleven(this).GetInstance());
			
			GetNode<Panel>("ParallaxBackground/PanelContainer").Modulate = Color.Color8(255, 255, 255, 0);
		}else if(_bossLevelState == EFinalBossState.AngryCore2)
		{
            
            AudioManager.SetCustonMusic("res://Assets/Songs/FinalBoss/AngryCore.wav");
			GetNode("TimelineEleven").QueueFree();

            AddChild(new DAngryMotherShipCore(this, removeIdProtector).GetInstance());

			GetNode<Panel>("ParallaxBackground/PanelContainer").Modulate = Color.Color8(255, 255, 255, 0);

		}else if(_bossLevelState == EFinalBossState.TimelineThree)
		{
			GetNode("AngryMotherShipCore").QueueFree();
            AddChild(new DTimelineThree(this).GetInstance());
			GetNode<Panel>("ParallaxBackground/PanelContainer").Modulate = Color.Color8(255, 255, 255, 0);
		}else if(_bossLevelState == EFinalBossState.FinalStage)
		{
            
            AudioManager.SetCustonMusic("res://Assets/Songs/FinalBoss/DeseperateCore.wav");
			GetNode("Timelinethree").QueueFree();
            AddChild(new DFinalStage(this).GetInstance());
			GetNode<Panel>("ParallaxBackground/PanelContainer").Modulate = Color.Color8(255, 255, 255, 0);
		}else if(_bossLevelState == EFinalBossState.EndingTransition)
		{
			_state = new FinalTransitionState(GetTree().Root.GetNode<Player>("/root/Main/Player"), GetNode<Panel>("ParallaxBackground/PanelContainer"));
		}
        
        EnemySpawner.GetEnemySpawner().RemoveAllExplosions();
	}
}