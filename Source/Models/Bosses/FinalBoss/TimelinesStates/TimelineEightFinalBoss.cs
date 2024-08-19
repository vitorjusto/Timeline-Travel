using System;
using System.Collections.Generic;
using Godot;
using Shooter.Source.Dumies.Enemies;
using Shooter.Source.Enums;
using Shooter.Source.Models.Levels;

public partial class TimelineEightFinalBoss : Node2D
{
    private Label _lblTimeline;
	private int _timer;
    private EnemySpawner _enemyManager;

    public override void _Ready()
	{
		_lblTimeline = GetNode<Label>("lblTimeline");
        _enemyManager = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
	}

	public override void _Process(double delta)
	{


		if(_timer == 200)
		{
			if(_enemyManager.EnemiesSectionEmpty)
			{
				EmitSignal("OnNextState");
				SetProcess(false);
			}
			
			return;
		}

		_timer++;
			
		if(_timer < 200)
		{
			if(_timer % 10 == 0)
				_lblTimeline.Visible = !_lblTimeline.Visible;
		}else
		{
			AddEnemies();
		}
	}

    private void AddEnemies()
    {
		var enemies = new List<EnemySection>()
            {

                new(100, false, new DLazer(700, 150)),
                new(100, false, new DLazer(600, 1400), new DLazer(500, 1400), new DLazer(800, 1400), new DLazer(900, 1400)),

                new(60, false, new DBlackHole(700, false, 3)),
                new(60, false, new DBlackHole(700, false, 3)),
                new(60, false, new DBlackHole(700, false, 3)),
                new(60, false, new DBlackHole(700, false, 3)),
                new(60, false, new DBlackHole(700, false, 3)),
                new(150, false, new DBlackHole(700, false, 3)),

                new(200, false, new DShoter(300, EEnemyProjectileType.Normal), new DShoter(1200, EEnemyProjectileType.Normal), new DBlackHole(700, false, 3)),
                new(150, false, new DBlackHole(700, false, 3)),
                new(70, false, new DBlackHole(700, false, 3), new DSniper(100, EEnemyProjectileType.Strong), new DSniper(1300, EEnemyProjectileType.Strong)),
                new(70, false, new DBlackHole(700, false, 3), new DSniper(100, EEnemyProjectileType.Strong), new DSniper(1300, EEnemyProjectileType.Strong)),
                new(70, true, new DBlackHole(700, false, 3), new DSniper(100, EEnemyProjectileType.Strong), new DSniper(1300, EEnemyProjectileType.Strong)),

                new(200, false, new DBlackHole(700, false, 4)),
                new(10, false, new DFollower(10, EEnemyProjectileType.Light)),
                new(10, false, new DFollower(10, EEnemyProjectileType.Light)),
                new(10, false, new DFollower(10, EEnemyProjectileType.Light)),

                new(200, false, new DBlackHole(400, false, 4), new DBlackHole(1000, false, 4)),
                new(10, false, new DFollower(1390, EEnemyProjectileType.Light)),
                new(10, false, new DFollower(1390, EEnemyProjectileType.Light)),
                new(10, false, new DFollower(1390, EEnemyProjectileType.Light)),

                new(200, false, new DBlackHole(700, false, 4), new DBlackHole(100, false, 4), new DBlackHole(1300, false, 4)),
                new(10, false, new DFollower(10, EEnemyProjectileType.Light)),
                new(10, false, new DFollower(10, EEnemyProjectileType.Light)),
                new(10, false, new DFollower(10, EEnemyProjectileType.Light)),

                new(200, false, new DBlackHole(400, false, 4), new DBlackHole(1000, false, 4), new DBlackHole(100, false, 4), new DBlackHole(1300, false, 4)),
                new(10, false, new DFollower(1390, EEnemyProjectileType.Light)),
                new(10, false, new DFollower(1390, EEnemyProjectileType.Light)),
                new(10, true, new DFollower(1390, EEnemyProjectileType.Light)),

                new(40, false, new DCommon(700, 3)),
                new(40, false, new DCommon(700, 3), new DCommon(600, 3), new DCommon(800, 3)),
                new(40, false, new DCommon(700, 3), new DCommon(600, 3), new DCommon(800, 3), new DCommon(500, 3), new DCommon(900, 3)),
                new(40, false, new DSpread(700, EEnemyProjectileType.Normal ,3), new DCommon(600, 3), new DCommon(800, 3), new DCommon(500, 3), new DCommon(900, 3), new DCommon(400, 3), new DCommon(1000, 3)),
                new(40, false, new DBlackHole(700, false, 3), new DSpread(600, EEnemyProjectileType.Normal ,3), new DSpread(800, EEnemyProjectileType.Normal ,3), new DCommon(500, 3), new DCommon(900, 3), new DCommon(400, 3), new DCommon(1000, 3), new DCommon(300, 3), new DCommon(1100, 3)),
                new(40, false, new DSpread(700, EEnemyProjectileType.Normal ,3), new DCommon(600, 3), new DCommon(800, 3), new DCommon(500, 3), new DCommon(900, 3), new DCommon(400, 3), new DCommon(1000, 3)),
                new(40, false, new DCommon(700, 3), new DCommon(600, 3), new DCommon(800, 3), new DCommon(500, 3), new DCommon(900, 3)),
                new(40, false, new DCommon(700, 3), new DCommon(600, 3), new DCommon(800, 3)),
                new(40, true, new DCommon(700, 3)),


                new(40, false, new DBlackHole(700, true, 4)),
                new(40, false, new DSpread(1300, EEnemyProjectileType.Normal, 4)),
                new(40, false, new DSpread(100, EEnemyProjectileType.Normal, 4)),

                new(40, false, new DSpread(1300, EEnemyProjectileType.Normal, 4)),
                new(40, false, new DSpread(1300, EEnemyProjectileType.Normal, 4), new DSpread(1200, EEnemyProjectileType.Normal, 4)),
                new(40, false, new DSpread(1300, EEnemyProjectileType.Normal, 4)),

                new(40, false, new DBlackHole(700, true, 4)),
                new(40, false, new DSpread(100, EEnemyProjectileType.Normal, 4)),
                new(40, false, new DSpread(100, EEnemyProjectileType.Normal, 4), new DSpread(200, EEnemyProjectileType.Normal, 4)),
                new(40, true, new DSpread(100, EEnemyProjectileType.Normal, 4)),    
            };

		_enemyManager.AddEnemySection(enemies);
		_enemyManager.GetNextSection();
    }


	[Signal]
	public delegate void OnNextStateEventHandler();
}
