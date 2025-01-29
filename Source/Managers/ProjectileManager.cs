using Godot;
using Shooter.Source.Dumies.Interfaces;
using System.Collections.Generic;
using System;

public partial class ProjectileManager : Node2D
{
	public int PlayerProjectileLevel { 
		get => _playerProjectileLevel;
		set  { SetPlayerProjectileLevel(value); }
	}

    private void SetPlayerProjectileLevel(int value)
    {
        _playerProjectileLevel = value;
		EmitSignal("PlayerBulletUpdated", _playerProjectileLevel);
    }

    public int _playerProjectileLevel = 1;
	
	[Signal]
	public delegate void PlayerBulletUpdatedEventHandler(int currentBullet);

	public override void _Ready()
	{
		EnemiesProjectiles = new List<Node2D>();
		_player = GetTree().Root.GetNode<Player>("/root/Main/Player");
	}
	private int _autoFireCooldown = 0;
	public List<Node2D> EnemiesProjectiles;
    private Player _player;

    public override void _Process(double delta)
	{
		Shoot();
	}

    private void Shoot()
    {
		if(Input.IsActionPressed("shoot"))
		{
			_autoFireCooldown--;
			if(_autoFireCooldown == 0)
			{
				if(_player.GetFinalPowerUp)
					ShootPlayerProjectileFinalPowerUp();
				else
					ShootPlayerProjectile();

				_autoFireCooldown = 10;
			}
		}

        if (Input.IsActionJustPressed("shoot") && !Input.IsActionJustPressed("pause"))
		{
            
            GetNode<AudioStreamPlayer>("PlayerProjectilesfx").Play();
			if(_player.GetFinalPowerUp)
				ShootPlayerProjectileFinalPowerUp();
			else
				ShootPlayerProjectile();

			_autoFireCooldown = 10;
		}
    }

    private void ShootPlayerProjectileFinalPowerUp()
    {
		AddPlayerProjectile(-6, -15, -10);
		AddPlayerProjectile(-3, -20, -10);
		AddPlayerProjectile(6, -15, -10);
		AddPlayerProjectile(3, -20, -10);

		AddPlayerProjectile(-6, -15, 10);
		AddPlayerProjectile(-3, -20, 10);
		AddPlayerProjectile(6, -15, 10);
		AddPlayerProjectile(3, -20, 10);

		AddPlayerProjectile(0, -20, -32);

		AddPlayerProjectile(0, -20, 32);
    }

    private void ShootPlayerProjectile()
    {
		if(PlayerProjectileLevel == 1)
			AddPlayerProjectile(0, -20);
		else if(PlayerProjectileLevel == 2)
		{
			AddPlayerProjectile(-1, -20);
			AddPlayerProjectile(1, -20);
		}
		else if(PlayerProjectileLevel == 3)
		{
			AddPlayerProjectile(-2, -20);
			AddPlayerProjectile(2, -20);
			AddPlayerProjectile(0, -20);
		}
		else if(PlayerProjectileLevel == 4)
		{
			AddPlayerProjectile(-6, -20);
			AddPlayerProjectile(-1, -20);
			AddPlayerProjectile(1, -20);
			AddPlayerProjectile(6, -20);
		}
		else
		{
			AddPlayerProjectile(-6, -20);
			AddPlayerProjectile(-3, -20);
			AddPlayerProjectile(3, -20);
			AddPlayerProjectile(6, -20);
			AddPlayerProjectile(0, -20);
		}
    }

    private void AddPlayerProjectile(int xSpeed, int ySpeed, int xOffSet = 0)
    {
		var scene = GD.Load<PackedScene>("res://Scenes/Projectiles/PlayerProjectiles/player_projectile.tscn");

        var instance = (PlayerProjectile)scene.Instantiate();

        instance.SetPosition(_player.Position.X + xOffSet, _player.Position.Y - 32);
		
		instance.SetSpeed(xSpeed, ySpeed);

		CallDeferred("add_child", instance);
    }

    public void AddProjectile(IProjectileDummy projectile)
	{
		var node = projectile.GetInstance();
		
		EnemiesProjectiles.Add(node);
		CallDeferred("add_child", node);

	}

	public void PlayerHitProjectile(Node2D node)
	{
		RemoveProjectile(node);

	}

    public void RemoveProjectile(Node2D node)
    {
		try
		{
			EnemiesProjectiles.Remove(node);
			node.QueueFree();

		}catch(Exception)
		{
			
		}
        
    }

    internal void RemoveAllProjectiles()
    {
        while(EnemiesProjectiles.Count > 0)
		{
			RemoveProjectile(EnemiesProjectiles[0]);
		}
    }

}
