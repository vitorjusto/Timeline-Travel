using Godot;
using Shooter.Source.Interfaces;
using System;

public partial class PlayerProjectile : Area2D
{

	private int _speed = -20;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position = new Vector2(x: Position.X, y: Position.Y + _speed);
	}

	public void SetPosition(float x, float y)
	{
		Position = new Vector2(x, y);
	}

	public void OnScreenExited()
	{
		QueueFree();
	}

	public void OnBodyEntered(Node2D node)
	{
		if(node is IEnemy)
		{
			var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
			enemySpawner.RemoveEnemy(node);

			QueueFree();
		}
	}
}
