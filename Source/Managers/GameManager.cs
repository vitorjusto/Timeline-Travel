using Godot;
using Shooter.Source.Models.Misc;
using TimelineTravel.Source.ScrensTransitions;

public partial class GameManager : Node2D
{
    [Export]
    public bool SpecialMode = false;
    private static GameManager _game;
    public static GameManager GetManager()
        => _game;

    public static bool IsSpecialMode => _game is not null && _game.SpecialMode;
	private readonly QuickTimer _time = new(130);
	public bool IsBlackScreen {get; set; } = false;
	public Node2D BlackScreen { get; private set; }

	private ScreenTransition _screenTransition;

    public override void _Ready()
    {
        _game = this;
		BlackScreen = GetTree().Root.GetNode<Node2D>("/root/Main/ParallaxBackground/BlackScreen");
        if(SpecialMode)
        {
            var player = GetNode<Player>("Player");

            FinalPowerUp.GiveFinalPowerUpStatus(player);
            player.Hp = 600;
            player.Hp = 600;
            player.Life = 0;
            
		    Hud.UpdateHud(player, 6);
            
		    GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager").PlayerProjectileLevel = 6;
        }

        AudioManager.SetTimelineSong(EnemySpawner.GetEnemySpawner().CurrentLevel);
        AudioManager.Play();
    }

	public override void _Process(double delta)
	{
		if(!IsBlackScreen)
            return;

		if(_screenTransition is not null)
		{
			_screenTransition.LoadLevel();
			_screenTransition = null;
		}

        if(_time.Process(delta))
		{
            AudioManager.Play();
			var blackScreen = GetTree().Root.GetNode<Node2D>("/root/Main/ParallaxBackground/BlackScreen");
			blackScreen.Visible = false;
			IsBlackScreen = false;
			_time.Reset();
			
			var player = GetTree().Root.GetNode<Player>("/root/Main/Player");

			player.EnablePlayerToMove();

			var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
			enemySpawner.StartLevel();
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
		_screenTransition = new RestartLevelScreenTransition();
    }

	public void OnLevelPassed()
	{
		StartNewLevel();
	}

	private void StartNewLevel()
	{
		_screenTransition = new StartLevelScreenTransition();
	}

	[Signal]
	public delegate void BlackScreenFadedEventHandler();

}
