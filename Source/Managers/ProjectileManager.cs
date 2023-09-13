using Godot;
using Shooter.Source.Dumies.Interfaces;
using System.Collections.Generic;
using Shooter.Source.Models.Levels;

public partial class ProjectileManager : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		EnemiesProjectiles = new List<Node2D>();
	}

	public List<Node2D> EnemiesProjectiles;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Shoot();
	}

    private void Shoot()
    {
        if (Input.IsActionJustPressed("shoot"))
		{
			var player = GetTree().Root.GetNode<Player>("/root/Main/Player");

			var scene = GD.Load<PackedScene>("res://Scenes/Projectiles/PlayerProjectiles/player_projectile.tscn");

            var instance = (PlayerProjectile)scene.Instantiate();

            instance.SetPosition(player.Position.X, player.Position.Y - 32);

			AddChild(instance);

		}
    }

	public void AddProjectile(IProjectileDummy projectile)
	{
		var node = projectile.GetInstance();

		EnemiesProjectiles.Add(node);
		AddChild(node);

	}

	public void PlayerHitProjectile(Node2D node)
	{
		RemoveProjectile(node);

	}

    private void RemoveProjectile(Node2D node)
    {
        EnemiesProjectiles.Remove(node);
		node.QueueFree();
    }
}
