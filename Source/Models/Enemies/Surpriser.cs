using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;
using System;

public partial class Surpriser : CharacterBody2D, IEnemy
{
	private int _time;
    private CollisionShape2D _collisionShape;


    public override void _Ready()
    {
        _collisionShape = GetNode<CollisionShape2D>("CollisionShape2D");
		_collisionShape.Disabled = true;

		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");

		var x = player.Position.X  + (new Random().Next(0,3) == 1? 100: -100);
		
		var y = player.Position.Y  + (new Random().Next(0,3) == 1? 100: new Random().Next(1,3) == 1? -100: 0);

		Position = new Vector2(x, y);

    }
    public override void _Process(double delta)
    {
        _time++;

        if(_time == 40)
            Explode();
    }

    private void Explode()
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

        var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

        enemySpawner.RemoveEnemy(this);

    }


    public void Destroy()
    {
        Explode();
    }

    public bool IsImortal()
    {
        return false;
    }

}
