using Godot;
using System;
using Shooter.Source.Interfaces;

public partial class LightningPart : CharacterBody2D, IEnemy, INonExplodable
{

	private int _speed = 1;

	private int _time = 0;
	public override void _Ready()
	{
		var animation = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		animation.Play("default");
	}
    public override void _Process(double delta)
	{


		if(_time > 10)
		{
			var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

        	enemySpawner.RemoveEnemy(this);
		}
		_time++;
	}

	public bool IsImortal()
	{
		return true;
	}


    public void Destroy()
    {
        
    }
}
