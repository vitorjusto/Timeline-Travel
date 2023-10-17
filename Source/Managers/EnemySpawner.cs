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
    private bool _endingLevel;
	private bool _startingLevel;
	private bool _showingWarningBoss;
    private Node2D _boss;
	private GameManager _gameManager;
	
    public override void _Ready()
	{
		Enemies = new List<Node2D>();
		StartLevel();

		_gameManager = GetTree().Root.GetNode<GameManager>("/root/Main");
	}

	public void StartLevel()
	{
		_time = 0;
		_startingLevel = true;
		var hud = GetTree().Root.GetNode<Hud>("/root/Main/Hud");

		hud.ShowTimelineLabel(CurrentLevel);

		GetEnemyLevel();

	}

    private void GetEnemyLevel()
    {
        if(CurrentLevel == 1)
			_enemySection = EnemiesLevelOne.GetEnemies();
    }


    private void EndingLevelAnimation()
    {
        var player = GetTree().Root.GetNode<Player>("/root/Main/Player");

		player.SetSpeed(0, -player.Speed, -100);

		if(_time > 200)
		{
			_endingLevel = false;
			EmitSignal("LevelEnded");
		}
		
		_time++;
    }

	[Signal]
	public delegate void LevelEndedEventHandler();

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
		if(_gameManager.IsBlackScreen)
			return;

		if(_startingLevel)
			WaitForTimelineLabel();
		else if(_showingWarningBoss)
			ShowWarningBoss();
		else if(_endingLevel)
			EndingLevelAnimation();
		else
			VerifyEnemySection();
	}

    private void WaitForTimelineLabel()
    {
        _time++;

		if(_time == 200)
		{
			_startingLevel = false;
			_time = 0;
			GetNextSection();
		}
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
		_boss = BossFactory.GetBoss(CurrentLevel);

		CallDeferred("add_child", _boss);
		BossApeared = true;
	}

	public void PlayerHitEnemy(Node2D node)
	{
		RemoveEnemy(node);
	}

	public void RemoveEnemy(Node2D node)
	{
		Enemies.Remove(node);

		AddExplosion(node.Position.X, node.Position.Y);

		node.QueueFree();

		if(Enemies.Count == 0 && !_enemySection.Any() && !BossApeared  && !_endingLevel)
		{
			var hud = GetTree().Root.GetNode<Hud>("/root/Main/Hud");

			_showingWarningBoss = true;
			hud.ShowWarningBoss();
			_time = 0;
		}
	}

    private void ShowWarningBoss()
    {
        _time++;
		if(_time == 200)
		{
			_showingWarningBoss = false;
			_time = 0;
			GetBoss();
		}
    }


    public void AddExplosion(float x, float y)
    {
        var scene = GD.Load<PackedScene>("res://Scenes/Misc/Explosion.tscn");
        var instance = (Explosion)scene.Instantiate();
		instance.Position = new Vector2(x, y);

		CallDeferred("add_child", instance);
    }

    public void AddEnemy(IEnemyDummy enemy)
	{
		var node = enemy.GetInstance();

		Enemies.Add(node);
		CallDeferred("add_child", node);
	}

	public void RemoveAllEnemies()
	{
		while(Enemies.Count > 0)
		{
			RemoveEnemy(Enemies[0]);
		}
	}

	[Signal]
	public delegate void EndingLevelEventHandler();

    internal void EndLevel()
    {
		_endingLevel = true;
        EmitSignal("EndingLevel");
		_time = 0;

		BossApeared = false;
		_boss = null;
    }

    public void RestartLevel()
    {
		_time = 0;
        while(Enemies.Count > 0)
		{
			Enemies[0].QueueFree();
			Enemies.RemoveAt(0);
		}
		
		if(BossApeared)
		{
			_boss.QueueFree();
			_boss = null;
			BossApeared = false;
		}

    }
	
	public void OnGamePaused(bool isPaused)
	{
		foreach(var enemy in GetChildren())
		{
			enemy.SetProcess(!isPaused);
		}

		SetProcess(!isPaused);
	}

}
