using System;
using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

public partial class MagnectGenerator : Node2D , IEnemy
{
	int _hp = GameManager.IsSpecialMode?50:10;
	[Export]
	public int Id = 0;
	int _time = 0;
	int _cycles = 0;
	bool _isEntering = true;
	bool _isAtracting = false;
	private DamageAnimationPlayer _damageAnimator;
    private ShootPoint _shootingPoint;

    public void Destroy()
    {
        _hp--;
		_damageAnimator.PlayDamageAnimation();

		if(_hp == 0)
        {
		    EmitSignal("OnEnemyDestroyed");
		    EnemySpawner.GetEnemySpawner().DestroyEnemy(this);
        }
    }

    public bool IsImortal()
    {
        return true;
    }

    public override void _Ready()
    {
        _cycles = Id * 8;

		var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
        enemySpawner.AddEnemy(this);
		_damageAnimator = new DamageAnimationPlayer(GetNode<AnimatedSprite2D>("AnimatedSprite2D"));

		_shootingPoint = GetNode<ShootPoint>("ShootPoint");
    }

    public override void _Process(double delta)
	{
		if(_isEntering)
		{
			Position = new Vector2(Position.X, Position.Y + 2);

			if(Position.Y > 90)
			{
				_isEntering = false;
				_time = 0;
			}
		}
		else if(_isAtracting)
		{
			var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
			var angle = Math.Atan2(Position.X - player.Position.X, Position.Y - player.Position.Y);

			player.SetSpeed((float)Math.Sin(angle) * (7), (float)Math.Cos(angle) * (7) );

			if(_time > 200)
			{
				StopAtracting();
			}
		}
		else if(_cycles == 28)
		{
			StartAtracting();

		}
		else
		{

			Shoot();
		}

		if(!_isAtracting)
            _damageAnimator.Process(delta);

		_time++;
	}

    private void StopAtracting()
    {
        _time = 0;
		_cycles = 0;
		_isAtracting = false;

       GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;
	   GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("default");
    }


    private void StartAtracting()
    {
       GetNode<CollisionShape2D>("CollisionShape2D").Disabled = true;
	   GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("Atracting");

	   _isAtracting = true;
    }

    private void Shoot()
    {
        if(_time < 50)
			return;

		_shootingPoint.Shoot();

        if(GameManager.IsSpecialMode)
        {
            GetNode<ShootPoint>("ShootPoint2").Shoot();
            GetNode<ShootPoint>("ShootPoint3").Shoot();
        }

		_time = 0;
		_cycles++;
    }

    public EnemyBoundy GetBoundy()
    {
        return new();
    }

    [Signal]
	public delegate void OnEnemyDestroyedEventHandler();

}
