using Godot;
using System;

public partial class BlackHoleAnimation : Node2D
{
	[Export]
	public bool IsWhiteHole = false;
	public override void _Ready()
	{
		UpdateAnimation(IsWhiteHole);
	}

	public void UpdateAnimation(bool isWhiteHole)
	{
        IsWhiteHole = isWhiteHole;

		if(IsWhiteHole)
		{
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("Whitehole");
			GetNode<AnimationPlayer>("AnimationPlayer").Play("Whitehole");
		}else
        {
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("Blackhole");
			GetNode<AnimationPlayer>("AnimationPlayer").Play("Blackhole");
        }

	}
}
