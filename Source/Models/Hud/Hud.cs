using Godot;
using System;

public partial class Hud : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void PlayerHpUpdated(int hp)
	{
		var lblHp = GetNode<Label>("lblHp");
		lblHp.Text = $"Hp: {hp}";
	}


}
