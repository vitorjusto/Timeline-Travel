using System;
using Godot;
using Shooter.Source.Interfaces;

public partial class Player : Area2D
{

	[Export]
    public int Speed = 12; 

	[Export]
	public int DashInitialSpeed = 35;
	private int _dashSpeedBoost = 0;

	private int _iFrame = 0;
	
	[Export]
	public int IFrameTime = 50;

	private bool _showingIFrameAnimation = true;

    public Vector2 ScreenSize;

	public int Hp {get; set;}

	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
		Hp = 10;

		var animation = GetNode<AnimatedSprite2D>("AniTarget");
		animation.Hide();
	}

	public override void _Process(double delta)
	{
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
    		x: Mathf.Clamp(Position.X + velocity.X, 5, ScreenSize.X - 5),
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
	public delegate void PlayerHitEnemyEventHandler(Node2D node);
	[Signal]
	public delegate void PlayerHitProjectileEventHandler(Node2D node);

	public void OnPlayerBodyEntered(Node2D node)
	{

		if(node is IEnemy)
		{
			if(_iFrame == 0)
				Hp -= 3;

			var enemy = (IEnemy)node;

			if(!enemy.IsImortal())
				EmitSignal("PlayerHitEnemy", node);

		}else if(node is IEnemyProjectile)
		{
			if(_iFrame == 0)
				Hp -= ((IEnemyProjectile)node).GetDamage();

			EmitSignal("PlayerHitProjectile", node);
		}

		_iFrame = IFrameTime;

		EmitSignal("PlayerHpUpdated", Hp);//Não pode colocar eventhandler (mesmo que o delegate obriga a por no nome)	

	}

	public void ShowTarget()
	{
		var animation = GetNode<AnimatedSprite2D>("AniTarget");
		animation.Show();
		animation.Play("default");
	}

	public void HideTarget()
	{
		var animation = GetNode<AnimatedSprite2D>("AniTarget");
		animation.Hide();
		animation.Stop();
	}
}
