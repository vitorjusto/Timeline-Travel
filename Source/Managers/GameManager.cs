using Godot;

public partial class GameManager : Node2D
{
    [Export]
    public bool SpecialMode = false;
    private static GameManager _game;
    public static GameManager GetManager()
        => _game;

    public static bool IsSpecialMode => _game is not null && _game.SpecialMode;
	private int _time = 0;
	public bool IsBlackScreen {get; private set; } = false;

    public override void _Ready()
    {
        _game = this;
        if(SpecialMode)
        {
            var player = GetNode<Player>("Player");

            FinalPowerUp.GiveFinalPowerUpStatus(player);
            player.Hp = 600;
            player.Hp = 600;
            player.Life = 0;
            
		    GetTree().Root.GetNode<Hud>("/root/Main/Hud").UpdateHud(player, 6);
            
		    GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager").PlayerProjectileLevel = 6;
        }

        AudioManager.SetTimelineSong(EnemySpawner.GetEnemySpawner().CurrentLevel);
        AudioManager.Play();
    }

	public override void _Process(double delta)
	{
		if(_time > 0)
		{
			_time++;

			if(_time > 130)
			{
                AudioManager.Play();
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
		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
		
		if(player.Life == 0)
			GetTree().ChangeSceneToFile("res://Scenes/GameOverScreen.tscn");

		RestartLevel();
	}

    private void RestartLevel()
    {
        var blackScreen = GetTree().Root.GetNode<Node2D>("/root/Main/ParallaxBackground/BlackScreen");
		blackScreen.Visible = true;
		IsBlackScreen = true;
		_time++;

        AudioManager.Stop();

		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
		player.Hp = 10;

		player.Life--;
		player.Position = new Vector2(x: 722, y: 720);

		player.EmitSignal("PlayerHpUpdated", player.Hp);
		player.EmitSignal("PlayerLifeUpdated", player.Life);
		player.ResetTargetCount();

		var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

		enemySpawner.RestartLevel();
        
        AudioManager.SetTimelineSong(enemySpawner.CurrentLevel);

		var projectileManager = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");

		projectileManager.RemoveAllProjectiles();
		projectileManager.PlayerProjectileLevel = 1;

		GetTree().Root.GetNode<Hud>("/root/Main/Hud").ShowCustomWarning("None");

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
        AudioManager.Stop();

		_time++;

		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
		player.Position = new Vector2(x: 722, y: 720);

		var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
		enemySpawner.RestartLevel();
		enemySpawner.CurrentLevel += 1;
        enemySpawner.CheckpointId = 0;
        
		var projectileManager = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");
		projectileManager.RemoveAllProjectiles();

		var backgroundManager = GetTree().Root.GetNode<BackgroundManager>("/root/Main/BackgroundManager");
		backgroundManager.SetNewBackgroundLevel(enemySpawner.CurrentLevel);
		player.ResetTargetCount();
		
		GetTree().Root.GetNode<Hud>("/root/Main/Hud").ShowCustomWarning("None");
		GetTree().Root.GetNode<PowerUpManager>("/root/Main/PowerUpManager").ClearAllChild();

        AudioManager.SetTimelineSong(enemySpawner.CurrentLevel);
	}

	[Signal]
	public delegate void BlackScreenFadedEventHandler();

}
