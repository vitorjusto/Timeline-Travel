using Godot;
using System;
using Shooter.Source.Interfaces;
public partial class LazerPart : CharacterBody2D, IEnemy
{

	private int _speed = 1;

	private int _time = 0;

    public override void _Process(double delta)
	{
		if(_time > 200)
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
