using Godot;
using Shooter.Source.Enums;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;
using System;

public partial class Stomper : CharacterBody2D, IEnemy
{

	private int _xSpeed = 5;
	private int _ySpeed = 5;

	private float _time = 0;
    private EDashStatus _dashStatus;
	private int _timeDashed = 0;

    public override void _Process(double delta)
	{
		MoveEnemy();
	}

    private void MoveEnemy()
    {
		if(_time < 50)
		{
			Position = new Vector2(x: Position.X, y: Position.Y + _ySpeed);
			_time++;
		}
		else
			FollowPlayer();
    }

    private void FollowPlayer()
    {
        var player = GetTree().Root.GetNode<Player>("/root/Main/Player");

		var xSpeed = 0;
		float ySpeed = 0;

		if(Math.Abs(Position.X - player.Position.X) < 64 || _dashStatus == EDashStatus.Dashing )
		{
			ySpeed = _ySpeed * 4;
			_dashStatus = EDashStatus.Dashing;



			if(Position.Y + 96 >= GetViewport().GetWindow().Size.Y && _timeDashed < 5)
			{
				_dashStatus = EDashStatus.GoingToOriginalPosition;
				_timeDashed += 1;
			}
		}
		else if(_dashStatus == EDashStatus.GoingToOriginalPosition)
		{
			ySpeed = _ySpeed * -4;

			if(Position.Y + ySpeed <=160)
			{
				_dashStatus = EDashStatus.NotDashing;
			}
		}
		else if(Position.X < player.Position.X)
		{
			xSpeed = Math.Abs(_xSpeed) * 3;
		}
		else if(Position.X > player.Position.X)
		{
			xSpeed = Math.Abs(_xSpeed) * -3;
		}

		Position = new Vector2(x: Position.X + xSpeed, y: Position.Y + ySpeed);
    }


    public void OnScreenExited()
    {
        EnemySpawner.GetEnemySpawner().RemoveEnemy(this);
    }

	public bool IsImortal()
	{
		return false;
	}


    public void Destroy()
    {
        EnemySpawner.GetEnemySpawner().DestroyEnemy(this);
    }

    public EnemyBoundy GetBoundy()
    {
        return new(2, 0, Position);
    }
}
