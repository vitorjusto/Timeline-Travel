using Godot;
using System;
using Shooter.Source.Interfaces;

public partial class BlackHoleGeneratorPart : CharacterBody2D, IEnemy
{

	public bool ShowBlackHole = false;
	public float RelativeX = 0;
	public float RelativeY = 0;
	public int _hp = 30;
	public int _damageAnimation = 0;
	public override void _Process(double delta)
	{
		if(ShowBlackHole)
		{
			var blackHole = GetNode<AnimatedSprite2D>("AniBlackHole");
			blackHole.Play("default");
			blackHole.Show();

			var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
			var angle = Math.Atan2(RelativeX + Position.X + blackHole.Position.X - player.Position.X, RelativeY + Position.Y + blackHole.Position.Y - player.Position.Y);

			player.SetSpeed((float)Math.Sin(angle) * (7), (float)Math.Cos(angle) * (7) );

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

	public void InvertArm()
	{
		var animation = GetNode<AnimatedSprite2D>("AniArm");
		animation.FlipH = true;

		animation = GetNode<AnimatedSprite2D>("AniHand");
		animation.Position = new Vector2(- 32, animation.Position.Y);

		animation = GetNode<AnimatedSprite2D>("AniBlackHole");
		animation.Position = new Vector2(- 32, animation.Position.Y);

		var collision = GetNode<CollisionShape2D>("CollisionShape2D");
		collision.Position = new Vector2(- 32, collision.Position.Y);
	
	}

	public void Destroy()
	{
		_hp--;

		if(_hp == 0)
		{
			EmitSignal("DestroyArm");
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

	[Signal]
	public delegate void DestroyArmEventHandler();
}
