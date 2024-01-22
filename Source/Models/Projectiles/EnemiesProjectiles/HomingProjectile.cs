using Godot;
using System;
using Shooter.Source.Interfaces;

public partial class HomingProjectile : CharacterBody2D, IEnemyProjectile
{	
	private float _speedModifier = 5;

	private int _time = 0;

	public int Damage = 2;
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
		var angle = Math.Atan2(Position.X - player.Position.X, Position.Y - player.Position.Y);

		var x = Position.X + (float)Math.Sin(angle) * -_speedModifier;
		var y = Position.Y + (float)Math.Cos(angle) * -_speedModifier;
		Position = new Vector2(x ,y);

		if(_time > 500)
			DestroyProjectile();

		_time++;
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
}
