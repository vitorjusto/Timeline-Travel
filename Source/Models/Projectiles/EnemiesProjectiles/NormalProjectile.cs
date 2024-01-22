using Godot;
using Shooter.Source.Interfaces;

public partial class NormalProjectile : CharacterBody2D, IEnemyProjectile
{
	
	private float _Xspeed = 0;
	private float _Yspeed = 0;
	private float _speedModifier = 2;
	public int Damage = 2;
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
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
