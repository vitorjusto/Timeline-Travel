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
    private byte _panelOpacity = 255;
    private byte _EndOpacity = 0;
    private float _backgroundSpeed = 10;
    private string _endingText = "AFTER BLOWING UP THE ENEMIES' SHIP, ALL TIMELINES ARE AT PEACE.\nTHANKS TO YOU.";
    private int _textCooldown = 100;
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
            FadeInEndText();
        if(_TextFadedOut)
            LetPlayerGoBackGround();
        if(_playerReachedEndScreen)
            FadeOutText();
        else
            GenerateText();
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

    private void FadeInEndText()
    {
        if(_EndOpacity == 255)
        {
            VerifyUnlockables();
            _allowPlayerToExit = true;
            return;
        }

        _EndOpacity += 5;
        GetNode<Node2D>("EndText").Modulate = Color.Color8(255, 255, 255, _EndOpacity);
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

    private void LetPlayerGoBackGround()
    {
        var animationSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

        animationSprite.Position += new Vector2(4, 1);
    }

    private void FadeOutText()
    {
        if(_panelOpacity == 0)
        {
            if(_backgroundSpeed == 0)
            {
                _TextFadedOut = true;
                GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play();
                return;
            }

            _backgroundSpeed -= 0.2f;
            _backgroundSpeed = _backgroundSpeed < 0? 0: _backgroundSpeed;

            GetNode<MovingParallaxLayer>("ParallaxBackground/MovingParallaxLayer").XSpeed = _backgroundSpeed;
            return;
        }

        _panelOpacity -= 5;
        _panel.Modulate = Color.Color8(255, 255, 255, _panelOpacity);
    }

    private void GenerateText()
    {
        _player.Position += new Vector2(_playerSpeed, 0);

        if(_endingText.Length == 0)
            return;

        if(_textCooldown == 0)
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
            _textCooldown--;
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
