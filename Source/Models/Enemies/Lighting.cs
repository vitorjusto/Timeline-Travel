using Godot;
using System;
using Shooter.Source.Interfaces;
using Shooter.Source.Dumies.Enemies.EnemiesPart;

public partial class Lighting : Node2D, IEnemy
{
	private int _time = 0;
	private bool _isWarning = true;

	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(_isWarning)
			MakeWarning();
		else
			MakeLightning();

		_time++;
	}

	private void MakeWarning()
	{
		if(_time % 7 == 0)
		{
			if(Visible)
				Hide();
			else
				Show();
		}

		if(_time == 100)
		{
			_isWarning = false;
			_time = -1;
		}
	}

	private void MakeLightning()
	{

		var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
        enemySpawner.AddEnemy(new DLightningPart(Position.X, (_time * 320)));

		if(_time == 4)
		{
        	enemySpawner.RemoveEnemy(this);
		}

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
