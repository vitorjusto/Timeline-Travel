using Godot;
using Shooter.Source.Interfaces;

public partial class SpecialProjectile : CharacterBody2D, IEnemyProjectile
{
	private float _Xspeed = 0;
	private float _Yspeed = 0;

	private float _speedModifier = 5;

	public int Damage = 3;
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		Position = new Vector2(x: Position.X + (_Xspeed * _speedModifier), y: Position.Y + (_Yspeed * _speedModifier));
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
