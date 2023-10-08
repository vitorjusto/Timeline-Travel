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
				var blackScreen = GetTree().Root.GetNode<Node2D>("/root/Main/BlackScreen");
				blackScreen.Visible = false;
				IsBlackScreen = false;
				_time = 0;

				

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
        var blackScreen = GetTree().Root.GetNode<Node2D>("/root/Main/BlackScreen");
		blackScreen.Visible = true;
		IsBlackScreen = true;

		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
		player.Hp = 10;

		player.Life--;
		player.Position = new Vector2(x: 722, y: 720);

		player.EmitSignal("PlayerHpUpdated", player.Hp);
		player.EmitSignal("PlayerLifeUpdated", player.Life);

		var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

		enemySpawner.RestartLevel();

		var projectileManager = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");

		projectileManager.RemoveAllProjectiles();

		_time++;

    }

	[Signal]
	public delegate void BlackScreenFadedEventHandler();

}
