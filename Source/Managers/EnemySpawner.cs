using System.Security.AccessControl;
using Godot;
using Shooter.Source.Dumies.Enemies;
using System;
using System.Collections.Generic;
using Shooter.Source.Models.Levels;
using Shooter.Source.Factories.Levels;
using Shooter.Source.Dumies.Interfaces;
using System.Linq;
using Shooter.Source.Factories.Bosses;

public partial class EnemySpawner : Node2D
{
	private int _time;
	private int _timeSection;

	private bool _waitForEveryEnemy = false;
	public List<Node2D> Enemies;
	private List<EnemySection> _enemySection;
	public int CurrentLevel = 1;

	public bool BossApeared = false;
	public override void _Ready()
	{
		_enemySection = EnemiesLevelOne.GetEnemies();
		Enemies = new List<Node2D>();
		GetNextSection();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		VerifyEnemySection();
	}

	private void VerifyEnemySection()
	{
		if(_waitForEveryEnemy)
		{
			if(Enemies.Count == 0)
				GetNextSection();
		}
		else if(_time == _timeSection)
		{
			GetNextSection();
		}
		_time++;
	}

	private void GetNextSection()
	{
		if(!_enemySection.Any())
		{
			return;
		}

		var currentSection = _enemySection.First();
		_enemySection.RemoveAt(0);

		_timeSection = currentSection.Time;
		_time = 0;

		_waitForEveryEnemy = currentSection.WaitForEveryEnemy;

		foreach(IEnemyDummy enemy in currentSection.Enemies)
		{
			AddEnemy(enemy);
		}
	}

	private void GetBoss()
	{
		CallDeferred("add_child", BossFactory.GetBoss(CurrentLevel));
		BossApeared = true;
	}

	public void PlayerHitEnemy(Node2D node)
	{
		RemoveEnemy(node);
	}

	public void RemoveEnemy(Node2D node)
	{
		Enemies.Remove(node);

		node.QueueFree();

		if(Enemies.Count == 0 && !_enemySection.Any())
			GetBoss();
	}

	public void AddEnemy(IEnemyDummy enemy)
	{
		var node = enemy.GetInstance();

		Enemies.Add(node);
		CallDeferred("add_child", node);
	}
}
