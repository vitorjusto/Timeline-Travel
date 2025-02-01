using Godot;
using System;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

public partial class Crusader : CharacterBody2D, IEnemy, INonExplodable
{
	private float _speed = 0;

	private int _time = 0;

	private bool _isExplosing = false;

	public override void _Ready()
	{
		GetNode<CollisionShape2D>("CollisionShape2D").Disabled = true;
	}

    public override void _Process(double delta)
	{
		MoveEnemy();
	}

    private void MoveEnemy()
    {
		if(_time < 150)
        	Position = new Vector2(x: Position.X, y: Position.Y + _speed);
		else if(_time == 150)
		{
			_isExplosing = true; 
            AudioManager.OnExplosion();
            
			var animation = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
			animation.Play("RayLazer");
			animation.ApplyScale(new Vector2(x: 1, y: 990));

			var collision = GetNode<CollisionShape2D>("CollisionShape2D");
			collision.ApplyScale(new Vector2(x: 1, y: 990));

			animation = GetNode<AnimatedSprite2D>("AuxAnimatedSprite");
			animation.Play("RayLazer");
			animation.ApplyScale(new Vector2(x: 1444, y: 1));

			collision = GetNode<CollisionShape2D>("AuxCollision");
			collision.ApplyScale(new Vector2(x: 1444, y: 1));
			
			GetNode<Sprite2D>("Crusader").Visible = false;

		}else if(_time == 185)
		{
        	EnemySpawner.GetEnemySpawner().RemoveEnemy(this);
		}

		_time++;
    }

	public void SetSpeed(float speed)
	{
		_speed = speed;
	}

    public void OnScreenExited()
    {
        EnemySpawner.GetEnemySpawner().RemoveEnemy(this);
    }

	public bool IsImortal()
	{
		return _isExplosing;
	}


    public void Destroy()
    {
		if(!_isExplosing)
        {
            
			_time = 150;
        }
    }

    public EnemyBoundy GetBoundy()
    {
        return new();
    }

	public void OnScreenEntered()
	{
		GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;
	}
}
