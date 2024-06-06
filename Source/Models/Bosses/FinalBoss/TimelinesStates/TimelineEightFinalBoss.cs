using System;
using System.Collections.Generic;
using Godot;
using Shooter.Source.Dumies.Enemies;
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
                new EnemySection(10, false, new DOrbiter()),
                new EnemySection(50, true, new DOrbiter()),
            };

		_enemyManager.AddEnemySection(enemies);
		_enemyManager.GetNextSection();
    }


	[Signal]
	public delegate void OnNextStateEventHandler();
}
