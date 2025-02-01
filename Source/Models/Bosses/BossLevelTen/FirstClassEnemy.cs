using System;
using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.SpaceshipPredador;
using Shooter.Source.Models.Misc;

public partial class FirstClassEnemy : Node2D, IEnemy
{
	private int _hp = 10;
	private int _Iframe = 0;
    private ProjectileManager _projectiles;
	private int _timer;
    private Player _player;
    private bool _showingIFrameAnimation;
	public bool Enable;
	private bool _followingPlayer;

	private float _yPosition;
	private float _ySpeed;

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
			FollowPlayer();
		else
		{
			Position += new Vector2(0, 12);

			_followingPlayer = Position.Y > 100;
			return;
		}

		if(_Iframe > 0)
		{
			if(_Iframe % 5 == 0)
			{
				_showingIFrameAnimation = !_showingIFrameAnimation;
			}
			_Iframe--;
			Visible = _showingIFrameAnimation;

		}else
			Visible = true;

		_timer++;
		if(_timer == 10)
			Shoot();
	}

    private void FollowPlayer()
    {
		var xspeed = 0;
		if(Position.X < _player.Position.X - 5)
		{
			xspeed = 6;
		}else if(Position.X > _player.Position.X + 5)
		{
			xspeed = -6;
		}

		Position += new Vector2(xspeed, _ySpeed);

		if(Math.Abs(_yPosition - Position.Y) < 8)
		{
			_yPosition = new Random().Next(100, 450);
			_ySpeed = new Random().Next(4, 7);

			_ySpeed *= _yPosition > Position.Y ? 1: -1;
		}
    }

    private void Shoot()
    {
        _timer = 0;

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
