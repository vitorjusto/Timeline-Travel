using System;
using Godot;

public partial class FirstClassEnemyBase : Node2D
{
	private AnimatedSprite2D _animatedSprite;
    private FirstClassEnemy _boss;
    private int _timer;
    private bool _endCutscene;
    private bool _mothershipClosing;
	private byte _playerAphaColor = 255;
	public override void _Ready()
	{
		_animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_boss = GetNode<FirstClassEnemy>("FirstClassEnemy");
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
			_timer++;

			if(_timer > 200)
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
			MakeEndCutscene();
			return;
		}

		if(_timer > 600)
			return;

		_timer++;

		if(_timer < 410)
			_animatedSprite.Position += new Vector2(0, 0.9f);
		
		else if(_timer == 412)
			_animatedSprite.Play("Opening");

		else if(_timer == 580)
			_boss.Enable = true;
	}

    private void MakeEndCutscene()
    {
        var player = GetTree().Root.GetNode<Player>("/root/Main/Player");

		if(Math.Abs(player.Position.X - 700) < 12)
		{
			
			if(Math.Abs(player.Position.Y - 60) < 12)
			{
				_playerAphaColor -= 5;
				player.Modulate = Color.Color8(255, 255, 255, _playerAphaColor);

				if(_playerAphaColor == 0)
				{
					_mothershipClosing = true;
					_animatedSprite.Play("Closing");
					_timer = 0;
				}
			}
			else
				player.Position += new Vector2(0, -player.Speed);
		}
		else if(player.Position.X < 700)
			player.Position += new Vector2(player.Speed, 0);
			
		else if(player.Position.X > 700)
			player.Position -= new Vector2(player.Speed, 0);
    }
}
