using System;
using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

public partial class AngryCore : Node2D, IEnemy
{
    private QuickTimer _timer = new(50);
    private WaveSpeed _ySpeed;

	public override void _Ready()
	{
		_ySpeed = new WaveSpeed(-1, 5, Position.Y);
	}
	
    public override void _Process(double delta)
	{
		Position = new Vector2(Position.X, _ySpeed.Update(delta));

		if(_timer.Process(delta))
			Shoot();
	}

	private void Shoot()
    {
		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
		var angle = Math.Atan2(Position.X - player.Position.X, Position.Y - player.Position.Y);
		var projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");

		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, (float)Math.Sin(angle) * (-3), (float)Math.Cos(angle) * (-3)));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, (float)Math.Sin(angle + 0.6) * (-3), (float)Math.Cos(angle + 0.6) * (-3)));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, (float)Math.Sin(angle - 0.6) * (-3), (float)Math.Cos(angle - 0.6) * (-3)));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, (float)Math.Sin(angle + 0.3) * (-3), (float)Math.Cos(angle + 0.3) * (-3)));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, (float)Math.Sin(angle - 0.3) * (-3), (float)Math.Cos(angle - 0.3) * (-3)));

    }

    public void Destroy()
    {
        return;
    }

    public bool IsImortal()
    {
        return false;
    }

    public EnemyBoundy GetBoundy()
    {
        return new();
    }
}
