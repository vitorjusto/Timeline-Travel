using Godot;
using System.Collections.Generic;
using Shooter.Source.Models.Levels;
using Shooter.Source.Factories.Levels;
using Shooter.Source.Dumies.Interfaces;
using System.Linq;
using Shooter.Source.Factories.Bosses;
using Shooter.Source.Factories.Enemies;
using Shooter.Source.Interfaces;

public partial class EnemySpawner : Node2D
{
	private int _time;
	private int _timeSection;

	private bool _waitForEveryEnemy = false;
	public List<Node2D> Enemies;
	private List<EnemySection> _enemySection;

	public bool EnemiesSectionEmpty => !_enemySection.Any() && !Enemies.Any();
	public int CurrentLevel = 10;
	public bool BossApeared = false;
    private bool _endingLevel;
	private bool _startingLevel;
	private bool _showingWarningBoss;
    private Node2D _boss;
	private GameManager _gameManager;
	
    public override void _Ready()
	{
		Enemies = new List<Node2D>();
		_enemySection = new List<EnemySection>();
		
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

	public void AddEnemySection(List<EnemySection> enemies)
	{
		_enemySection.AddRange(enemies);
	}

    private void GetEnemyLevel()
    {
        if(CurrentLevel == 1)
			_enemySection = EnemiesLevelOne.GetEnemies();
		if(CurrentLevel == 2)
			_enemySection = EnemiesLevelTwo.GetEnemies();
		if(CurrentLevel == 3)
			_enemySection = EnemiesLevelThree.GetEnemies();
		if(CurrentLevel == 4)
			_enemySection = EnemiesLevelFour.GetEnemies();
		if(CurrentLevel == 5)
			_enemySection = EnemiesLevelFive.GetEnemies();
		if(CurrentLevel == 6)
			_enemySection = EnemiesLevelSix.GetEnemies();
		if(CurrentLevel == 7)
			_enemySection = EnemiesLevelSeven.GetEnemies();
		if(CurrentLevel == 8)
			_enemySection = EnemiesLevelEight.GetEnemies();
		if(CurrentLevel == 9)
			_enemySection = EnemiesLevelNine.GetEnemies();
		if(CurrentLevel == 10)
			_enemySection = EnemiesLevelTen.GetEnemies();
		if(CurrentLevel == 11)
			GetBoss();
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

	public void GetNextSection()
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

	public void RemoveEnemy(Node2D node)
	{
		var enemy = Enemies.Find((x) => x == node);

		Enemies.Remove(node);

		if(node is not INonExplodable)
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

	public void RemoveAllExplosions()
    {
		foreach(var node in GetChildren())
		{
			if(node is Explosion explosion)
				explosion.QueueFree();
		}
    }

	public void AddExplosion(Vector2 position)
	{
		AddExplosion(position.X, position.Y);
	}

    public void AddEnemy(IEnemyDummy enemy)
	{
		var node = enemy.GetInstance();
		AddEnemy(node);
		CallDeferred("add_child", node);
	}

	public void AddEnemy(Node2D enemy)
	{
		Enemies.Add(enemy);
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

		GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager").RemoveAllProjectiles();

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
		
		_boss?.QueueFree();
		_boss = null;
		
		_showingWarningBoss = false;
		BossApeared = false;
    }

	public void ClearEnemySection()
		=> _enemySection.Clear();
	
}
