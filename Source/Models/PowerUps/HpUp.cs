using Godot;
using Shooter.Source.Interfaces;

public partial class HpUp : CharacterBody2D, IPowerUp
{
    public void OnPickUp()
    {
        var player = GetTree().Root.GetNode<Player>("/root/Main/Player");

		player.Hp += 5;

		if(player.Hp > 10)
			player.Hp = 10;

		QueueFree();
    }

    public override void _PhysicsProcess(double delta)
	{
		Position = new Vector2(Position.X, Position.Y + 2);
	}
}
