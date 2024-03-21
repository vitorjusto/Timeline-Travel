using Godot;
using Shooter.Source.Interfaces;

public partial class BulletUp : CharacterBody2D, IPowerUp
{
    public void OnPickUp()
    {
        var p = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");

		p.PlayerProjectileLevel += 1;

		if(p.PlayerProjectileLevel > 5)
			p.PlayerProjectileLevel = 5;
			
		QueueFree();
    }

    public override void _PhysicsProcess(double delta)
	{
		Position = new Vector2(Position.X, Position.Y + 2);
	}
}
