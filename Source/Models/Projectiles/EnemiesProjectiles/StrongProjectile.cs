using Godot;
using System;
using Shooter.Source.Interfaces;

public partial class StrongProjectile : CharacterBody2D, IEnemyProjectile
{
	private float _Xspeed = 0;
	private float _Yspeed = 0;

	private float _speedModifier = 1;

	public int Damage = 4;
	public override void _Process(double delta)
	{
		Position += new Vector2(x: _Xspeed * _speedModifier, y: _Yspeed * _speedModifier) * (float)(delta * 60);
	}

	public void SetPosition(float x, float y)
	{
		Position = new Vector2(x, y);
	}

	public void SetSpeed(float xSpeed, float ySpeed)
	{
		_Xspeed = xSpeed;
		_Yspeed = ySpeed;
	}

	public void OnScreenExited()
	{
		var projectileManager = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");
		projectileManager.RemoveProjectile(this);
	}

    public int GetDamage()
    {
        return Damage;
    }
}
