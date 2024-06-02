using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

public partial class FinalPowerUp : CharacterBody2D, IPowerUp
{
	public WaveSpeed _yspeed;
    public void OnPickUp()
    {
        return;
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
		GD.Print(GetNode<CollisionShape2D>("CollisionShape2D").Disabled);
	}
	public void OnBossDestroyed()
	{
		SetProcess(true);
		Visible = true;
		GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;
	}
}
