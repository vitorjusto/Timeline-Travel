using Godot;
using Shooter.Source.Interfaces;

public partial class BulletUp : Node2D, IPowerUp
{
    public void OnPickUp()
    {
        var p = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");

		p.PlayerProjectileLevel += 1;

		if(p.PlayerProjectileLevel > 5)
		{

			var player = GetTree().Root.GetNode<Player>("/root/Main/Player");

            if(!EnemySpawner.GetEnemySpawner().isBossRush)
			    player.AddLifeProgress();

			p.PlayerProjectileLevel = 5;
		}
		QueueFree();
    }

    public override void _Process(double delta)
	{
		Position = new Vector2(Position.X, Position.Y + 2);
	}

}
