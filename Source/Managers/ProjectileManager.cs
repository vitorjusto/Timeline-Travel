using Godot;
using Shooter.Source.Dumies.Interfaces;
using System.Collections.Generic;
using System;

public partial class ProjectileManager : Node2D
{
	public int PlayerProjectileLevel = 1;
	public override void _Ready()
	{
		EnemiesProjectiles = new List<Node2D>();
	}
	private int _autoFireCooldown = 0;
	public List<Node2D> EnemiesProjectiles;

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
				ShootPlayerProjectile();
				_autoFireCooldown = 10;
			}
		}

        if (Input.IsActionJustPressed("shoot") && !Input.IsActionJustPressed("pause"))
		{
			ShootPlayerProjectile();
			_autoFireCooldown = 10;
		}
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

    private void AddPlayerProjectile(int xSpeed, int ySpeed)
    {
        var player = GetTree().Root.GetNode<Player>("/root/Main/Player");

		var scene = GD.Load<PackedScene>("res://Scenes/Projectiles/PlayerProjectiles/player_projectile.tscn");

        var instance = (PlayerProjectile)scene.Instantiate();

        instance.SetPosition(player.Position.X, player.Position.Y - 32);
		
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
