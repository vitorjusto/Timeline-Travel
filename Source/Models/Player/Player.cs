using System;
using Godot;
using Shooter.Source.Interfaces;

public partial class Player : Area2D
{

	[Export]
    public int Speed = 12; 

	[Export]
	public int DashInitialSpeed = 45;
	private int _dashSpeedBoost = 0;
	private int _iFrame = 0;
	
	[Export]
	public int IFrameTime = 50;

	private bool _showingIFrameAnimation = true;

    public Vector2 ScreenSize;
    private bool _unableToMove;
    private bool _playerDestroyed;
	private int _time = 0;
    public int Hp {get; set;}
    public bool GetFinalPowerUp { get; internal set; }

    public int Life = 3;
    private GameManager _gameManager;
	private int _playerHitTimes = 0;
	//Player will not take damage if _playerImortal is true, this property is only used for debugging proporses
	private bool _playerImortal = false;
    private int _minLimit = 32;
    private int _maxLimit;
    private int _targetCount;

    public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
		_maxLimit = (int)ScreenSize.X - 32;
		Hp = 10;

		var animation = GetNode<AnimatedSprite2D>("AniTarget");
		animation.Hide();

		_gameManager = GetTree().Root.GetNode<GameManager>("/root/Main");
	}

	public override void _Process(double delta)
	{
		if(_gameManager.IsBlackScreen)
			return;

		if(_playerDestroyed)
		{
			_time++;

			if(_time > 20)
			{
				_time = 0;
				EmitSignal("PlayerDestroyed");
				_playerDestroyed = false;
			}

			return;

		}

		MovePlayer();
		AnimateIFrame();
	}

    private void AnimateIFrame()
    {
        if(_iFrame > 0)
		{
			if(_iFrame % 5 == 0)
			{
				_showingIFrameAnimation = !_showingIFrameAnimation;
			}

			Visible = _showingIFrameAnimation;

			_iFrame--;

		}else
		{
			Show();
			_showingIFrameAnimation = true;
		}
    }

    private void MovePlayer()
    {
		if(_unableToMove)
			return;

        var velocity = Vector2.Zero; 

		int currentSpeed = GetCurrentSpeed();

    	if (Input.IsActionPressed("move_right"))
    	{
        	velocity.X += currentSpeed;
    	}

    	if (Input.IsActionPressed("move_left"))
    	{
        	velocity.X -= currentSpeed;
    	}

    	if (Input.IsActionPressed("move_down"))
    	{
        	velocity.Y += currentSpeed;
    	}

    	if (Input.IsActionPressed("move_up"))
    	{
        	velocity.Y -= currentSpeed;
    	}

		Position = new Vector2(
    		x: Mathf.Clamp(Position.X + velocity.X, _minLimit, _maxLimit),
    		y: Mathf.Clamp(Position.Y + velocity.Y, 5, ScreenSize.Y - 5)
		);

    }

    private int GetCurrentSpeed()
    {
        if(Input.IsActionJustPressed("dash") && _dashSpeedBoost <= 0)
		{
			_dashSpeedBoost = DashInitialSpeed;
		}
		else if(_dashSpeedBoost > 0)
		{
			_dashSpeedBoost -= 4;

			if(_dashSpeedBoost < 0)
				_dashSpeedBoost = 0;
		}

		return Speed + _dashSpeedBoost;
    }

	[Signal]
	public delegate void PlayerHpUpdatedEventHandler(int currentHp);

	[Signal]
	public delegate void PlayerHitProjectileEventHandler(Node2D node);

	public void OnPlayerBodyEntered(Node2D node)
	{
		if(_playerDestroyed || _playerImortal)
			return;

		if(node is IPowerUp)
		{
			if(GetFinalPowerUp)
				return;
				
			var powerUp = (IPowerUp)node;

			powerUp.OnPickUp();
			EmitSignal("PlayerHpUpdated", Hp);
			return;
		}

		if(node is IEnemy)
		{
			if(_iFrame == 0)
				Hp -= 2;

			var enemy = (IEnemy)node;

			if(!enemy.IsImortal())
				enemy.Destroy();

		}else if(node is IEnemyProjectile)
		{
			if(_iFrame == 0)
				Hp -= ((IEnemyProjectile)node).GetDamage();

			EmitSignal("PlayerHitProjectile", node);
		}

		if(_iFrame == 0)
		{
			var projectileManager = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");

			projectileManager.PlayerProjectileLevel -= 1;

			if(projectileManager.PlayerProjectileLevel < 1)
				projectileManager.PlayerProjectileLevel = 1;
				
		}
		if(_iFrame == 0)
			_iFrame = IFrameTime;

		if(Hp <= 0)
		{
			DestroyPlayer();
		}

		EmitSignal("PlayerHpUpdated", Hp);//Não pode colocar eventhandler (mesmo que o delegate obriga a por no nome)

	}

    public void DestroyPlayer()
    {
        Hp = 0;

		EnemySpawner.GetEnemySpawner().AddExplosion(Position.X, Position.Y, addScore: false);
		Visible = false;

		_playerDestroyed = true;

		EmitSignal("PlayerHpUpdated", Hp);
    }

    [Signal]
	public delegate void PlayerDestroyedEventHandler();	
	[Signal]
	public delegate void PlayerLifeUpdatedEventHandler(int life);

	public void SetSpeed(float xspeed, float yspeed, int limit = 5)
	{
		Position = new Vector2(
    		x: Mathf.Clamp(Position.X + xspeed, limit, ScreenSize.X - limit),
    		y: Mathf.Clamp(Position.Y + yspeed, limit, ScreenSize.Y - limit)
		);
	}

	public void SetSizeLimit(int min, int max)
	{
		_minLimit = min;
		_maxLimit = max;
	}

	public void SetDefaultLimit()
	{
		_minLimit = 5;
		_maxLimit = (int)ScreenSize.X - 5;;
	}

	public void ShowTarget()
	{
		var animation = GetNode<AnimatedSprite2D>("AniTarget");
		animation.Show();
		animation.Play("default");
		_targetCount++;
	}

	public void HideTarget()
	{
		_targetCount--;

		if(_targetCount > 0)
			return;


		var animation = GetNode<AnimatedSprite2D>("AniTarget");
		animation.Hide();
		animation.Stop();
		_targetCount = 0;
	}

	public void ResetTargetCount()
	{
		_targetCount = 0;
		
		var animation = GetNode<AnimatedSprite2D>("AniTarget");
		animation.Hide();
		animation.Stop();
	}

	public void OnEndingLevel()
		=> DisablePlayerToMove();

	public void EnablePlayerToMove()
		=> _unableToMove = false;

	public void DisablePlayerToMove()
		=> _unableToMove = true;
}
