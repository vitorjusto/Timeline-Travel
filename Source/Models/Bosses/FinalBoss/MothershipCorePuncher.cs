using System;
using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

public partial class MothershipCorePuncher : Node2D, IEnemy, IEnableNotifier
{
    private WaveSpeed _idleySpeed;
    private float _ySpeed;
    private float _xSpeed;

	private Vector2 _idlePosition;

	private bool _entreringStage = true;
	private int _timer;
	private int _timerDashing;

    private Player _player;
	private bool _dashing;
	private int _hp = 180;
    private bool _damageDisabled;
    private DamageAnimationPlayer _damageAnimator;

    public override void _Ready()
	{
		_player = GetTree().Root.GetNode<Player>("/root/Main/Player");
		_damageAnimator = new DamageAnimationPlayer(GetNode<AnimatedSprite2D>("AniPuncher"));
	}
	
	public override void _Process(double delta)
	{
		_damageAnimator.Process();

		if(_entreringStage)
			MoveBoss();
		else if(_dashing)
			Dash();
		else
		{
			Position = new Vector2(Position.X, _idleySpeed.Update());

			if(!_damageDisabled)
				_timer++;

			_dashing = _timer > 50;
		}
	}

    private void Animate()
    {
		var angle = Math.Atan2(Position.X - _player.Position.X, Position.Y - _player.Position.Y);
		var speed = new Vector2((float)Math.Sin(angle), (float)Math.Cos(angle));

		GetNode<Node2D>("AniPuncher").Rotation = 1.5708f;
		Rotation = speed.Angle();
    }

    private void Dash()
    {
		_timerDashing++;
		
        if(_timerDashing == 1)
		{
			_player.ShowTarget();
			Animate();
		}
		else if(_timerDashing < 50)
		{
			Animate();
		}
		else if(_timerDashing == 50)
		{
			_player.HideTarget();
			var angle = Math.Atan2(Position.X - _player.Position.X, Position.Y - _player.Position.Y);

			_xSpeed = (float)Math.Sin(angle) * (-20);
			_ySpeed = (float)Math.Cos(angle) * (-20);

		}else if(_timerDashing == 100)
		{
			var angle = Math.Atan2(Position.X - _idlePosition.X, Position.Y - _idlePosition.Y);

			_xSpeed = (float)Math.Sin(angle) * (-20);
			_ySpeed = (float)Math.Cos(angle) * (-20);

		}
		else if(_timerDashing == 150)
		{
			_xSpeed = 0;
			_ySpeed = 0;
			_dashing = false;
			_timerDashing = 0;

			Position = _idlePosition;
			_timer = 0;
		}
		
		Position += new Vector2(_xSpeed, _ySpeed);
    }

    private void MoveBoss()
    {
        Position += new Vector2(0, 2);
		
		if(Position.Y < 175)
			return;
		
		_idleySpeed = new WaveSpeed(-1, 5, Position.Y);
		_idlePosition = Position;
		_entreringStage = false;
    }

	public void Destroy()
    {
		if(_damageDisabled)
			return;

		_hp--;

		if(_hp == 0)
		{
			_player.HideTarget();
			_damageAnimator.PlayDefaultAnimation();
			EmitSignal("OnPuncherDestroing", this);
		}
		else if(_hp > 0)
			_damageAnimator.PlayDamageAnimation();

    }

    public bool IsImortal()
    {
        return true;
    }

	public void OnOtherPuncherDestroing(Node2D node)
	{
		_damageDisabled = true;
	}

    public void OnEnable()
    {
        _damageDisabled = false;
    }

    public EnemyBoundy GetBoundy()
    {
        return new();
    }

    [Signal]
	public delegate void OnPuncherDestroingEventHandler(Node2D node);
}