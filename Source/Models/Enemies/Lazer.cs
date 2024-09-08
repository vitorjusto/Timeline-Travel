using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Dumies.Enemies.EnemiesPart;
using Shooter.Source.Models.Misc;

public partial class Lazer : CharacterBody2D, IEnemy
{
	private int _yspeed = 8;
	private float _time = 0;
	private bool _isShooting = false;
	public int MaxTime = 201;
    public override void _Process(double delta)
	{
		if(_isShooting )
			Shoot();
		else
			MoveEnemy();
	}

    private void MoveEnemy()
    {
		if(_time < 10)
		{
        	Position = new Vector2(x: Position.X, y: Position.Y + _yspeed);

		}else
		{
			_isShooting = true;
			_time = 0;
		}

		_time++;
    }

	private void Shoot()
	{
		_time++;

		if(_time > MaxTime)
		{
			Position = new Vector2(x: Position.X, y: Position.Y - _yspeed);
		}else
		{
			var y = Position.Y + (20 * _time);

			if(y > 900)
				return;
				
			var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");


        	enemySpawner.AddEnemy(new DLazerPart(Position.X, y, MaxTime));
		}
	}

    public void OnScreenExited()
    {
        EnemySpawner.GetEnemySpawner().RemoveEnemy(this);
    }

	public bool IsImortal()
	{
		return true;
	}


    public void Destroy()
    {
		return;
    }

    public EnemyBoundy GetBoundy()
    {
		if(_isShooting)
			return new();
			
        return new(1, 1, Position);
    }
}
