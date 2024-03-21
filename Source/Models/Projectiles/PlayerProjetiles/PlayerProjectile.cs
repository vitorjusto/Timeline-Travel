using Godot;
using Shooter.Source.Interfaces;
using System;

public partial class PlayerProjectile : Area2D
{
	private int _ySpeed = -20;
	private int _xSpeed = 0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position = new Vector2(x: Position.X + _xSpeed, y: Position.Y + _ySpeed);
	}

	public void SetPosition(float x, float y)
	{
		Position = new Vector2(x, y);
	}

	public void SetSpeed(int xSpeed, int ySpeed)
	{
		_ySpeed = ySpeed;
		_xSpeed = xSpeed;
	}

	public void OnScreenExited()
	{
		QueueFree();
	}

	public void OnBodyEntered(Node2D node)
	{
		if(node is IEnemy)
		{
			var enemy = (IEnemy)node;

			enemy.Destroy();

			if(!enemy.IsImortal())
				GetTree().Root.GetNode<PowerUpManager>("/root/Main/PowerUpManager").AddEnemyDefeated(node);
				
			QueueFree();

		}
	}
}
