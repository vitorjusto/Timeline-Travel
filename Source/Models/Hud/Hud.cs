using System;
using Godot;
using Shooter.Source.Managers;

public partial class Hud : Node2D
{
	private static Hud _hud;
	public int Score;
    private bool _showingTimelineLabel;
	private bool _showingWarningBoss;
	private float _timer = 0;
	private float _labeltimer = 0;
	public bool IsShowingTimelineLabel => _showingTimelineLabel;
	private bool _isGamePaused;
    private GameManager _game;
    public int CheckpointLabelTimer;
    private Label _lblCheckpoint;
    private AnimatedSprite2D _aniSound;

    public override void _Ready()
	{
		_game = GetTree().Root.GetNode<GameManager>("/root/Main");
		_hud = this;
        _lblCheckpoint = GetNode<Label>("ParallaxBackground/lblCheckpoint");
        _aniSound = GetNode<AnimatedSprite2D>("ParallaxBackground/btnMute/SondButton");

        if(MuteMusicManager.GetIsGameMute())
            _aniSound.Play("Mute");
        else
            _aniSound.Play("Playing");
    }

	public override void _Process(double delta)
	{
        if(Input.IsActionJustPressed("Mute"))
            TogleMusicGame();

        if(CheckpointLabelTimer > 0)
        {
            CheckpointLabelTimer--;
            _lblCheckpoint.Visible = CheckpointLabelTimer > 0;
        }

		if(_showingTimelineLabel)
		{
			_timer += (float)(delta * 60);
            _labeltimer += (float)(delta * 60);

			if(_labeltimer >= 10)
			{
				var lblTimeline = GetNode<Label>("ParallaxBackground/lblTimeline");
				lblTimeline.Visible = !lblTimeline.Visible;
                _labeltimer = 0;
            }

			if(_timer >= 200)
			{
				var lblTimeline = GetNode<Label>("ParallaxBackground/lblTimeline");
				lblTimeline.Visible = false;
				_timer = 0;
                _labeltimer = 0;
				_showingTimelineLabel = false;
			}

			return;
		}else if(_showingWarningBoss)
		{
			_timer += (float)(delta * 60);
            _labeltimer += (float)(delta * 60);

			if(_labeltimer >= 10)
			{
				var bossWarning = GetNode<Node2D>("ParallaxBackground/BossWarning");
				bossWarning.Visible = !bossWarning.Visible;
                _labeltimer = 0;
			}

			if(_timer >= 200)
			{
				var bossWarning = GetNode<Node2D>("ParallaxBackground/BossWarning");
				bossWarning.Visible = false;
				_timer = 0;
                _labeltimer = 0;
				_showingWarningBoss = false;
			}

			return;

		}

		if(Input.IsActionJustPressed("pause"))
			OnPausePressed();
	}

    public static void SetCheckpointTimer(int timer)
    {
        if(GameManager.IsSpecialMode)
            return;
        _hud.CheckpointLabelTimer = timer;
    }

	public static void AddScore(int score)
	{
		_hud.Score += score;
		_hud.GetNode<Label>("ParallaxBackground/lblScore").SetDeferred("text", _hud.Score.ToString("0000000000"));
	}

	public void PlayerHpUpdated(int hp)
	{
		var lblHp = GetNode<Label>("ParallaxBackground/lblHp");
		lblHp.Text = $"{hp}";

		lblHp.Modulate = hp > 9? Color.Color8(255, 255, 0, 255) : Color.Color8(255, 255, 255, 255);
	}

	public void PlayerBulletUpdated(int bullet)
	{
		var lblBullet = GetNode<Label>("ParallaxBackground/lblBullet");
		lblBullet.Text = $"{bullet}";

		lblBullet.Modulate = bullet >= 5? Color.Color8(255, 255, 0, 255) : Color.Color8(255, 255, 255, 255);
	}

	public void onPlayerLifeUpdated(int life)
	{
		var lblHp = GetNode<Label>("ParallaxBackground/lblLife");
		lblHp.Text = $"{life}";
	}

    public void UpdateHud(Player player, int bullet)
    {
        PlayerHpUpdated(player.Hp);
        PlayerBulletUpdated(bullet);
        onPlayerLifeUpdated(player.Life);
    }

	public void OnPausePressed()
	{
		PauseGame();
	}

    public void PauseGame()
    {
		if(_showingTimelineLabel || _showingWarningBoss || _game.IsBlackScreen)
			return;

        var lblPause = GetNode<Label>("ParallaxBackground/lblPause");
		lblPause.Visible = !lblPause.Visible;
		_isGamePaused = lblPause.Visible;

        if(_isGamePaused)
            AudioManager.Pause();
        else
            AudioManager.Unpause();

		PauseAllProcess();
    }

    private void PauseAllProcess()
    {
        var main = GetTree().Root.GetNode<Node2D>("/root/Main");

		SetNodeProcess(main);
    }

    private void SetNodeProcess(Node nodeParent)
    {
        foreach(var node in nodeParent.GetChildren())
		{
			SetNodeProcess(node);
		}

		if(nodeParent is not Hud)
			nodeParent.SetProcess(!_isGamePaused);
		
		if(nodeParent is AnimatedSprite2D animated)
		{
			if(_isGamePaused)
				animated.Stop();
			else
				animated.Play();
		}
    }

	public void ShowTimelineLabel(int currentLevel)
	{
		_showingTimelineLabel = true;

		var bossWarning = GetNode<Node2D>("ParallaxBackground/BossWarning");
		bossWarning.Visible = false;

		var lblTimeline = GetNode<Label>("ParallaxBackground/lblTimeline");
		
		if(currentLevel == 1)
			lblTimeline.Text = $"OUR TIMELINE";
		else if(currentLevel == 10)
			lblTimeline.Text = $"THEIR TIMELINE";
		else if(currentLevel == 11)
			lblTimeline.Text = $"FINAL BOSS";
		else if(currentLevel == 12)
			lblTimeline.Text = $"BOSS RUSH";
		else
			lblTimeline.Text = $"TIMELINE {currentLevel}";

	}

    internal void ShowWarningBoss()
    {
        _showingWarningBoss = true;				
        _timer = 0;
        _labeltimer = 0;
    }

	public void ShowCustomWarning(string name)
	{
		GetNode<AnimatedSprite2D>("ParallaxBackground/AniCustomWarning").Play(name);
	}

	public void OnPlayerLifeProgressOpdated(int lifeProgress, int maxLifeProgress)
	{
		var panel = GetNode<Panel>("ParallaxBackground/LifeProgressBar");

		var whidth = lifeProgress * 64 / maxLifeProgress;

		panel.Size = new Vector2(whidth, panel.Size.Y);
	}

    public void OnBtnMutePressed()
    {
        TogleMusicGame();
    }

    private void TogleMusicGame()
    {
        if(MuteMusicManager.ToggleMute())
            _aniSound.Play("Mute");
        else
            _aniSound.Play("Playing");

        EmitSignal("OnChangeMute");
    }

    [Signal]
    public delegate void OnChangeMuteEventHandler();
}