using Godot;
using System;

public partial class BlackHoleAnimation : Node2D
{
	[Export]
	public bool IsWhiteHole = false;
	public override void _Ready()
	{
		if(IsWhiteHole)
		{
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("WhiteHole");
			GetNode<AnimationPlayer>("AnimationPlayer").Play("WhiteHole");
		}
	}

	public override void _Process(double delta)
	{
	}
}
