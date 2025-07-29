using System;
using Godot;

public partial class FinalEndingScene2 : Node2D
{
    private bool _playerReachedEndScreen;
    private Node2D _player;
    private int _playerSpeed = -2;
    private Label _label;
    private Panel _panel;
    private bool _enabled;
    private float _panelOpacity = 255;
    private float _EndOpacity = 0;
    private float _backgroundSpeed = 10;
    private string _endingText = "AFTER BLOWING UP THE ENEMIES' SHIP, ALL TIMELINES ARE AT PEACE.\nTHANKS TO YOU.";
    private float _textCooldown = 100;
    private bool _TextFadedOut;
    private bool _EndTextFadeIn;
    private bool _allowPlayerToExit;
    private bool _playerUnlockedSpecialMode;
    private bool _playerUnlockedBossRush;

    public override void _Ready()
	{
        _player = GetNode<Node2D>("SpaceshipUpgrade");
        _label = GetNode<Label>("Panel/Label");
        _panel = GetNode<Panel>("Panel");
        _enabled = false;
	}

	public override void _Process(double delta)
	{
        if(!_enabled)
            return;
        if(_allowPlayerToExit)
            ListenPlayerInput();
        if(_EndTextFadeIn)
            FadeInEndText(delta);
        if(_TextFadedOut)
            LetPlayerGoBackGround(delta);
        if(_playerReachedEndScreen)
            FadeOutText(delta);
        else
            GenerateText(delta);
	}

    private void ListenPlayerInput()
    {
        if(!Input.IsActionJustPressed("Enter"))
            return;

        if(_playerUnlockedSpecialMode)
            GetTree().ChangeSceneToFile("res://Scenes/Misc/NotificationsScreens/SpecialModeUnlocked.tscn");
        else if(_playerUnlockedBossRush)
            GetTree().ChangeSceneToFile("res://Scenes/Misc/NotificationsScreens/BossRushUnlocked.tscn");
        else
            GetTree().ChangeSceneToFile("res://Scenes/TitleScreen.tscn");
    }

    private void FadeInEndText(double delta)
    {
        if(_EndOpacity >= 255)
        {
            VerifyUnlockables();
            _allowPlayerToExit = true;
            return;
        }

        _EndOpacity += (float)(delta * 300);
        GetNode<Node2D>("EndText").Modulate = Color.Color8(255, 255, 255, (byte)Math.Clamp(Math.Floor(_EndOpacity), 0, 255));
    }

    private void VerifyUnlockables()
    {
        if(SaveManager.Data.GameMode == EGameMode.Normal && !SaveManager.Data.SpecialModeUnlocked)
        {
            SaveManager.Data.SpecialModeUnlocked = true;
            SaveManager.Save();
            _playerUnlockedSpecialMode = true;

        }else if(SaveManager.Data.GameMode == EGameMode.Special && !SaveManager.Data.BossRushUnlocked)
        {
            SaveManager.Data.BossRushUnlocked = true;
            SaveManager.Save();
            _playerUnlockedBossRush = true;
        }

    }

    private void LetPlayerGoBackGround(double delta)
    {
        var animationSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

        animationSprite.Position += new Vector2(4, 1) * (float)(delta * 60);
    }

    private void FadeOutText(double delta)
    {
        if(_panelOpacity == 0)
        {
            if(_backgroundSpeed == 0)
            {
                _TextFadedOut = true;
                GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play();
                return;
            }

            _backgroundSpeed -= 0.2f * (float)(delta * 60);
            _backgroundSpeed = _backgroundSpeed < 0? 0: _backgroundSpeed;

            GetNode<MovingParallaxLayer>("ParallaxBackground/MovingParallaxLayer").XSpeed = _backgroundSpeed;
            return;
        }

        _panelOpacity -= (float)(delta * 300);
        _panelOpacity -= (float)Math.Clamp(Math.Floor(_panelOpacity), 0, 255);
        _panel.Modulate = Color.Color8(255, 255, 255, (byte)_panelOpacity);
    }

    private void GenerateText(double delta)
    {
        _player.Position += new Vector2(_playerSpeed * (float)(delta * 60), 0);

        if(_endingText.Length == 0)
            return;

        if(_textCooldown <= 0)
        {
            _label.Text += _endingText[0];
            _endingText = _endingText.Substr(1, _endingText.Length - 1);

            if(_endingText.Length == 0)
            {
                _playerSpeed = -10;
                return;
            }

            if(_endingText[0] == ' ')
            {
                _label.Text += _endingText[0];
                _endingText = _endingText.Substr(1, _endingText.Length - 1);
            }

            _textCooldown = _endingText[0] == '\n'? 15: 3;

        }else
        {
            _textCooldown-= (float)(delta * 60);
        }
    }

    public void OnPlayerExited()
    {
        _playerReachedEndScreen = true;
    }

    
    public void AnimatedSpriteFinished()
    {
        GetNode<AnimatedSprite2D>("AnimatedSprite2D").Visible = false;
        _EndTextFadeIn = true;
    }

    public void AnimationEnded(string animationName)
    {
        _enabled = true;
    }
}
