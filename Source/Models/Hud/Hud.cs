using System.Runtime.InteropServices;
using Godot;
using System;

public partial class Hud : Node2D
{
    private bool _showingTimelineLabel;
	private bool _showingWarningBoss;
	private int _time = 0;
	public bool IsShowingTimelineLabel => _showingTimelineLabel;


    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
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
		if(_showingTimelineLabel)
			return;

        var lblPause = GetNode<Label>("lblPause");
		lblPause.Visible = !lblPause.Visible;
		EmitSignal("GamePaused", lblPause.Visible);
    }

	[Signal]
	public delegate void GamePausedEventHandler(bool isPaused);

	public void ShowTimelineLabel(int currentLevel)
	{
		_showingTimelineLabel = true;

		var bossWarning = GetNode<Node2D>("BossWarning");
		bossWarning.Visible = false;

		var lblTimeline = GetNode<Label>("lblTimeline");
		
		if(currentLevel == 1)
			lblTimeline.Text = $"Our Timeline";
		else if(currentLevel == 10)
			lblTimeline.Text = $"Their Timeline";
		else if(currentLevel == 11)
			lblTimeline.Text = $"Final Boss";
		else
			lblTimeline.Text = $"Timeline {currentLevel}";

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
