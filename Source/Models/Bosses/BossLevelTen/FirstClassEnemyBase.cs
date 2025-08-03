using System;
using Godot;
using Shooter.Source.Models.Misc;

public partial class FirstClassEnemyBase : Node2D
{
	private AnimatedSprite2D _animatedSprite;
    private FirstClassEnemy _boss;
    private QuickTimer _timer = new(600);
    private QuickTimer _closingTimer = new(200);
    private bool _endCutscene;
    private bool _mothershipClosing;
	private float _playerAphaColor = 255;
    private bool _enteringAnimationEnded;
    private bool _openingAnimationStarted;

    public override void _Ready()
	{
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_boss = GameManager.IsSpecialMode?GetNode<FirstClassEnemy>("FirstClassEnemy2"):GetNode<FirstClassEnemy>("FirstClassEnemy");
		_boss.Enable = false;
	}

	public void OnBossDefeated()
	{
		_endCutscene = true;
		GetTree().Root.GetNode<Player>("/root/Main/Player").DisablePlayerToMove();
	}

	public override void _Process(double delta)
	{
		if(_mothershipClosing)
		{
			if(_closingTimer.Process(delta))
			{
				var blackScreen = GetTree().Root.GetNode<Node2D>("/root/Main/ParallaxBackground/BlackScreen");
				blackScreen.Visible = true;

				GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner").RemoveEnemy(this);

				GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner").EndLevel();
				GetTree().Root.GetNode<Player>("/root/Main/Player").Modulate = Color.Color8(255, 255, 255, 255);

			}
			return;
		}
		if(_endCutscene)
		{
			MakeEndCutscene(delta);
			return;
		}

        if(_enteringAnimationEnded)
            return;

        _enteringAnimationEnded = _timer.Process(delta);

		if(_timer.Time < 410)
			_animatedSprite.Position += new Vector2(0, 0.9f) * (float)(delta * 60);
		
		else if(_timer.Time >= 412 && !_openingAnimationStarted)
        {
            _openingAnimationStarted = true;
            _animatedSprite.Play("Opening");
        }

		else if(_timer.Time >= 580)
			_boss.Enable = true;
	}

    private void MakeEndCutscene(double delta)
    {
        var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
        player.DisablePlayerToMove();

        if(Math.Abs(player.Position.X - 700) < 12)
		{
			if(Math.Abs(player.Position.Y - 60) < 12)
			{
				_playerAphaColor -= (float)(delta * 300);
				_playerAphaColor = Math.Clamp(_playerAphaColor, 0, 255);
				player.Modulate = Color.Color8(255, 255, 255, (byte)_playerAphaColor);

				if((int)_playerAphaColor == 0)
				{
					_mothershipClosing = true;
					_animatedSprite.Play("Closing");
				}
			}
			else
				player.Position += new Vector2(0, -player.Speed) * (float)(delta * 60);
		}
		else if(player.Position.X < 700)
			player.Position += new Vector2(player.Speed, 0) * (float)(delta * 60);
			
		else if(player.Position.X > 700)
			player.Position -= new Vector2(player.Speed, 0) * (float)(delta * 60);
    }
}
