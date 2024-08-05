using System;
using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Enums;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

public partial class SpaceScrap : CharacterBody2D, IEnemy
{

	public float XSpeed;
	public float YSpeed;
    public ESpaceScrapType SpaceScrapType;
    private int _timer;
    public override void _Process(double delta)
	{
		Position += new Vector2(XSpeed, YSpeed);

        _timer++;
        if(SpaceScrapType == ESpaceScrapType.Sniper && _timer == 70)
            Shoot();
	}

    private void Shoot()
    {
        var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
		var angle = Math.Atan2(Position.X - player.Position.X, Position.Y - player.Position.Y);
		var projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");

		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y + 41, (float)Math.Sin(angle) * (-3), (float)Math.Cos(angle) * (-3)));

    }

    public void OnScreenExited()
    {
        Destroy();
    }

	public void Destroy()
    {
        if(SpaceScrapType == ESpaceScrapType.Bomber)
            Explode();

        var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
		enemySpawner.RemoveEnemy(this);
    }

    public void Explode()
    {
        var projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 5, 5));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 5, -5));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, -5, 5));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, -5, -5));

		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 5, 0));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 0, 5));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, -5, 0));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 0, -5));

		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 5, 2.5f));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, -5, 2.5f));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 2.5f, 5));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 2.5f, -5));

		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 5, -2.5f));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, -5, -2.5f));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, -2.5f, 5));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, -2.5f, -5));
    }

    public void UpdateType(ESpaceScrapType type)
    {
        GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play(type.ToString());
        SpaceScrapType = type;
    }

    public bool IsImortal()
    {
        return false;
    }

    public EnemyBoundy GetBoundy()
    {
        return new(1, 0, Position);
    }
}
