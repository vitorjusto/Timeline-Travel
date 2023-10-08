using Godot;
using System;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;
using Shooter.Source.Enums;
using Shooter.Source.Dumies.Enemies;
using System.Threading;

public partial class BlackHoleGenerator : CharacterBody2D, IEnemy
{

	private int _speed = 3;
    private bool _isDestroing = false;
    private int _time = 0;
	private bool _walking = false;

	private int _hp = 2;

	public EEnemyProjectileType ProjectileType;

	private int _damageAnimation = 0;

	private BlackHoleGeneratorPart _arm1;
	private BlackHoleGeneratorPart _arm2;
    private EnemySpawner _enemySpawner;

    public override void _Ready()
	{
		_arm1 = GetNode<BlackHoleGeneratorPart>("Arm1");
		_arm1.InvertArm();

		_arm2 = GetNode<BlackHoleGeneratorPart>("Arm2");
		_enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
	}

    public override void _Process(double delta)
	{

		if(_isDestroing)
			DestroyAnimation();
		else if(_walking)
			WalkEnemy();
		else
			MoveEnemy();

		_time++;
	}

    private void DestroyAnimation()
    {
		_enemySpawner.AddExplosion(Position.X + (new Random().Next(-100, 100)), Position.Y + (new Random().Next(-100, 100)));

		if(_time == 300)
		{
			_enemySpawner.EndLevel();
			_enemySpawner.RemoveEnemy(this);

		}
    }

    private void WalkEnemy()
	{

		Position = new Vector2(x: Position.X + _speed, y: Position.Y);

		if(Position.X > 1212 || Position.X < 232)
			_speed *= -1;

		if(_time == 100)
		{
			var number = new Random().Next(1, 3);

			if(number == 1)
			{
				_arm1.ShowBlackHole = true;
			}else
			{
				_arm2.ShowBlackHole = true;
			}

		}else if(_time == 300)
		{
			_arm1.ShowBlackHole = false;

			_arm2.ShowBlackHole = false;

			_time = 0;
		}

		_arm1.RelativeX = Position.X;
		_arm1.RelativeY = Position.Y;

		_arm2.RelativeX = Position.X;
		_arm2.RelativeY = Position.Y;

		if(_damageAnimation > 0)
		{
			_damageAnimation--;

			if(_damageAnimation == 0)
			{
				var animation = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
				animation.Play("Idle");
			}
		}

		if(_enemySpawner.Enemies.Count == 0)
		{
			_enemySpawner.AddEnemy(new DShoter(100, EEnemyProjectileType.Normal));
			_enemySpawner.AddEnemy(new DShoter(1000, EEnemyProjectileType.Normal));

		}

	}

    private void MoveEnemy()
    {
		if(_time < 100)
		{
        	Position = new Vector2(x: 722, y: Position.Y + _speed);

		}else
		{
			_walking = true;
			_time = 0;
		}

    }

	public void Destroy()
	{

	}

	public bool IsImortal()
	{
		return true;
	}

	public void OnDestroyArm()
	{
		_hp--;

		if(_hp == 0)
		{
			var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
			_enemySpawner.RemoveAllEnemies();
			_isDestroing = true;
			_time = 0;
		}
	}

}
