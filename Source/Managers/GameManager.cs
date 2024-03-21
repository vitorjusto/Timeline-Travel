using Godot;
using System;

public partial class GameManager : Node2D
{
	private int _time = 0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public bool IsBlackScreen = false;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(_time > 0)
		{
			_time++;

			if(_time > 130)
			{
				var blackScreen = GetTree().Root.GetNode<Node2D>("/root/Main/ParallaxBackground/BlackScreen");
				blackScreen.Visible = false;
				IsBlackScreen = false;
				_time = 0;
				
				var player = GetTree().Root.GetNode<Player>("/root/Main/Player");

				player.EnablePlayerToMove();

				var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
				enemySpawner.StartLevel();
			}
		}
	}

	public void OnPlayerDestroyed()
	{
		RestartLevel();
	}

    private void RestartLevel()
    {
        var blackScreen = GetTree().Root.GetNode<Node2D>("/root/Main/ParallaxBackground/BlackScreen");
		blackScreen.Visible = true;
		IsBlackScreen = true;

		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
		player.Hp = 10;

		player.Life--;
		player.Position = new Vector2(x: 722, y: 720);

		player.EmitSignal("PlayerHpUpdated", player.Hp);
		player.EmitSignal("PlayerLifeUpdated", player.Life);
		player.HideTarget();

		var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

		enemySpawner.RestartLevel();

		var projectileManager = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");

		projectileManager.RemoveAllProjectiles();
		projectileManager.PlayerProjectileLevel = 1;

		_time++;
		GetTree().Root.GetNode<Hud>("/root/Main/Hud").ShowCustomWarning("None");

		var backgroundManager = GetTree().Root.GetNode<BackgroundManager>("/root/Main/BackgroundManager");
		backgroundManager.RestartBackgroundAnimation(enemySpawner.CurrentLevel);

		GetTree().Root.GetNode<PowerUpManager>("/root/Main/PowerUpManager").ClearAllChild();
    }

	public void OnLevelPassed()
	{
		StartNewLevel();
	}

	private void StartNewLevel()
	{
		var blackScreen = GetTree().Root.GetNode<Node2D>("/root/Main/ParallaxBackground/BlackScreen");
		blackScreen.Visible = true;
		IsBlackScreen = true;

		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
		player.Position = new Vector2(x: 722, y: 720);

		var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
		enemySpawner.RestartLevel();
		enemySpawner.CurrentLevel += 1;

		var projectileManager = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");
		projectileManager.RemoveAllProjectiles();

		var backgroundManager = GetTree().Root.GetNode<BackgroundManager>("/root/Main/BackgroundManager");
		backgroundManager.SetNewBackgroundLevel(enemySpawner.CurrentLevel);
		player.HideTarget();
		
		_time++;
		GetTree().Root.GetNode<Hud>("/root/Main/Hud").ShowCustomWarning("None");
		GetTree().Root.GetNode<PowerUpManager>("/root/Main/PowerUpManager").ClearAllChild();
	}

	[Signal]
	public delegate void BlackScreenFadedEventHandler();

}
