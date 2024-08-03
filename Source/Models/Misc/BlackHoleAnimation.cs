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

	public override void _Process(double delta)
	{
	}

	public void UpdateAnimation(bool isWhiteHole)
	{
		if(isWhiteHole)
		{
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("Whitehole");
			GetNode<AnimationPlayer>("AnimationPlayer").Play("Whitehole");
		}
	}
}
