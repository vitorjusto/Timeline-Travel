using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

public partial class FinalPowerUp : CharacterBody2D, IPowerUp
{
	public WaveSpeed _yspeed;

    public void OnPickUp()
    {
		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");

		GiveFinalPowerUpStatus(player);

		EmitSignal("OnGetPowerUp");
		QueueFree();
		
    }

	public static void GiveFinalPowerUpStatus(Player player)
	{
		player.GetFinalPowerUp = true;

		player.GetNode<Sprite2D>("SpaceshipUpgrade").Visible = true;
		player.GetNode<AnimatedSprite2D>("AnimatedSprite2D").Visible = false;

		player.GetNode<CollisionShape2D>("SpaceshipUpgradeColision").SetDeferred("disable", false);

		player.Hp = 100;
	}
	
	public override void _Ready()
	{
		SetProcess(false);
		Visible = false;
		GetNode<CollisionShape2D>("CollisionShape2D").Disabled = true;
		_yspeed = new WaveSpeed(-1, 5, Position.Y);
	}
    public override void _Process(double delta)
	{
		Position = new Vector2(Position.X, _yspeed.Update());
	}
	public void OnBossDestroyed()
	{
		SetProcess(true);
		Visible = true;
		GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;
	}

	[Signal]
	public delegate void OnGetPowerUpEventHandler();
    
}
