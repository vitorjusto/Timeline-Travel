using Godot;
using Shooter.Source.Models.Misc;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class TitleScreen : Node2D
{
    private bool _makeStartAnimation;
	private QuickTimer _timer = new(120);
	private QuickTimer _animationTimer = new(10);
    private List<ETitleScreenOptions> _avaliableOptions;
    private ETitleScreenOptions _selectedOption;

    public override void _Ready()
	{
        _avaliableOptions = new List<ETitleScreenOptions>
        {
            ETitleScreenOptions.Controls,
            ETitleScreenOptions.StartGame
        };

        _selectedOption = ETitleScreenOptions.StartGame;

        SaveManager.Load();

        //Special Mode Active
        if(SaveManager.Data.SpecialModeUnlocked)
        {
            _avaliableOptions.Add(ETitleScreenOptions.SpecialMode);
            GetNode<Label>("lblSpecialMode").Visible = true;
        }

        //Boss Rush Active
        if(SaveManager.Data.BossRushUnlocked)
        {
            _avaliableOptions.Add(ETitleScreenOptions.BossRush);
            GetNode<Label>("lblBossRush").Visible = true;
        }
	}

	public override void _Process(double delta)
	{
		if(_makeStartAnimation)
		{
			StartAnimation(delta);
			return;
		}
			
		if(GetNode<Node2D>("ControlsScreen").Visible)
		{
			if(Input.IsActionJustPressed("Enter"))
				GetNode<Node2D>("ControlsScreen").Visible = false;
			
			return;
		}

		if(Input.IsActionJustPressed("move_down"))
		{
            GetNode<Node2D>($"Indicator{(int)_selectedOption}").Visible = false;
            _selectedOption += 1;

            if(!_avaliableOptions.Contains(_selectedOption))
                _selectedOption = ETitleScreenOptions.Controls;
                
            GetNode<Node2D>($"Indicator{(int)_selectedOption}").Visible = true;
			
		}else if(Input.IsActionJustPressed("move_up"))
		{
            GetNode<Node2D>($"Indicator{(int)_selectedOption}").Visible = false;
            _selectedOption -= 1;

            if(_selectedOption == 0)
                _selectedOption = _avaliableOptions.Max<ETitleScreenOptions>();

            GetNode<Node2D>($"Indicator{(int)_selectedOption}").Visible = true;
				
		}else if(Input.IsActionJustPressed("Enter"))
		{
            OnOptionSelected();
		}

	}

    private void OnOptionSelected()
    {
		if(_selectedOption == ETitleScreenOptions.Controls)
			GetNode<Node2D>("ControlsScreen").Visible = true;
		else
			_makeStartAnimation = true;
    }

    private void StartAnimation(double delta)
    {
		if(_animationTimer.Process(delta))
			GetChosenOptionLabel().Visible = !GetChosenOptionLabel().Visible;

		if(_timer.Time >= 100)
			GetNode<Panel>("BlackScreen").Visible = true;
		
		if(_timer.Process(delta))
        {
            if(_selectedOption == ETitleScreenOptions.SpecialMode)
            {
                SaveManager.Data.GameMode = EGameMode.Special;
                GetTree().ChangeSceneToFile("res://Scenes/SpecialMode.tscn");
            }
            else if(_selectedOption == ETitleScreenOptions.StartGame)
            {
                
                SaveManager.Data.GameMode = EGameMode.Normal;
                GetTree().ChangeSceneToFile("res://Scenes/main.tscn");
            }
            else if(_selectedOption == ETitleScreenOptions.BossRush)
            {
                SaveManager.Data.GameMode = EGameMode.BossRush;
                GetTree().ChangeSceneToFile("res://Scenes/BossRush.tscn");
            }
        }
    }

    private Label GetChosenOptionLabel()
    {
        switch (_selectedOption)
        {
            case ETitleScreenOptions.Controls:
                return GetNode<Label>("lblControls");
            case ETitleScreenOptions.StartGame:
                return GetNode<Label>("lblStartGame");
            case ETitleScreenOptions.SpecialMode:
                return GetNode<Label>("lblSpecialMode");
            case ETitleScreenOptions.BossRush:
                return GetNode<Label>("lblBossRush");
        }

        return null;
    }

    public void OnSongFinished()
    {
        GetNode<AudioStreamPlayer>("AudioStreamPlayer").Play(0);
    }
}
