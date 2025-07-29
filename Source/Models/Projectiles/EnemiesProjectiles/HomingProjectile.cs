using Godot;
using System;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

public partial class HomingProjectile : CharacterBody2D, IEnemyProjectile
{	
	public float SpeedModifier = 3;

	private QuickTimer _timer = new(500);

	public int Damage = 2;

	public override void _Process(double delta)
	{
		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
		var angle = Math.Atan2(Position.X - player.Position.X, Position.Y - player.Position.Y);

		var x = Position.X + (float)Math.Sin(angle) * -SpeedModifier * (float)(delta * 60);
		var y = Position.Y + (float)Math.Cos(angle) * -SpeedModifier * (float)(delta * 60);
		Position = new Vector2(x ,y);

		if(_timer.Process(delta))
			DestroyProjectile();
	}

	public void SetPosition(float x, float y)
	{
		Position = new Vector2(x, y);
	}

	public void OnScreenExited()
	{
		DestroyProjectile();
	}

	public void DestroyProjectile()
	{

		var projectileManager = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");
		projectileManager.RemoveProjectile(this);

	}

    public int GetDamage()
    {
        return Damage;
    }

    public void SetSpeed(float XSpeed, float YSpeeed)
    {
        
    }
}
