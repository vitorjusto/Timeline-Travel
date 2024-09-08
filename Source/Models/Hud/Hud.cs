using System.Runtime.InteropServices;
using Godot;
using System;

public partial class Hud : Node2D
{
	private static Hud _hud;
	public int Score;
    private bool _showingTimelineLabel;
	private bool _showingWarningBoss;
	private int _time = 0;
	public bool IsShowingTimelineLabel => _showingTimelineLabel;
	private bool _isGamePaused;
    private GameManager _game;

    public override void _Ready()
	{
		_game = GetTree().Root.GetNode<GameManager>("/root/Main");
		_hud = this;
	}

	public override void _Process(double delta)
	{
		if(_showingTimelineLabel)
		{
			_time++;

			if(_time % 10 == 0)
			{
				var lblTimeline = GetNode<Label>("lblTimeline");
				lblTimeline.Visible = !lblTimeline.Visible;
			}

			if(_time == 200)
			{
				var lblTimeline = GetNode<Label>("lblTimeline");
				lblTimeline.Visible = false;
				_time = 0;
				_showingTimelineLabel = false;
			}

			return;
		}else if(_showingWarningBoss)
		{
			_time++;

			if(_time % 10 == 0)
			{
				var bossWarning = GetNode<Node2D>("BossWarning");
				bossWarning.Visible = !bossWarning.Visible;
			}

			if(_time == 200)
			{
				var bossWarning = GetNode<Node2D>("BossWarning");
				bossWarning.Visible = false;
				_time = 0;
				_showingWarningBoss = false;
			}

			return;

		}


		if(Input.IsActionJustPressed("pause"))
			OnPausePressed();
	}

	public static void AddScore(int score)
	{
		_hud.Score += score;
		_hud.GetNode<Label>("lblScore").SetDeferred("text", _hud.Score.ToString("0000000000"));
	}

	public void PlayerHpUpdated(int hp)
	{
		var lblHp = GetNode<Label>("lblHp");
		lblHp.Text = $"{hp}";
	}

	public void onPlayerLifeUpdated(int life)
	{
		var lblHp = GetNode<Label>("lblLife");
		lblHp.Text = $"{life}";
	}

	public void OnPausePressed()
	{
		PauseGame();
	}

    public void PauseGame()
    {
		if(_showingTimelineLabel || _showingWarningBoss || _game.IsBlackScreen)
			return;

        var lblPause = GetNode<Label>("lblPause");
		lblPause.Visible = !lblPause.Visible;
		_isGamePaused = lblPause.Visible;

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

		var bossWarning = GetNode<Node2D>("BossWarning");
		bossWarning.Visible = false;

		var lblTimeline = GetNode<Label>("lblTimeline");
		
		if(currentLevel == 1)
			lblTimeline.Text = $"OUR TIMELINE";
		else if(currentLevel == 10)
			lblTimeline.Text = $"THEIR TIMELINE";
		else if(currentLevel == 11)
			lblTimeline.Text = $"FINAL BOSS";
		else
			lblTimeline.Text = $"TIMELINE {currentLevel}";

	}

    internal void ShowWarningBoss()
    {
        _showingWarningBoss = true;
		_time = 0;
    }

	public void ShowCustomWarning(string name)
	{
		GetNode<AnimatedSprite2D>("AniCustomWarning").Play(name);
	}

}
