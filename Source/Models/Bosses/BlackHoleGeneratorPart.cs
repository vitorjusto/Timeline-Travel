using Godot;
using System;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.LevelOne.Enums;
using Shooter.Source.Models.Misc;

public partial class BlackHoleGeneratorPart : CharacterBody2D, IEnemy
{

	public bool ShowBlackHole = false;
	public int _hp = 50;
	public int _damageAnimation = 0;
	public int _blackholeTimer = 0;
	public BlackHoleGenerator Boss;

	[Export]
	public EPartSide PartSide;

	public override void _Process(double delta)
	{
		if(ShowBlackHole)
		{
			var blackHole = GetNode<Node2D>("AniBlackHole");
			blackHole.Visible = true;

			var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
			var angle = Math.Atan2(Boss.Position.X + Position.X - player.Position.X, Boss.Position.Y + Position.Y + blackHole.Position.Y - player.Position.Y);

			player.SetSpeed((float)Math.Sin(angle) * (7), (float)Math.Cos(angle) * (7) );
			_blackholeTimer++;

			if(_blackholeTimer == 100)
				ShowBlackHole = false;
		}else
		{
			var blackHole = GetNode<Node2D>("AniBlackHole");
			blackHole.Visible = false;
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
		if(ShowBlackHole)
			return;

		_hp--;

		if(_hp == 0)
		{
			EmitSignal("DestroyArm", this);
			QueueFree();
		}

		var animation = GetNode<AnimatedSprite2D>("AniHand");
		animation.Play("Damage");

		_damageAnimation = 10;
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

    public EnemyBoundy GetBoundy()
    {
        return new();
    }

    [Signal]
	public delegate void DestroyArmEventHandler(BlackHoleGeneratorPart part);
}
