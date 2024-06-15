using Godot;
using System;
using Shooter.Source.Interfaces;

public partial class BlackHoleGeneratorPart : CharacterBody2D, IEnemy
{

	public bool ShowBlackHole = false;
	public int _hp = 40;
	public int _damageAnimation = 0;
	public int _blackholeTimer = 0;
	public BlackHoleGenerator Boss;

	public override void _Process(double delta)
	{
		if(ShowBlackHole)
		{
			var blackHole = GetNode<AnimatedSprite2D>("AniBlackHole");
			blackHole.Play("default");
			blackHole.Show();

			var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
			var angle = Math.Atan2(Boss.Position.X + Position.X - player.Position.X, Boss.Position.Y + Position.Y + blackHole.Position.Y - player.Position.Y);

			player.SetSpeed((float)Math.Sin(angle) * (7), (float)Math.Cos(angle) * (7) );
			_blackholeTimer++;

			if(_blackholeTimer == 100)
				ShowBlackHole = false;
		}else
		{
			var blackHole = GetNode<AnimatedSprite2D>("AniBlackHole");
			blackHole.Hide();
		}

		if(_damageAnimation > 0)
		{
			_damageAnimation--;

			if(_damageAnimation == 0)
			{
				var animation = GetNode<AnimatedSprite2D>("AniHand");
				animation.Play("Idle");
			}
		}
	}

	public void Destroy()
	{
		if(_damageAnimation > 0 || ShowBlackHole)
			_hp--;

		if(_hp == 0)
		{
			EmitSignal("DestroyArm", this);
			QueueFree();
		}

		var animation = GetNode<AnimatedSprite2D>("AniHand");
		animation.Play("Damage");

		_damageAnimation = 50;
	}

	public bool IsImortal()
	{
		return true;
	}

	public void OnShowBlackHole()
	{
		ShowBlackHole = true;
		_blackholeTimer = 0;
	}

	[Signal]
	public delegate void DestroyArmEventHandler(BlackHoleGeneratorPart part);
}
