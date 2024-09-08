using System;
using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

public partial class GigantBomb : CharacterBody2D, IEnemy
{
	private float _ySpeed = -10;
	public float XSpeed = 0;
	public override void _Ready()
	{
		Rotation = new Random().Next(0, 360);
	}

	public override void _Process(double delta)
	{
		Position += new Vector2(XSpeed, _ySpeed);

		if(_ySpeed < 20)
			_ySpeed += 0.5f;

		Rotation += 0.05f;

		if(Rotation == 360)
			Rotation = 0;
	}

    public void Destroy()
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

        EnemySpawner.GetEnemySpawner().DestroyEnemy(this);
    }

    public bool IsImortal()
    {
        return false;
    }

	public void OnScreenExited()
	{
        EnemySpawner.GetEnemySpawner().RemoveEnemy(this);
	}

    public EnemyBoundy GetBoundy()
    {
        return new();
    }
}
