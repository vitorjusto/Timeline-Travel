using Godot;
using Shooter.Source.Interfaces;

public partial class NormalProjectile : CharacterBody2D, IEnemyProjectile
{
	
	private float _Xspeed = 0;
	private float _Yspeed = 0;

	public int Damage = 2;
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position = new Vector2(x: Position.X + _Xspeed, y: Position.Y + _Yspeed);
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
		QueueFree();
	}

	public void OnBodyEntered(Node2D node)
	{
		var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

		enemySpawner.RemoveEnemy(node);

		QueueFree();
	}

    public int GetDamage()
    {
        return Damage;
    }

}
