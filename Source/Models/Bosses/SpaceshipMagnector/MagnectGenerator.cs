using System;
using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;

public partial class MagnectGenerator : Node2D , IEnemy
{
	int _hp = 10;
	[Export]
	public int Id = 0;
	int _time = 0;
	int _cycles = 0;
	bool _isEntering = true;
	bool _isAtracting = false;
    public void Destroy()
    {
        _hp--;

		if(_hp > 0)
			return;

		EmitSignal("OnEnemyDestroyed");
		var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
        enemySpawner.RemoveEnemy(this);
    }

    public bool IsImortal()
    {
        return true;
    }

    public override void _Ready()
    {
        _cycles = Id * 8;

		var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
        enemySpawner.AddEnemy(this);
    }

    public override void _Process(double delta)
	{
		if(_isEntering)
		{
			Position = new Vector2(Position.X, Position.Y + 2);

			if(Position.Y > 90)
			{
				_isEntering = false;
				_time = 0;
			}
		}
		else if(_isAtracting)
		{
			var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
			var angle = Math.Atan2(Position.X - player.Position.X, Position.Y - player.Position.Y);

			player.SetSpeed((float)Math.Sin(angle) * (7), (float)Math.Cos(angle) * (7) );

			if(_time > 200)
			{
				StopAtracting();
			}
		}
		else if(_cycles == 28)
		{
			StartAtracting();

		}
		else
		{

			Shoot();
		}

		_time++;
	}

    private void StopAtracting()
    {
        _time = 0;
		_cycles = 0;
		_isAtracting = false;

		GetNode<Node2D>("AtractingAnimation").Visible = false;
       GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;
    }


    private void StartAtracting()
    {
       GetNode<Node2D>("AtractingAnimation").Visible = true;
       GetNode<CollisionShape2D>("CollisionShape2D").Disabled = true;

	   _isAtracting = true;
    }


    private void Shoot()
    {
        if(_time < 50)
			return;

		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
		var angle = Math.Atan2(Position.X - player.Position.X, Position.Y - player.Position.Y);
		var projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");

		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, (float)Math.Sin(angle) * (-3), (float)Math.Cos(angle) * (-3)));

		_time = 0;
		_cycles++;
    }

	[Signal]
	public delegate void OnEnemyDestroyedEventHandler();

}
