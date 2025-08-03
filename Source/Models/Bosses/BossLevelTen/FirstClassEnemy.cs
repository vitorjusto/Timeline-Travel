using System;
using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.SpaceshipPredador;
using Shooter.Source.Models.Misc;

public partial class FirstClassEnemy : Node2D, IEnemy
{
	private int _hp = 10;
	private float _Iframe = 0;
    private ProjectileManager _projectiles;
	private QuickTimer _timer = new(15);
    private Player _player;
    private bool _showingIFrameAnimation;
	public bool Enable;
	private bool _followingPlayer;

	private float _yPosition;
	private float _ySpeed;
    private float _IframeAnimation;

    public override void _Ready()
	{
		_projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");
		Position = new Vector2((int)ProjectSettings.GetSetting("display/window/size/viewport_width")/2, -100);

		_player = GetTree().Root.GetNode<Player>("/root/Main/Player");

		_yPosition = new Random().Next(200, 450);
		_ySpeed = new Random().Next(1, 5);
	}

    public override void _Process(double delta)
	{
		if(!Enable)
			return;

		if(_followingPlayer)
			FollowPlayer(delta);
		else
		{
			Position += new Vector2(0, 12) * (float)(delta * 60);

			_followingPlayer = Position.Y > 100;
			return;
		}

		if(_Iframe > 0)
		{
			if(_IframeAnimation <= 0)
			{
				_showingIFrameAnimation = !_showingIFrameAnimation;
                _IframeAnimation += 5;
            }
			_Iframe-= (float)(delta * 60);
			_IframeAnimation-= (float)(delta * 60);

			Visible = _showingIFrameAnimation;

		}else
			Visible = true;

		if(_timer.Process(delta))
			Shoot();
	}

    private void FollowPlayer(double delta)
    {
		var xspeed = 0;
		if(Position.X < _player.Position.X - 5)
		{
			xspeed = 6;
		}else if(Position.X > _player.Position.X + 5)
		{
			xspeed = -6;
		}

		Position += new Vector2(xspeed, _ySpeed) * (float)(delta * 60);

		if(Math.Abs(_yPosition - Position.Y) < 8)
		{
			_yPosition = new Random().Next(100, 450);
			_ySpeed = new Random().Next(4, 7);

			_ySpeed *= _yPosition > Position.Y ? 1: -1;
		}
    }

    private void Shoot()
    {
        if(GameManager.IsSpecialMode)
        {
		    _projectiles.AddProjectile(new DLightProjectile(Position.X - 10, Position.Y + 32, -6, 2));
		    _projectiles.AddProjectile(new DLightProjectile(Position.X - 10, Position.Y + 32, -3, 3));
		    _projectiles.AddProjectile(new DLightProjectile(Position.X - 10, Position.Y + 32, 6, 2));
		    _projectiles.AddProjectile(new DLightProjectile(Position.X - 10, Position.Y + 32, 3, 2));

		    _projectiles.AddProjectile(new DLightProjectile(Position.X + 10, Position.Y + 32, -6, 2));
		    _projectiles.AddProjectile(new DLightProjectile(Position.X + 10, Position.Y + 32, -3, 3));
		    _projectiles.AddProjectile(new DLightProjectile(Position.X + 10, Position.Y + 32, 6, 2));
		    _projectiles.AddProjectile(new DLightProjectile(Position.X + 10, Position.Y + 32, 3, 2));

		    _projectiles.AddProjectile(new DLightProjectile(Position.X - 32, Position.Y + 32, 0, 3));
		    _projectiles.AddProjectile(new DLightProjectile(Position.X + 32, Position.Y + 32, 0, 3));
            return;
        }

		_projectiles.AddProjectile(new DLightProjectile(Position.X, Position.Y, 0, 4));
    }

    public void Destroy()
    {
		if(_Iframe > 0)
			return;
		
		_Iframe = 60;
        _hp--;

		if(_hp == 0)
		{
			EnemySpawner.GetEnemySpawner().DestroyEnemy(this);
			_projectiles.RemoveAllProjectiles();
			
			EmitSignal("BossDefeated");
		}	
    }

	[Signal]
	public delegate void BossDefeatedEventHandler();

    public bool IsImortal()
    {
        return true;
    }

    public EnemyBoundy GetBoundy()
    {
        return new();
    }
}
