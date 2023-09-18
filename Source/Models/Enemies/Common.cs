using Godot;
using Shooter.Source.Interfaces;
using System;

public partial class Common : CharacterBody2D, IEnemy
{

	private int _speed = 1;

    public override void _Process(double delta)
	{
		MoveEnemy();
	}

    private void MoveEnemy()
    {
        Position = new Vector2(x: Position.X, y: Position.Y + _speed);
    }

    public void OnScreenExited()
    {
        var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

        enemySpawner.RemoveEnemy(this);
    }

	public bool IsImortal()
	{
		return false;
	}


    public void Destroy()
    {
        var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

        enemySpawner.RemoveEnemy(this);
    }
}
