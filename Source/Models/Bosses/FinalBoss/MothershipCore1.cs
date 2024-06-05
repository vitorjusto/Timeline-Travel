using System;
using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

public partial class MothershipCore1 : Node2D, IEnemy
{
    [Export]
    public int FinalPosition = 175;
    private WaveSpeed _ySpeed;
	private bool _entreringStage = true;
	private int _timer;

    public override void _Ready()
	{
		
	}
	public override void _Process(double delta)
	{
		if(_entreringStage)
			MoveBoss();
		else
		{
			Position = new Vector2(Position.X, _ySpeed.Update());
			_timer++;

			if(_timer > 50)
				Shoot();
		}
	}

    private void Shoot()
    {
        _timer = 0;

		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
		var angle = Math.Atan2(Position.X - player.Position.X, Position.Y - player.Position.Y);
		var projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");

		projectiles.AddProjectile(new DLightProjectile(Position.X, Position.Y, (float)Math.Sin(angle) * (-3), (float)Math.Cos(angle) * (-3)));
		projectiles.AddProjectile(new DLightProjectile(Position.X, Position.Y, (float)Math.Sin(angle + 0.6) * (-3), (float)Math.Cos(angle + 0.6) * (-3)));
		projectiles.AddProjectile(new DLightProjectile(Position.X, Position.Y, (float)Math.Sin(angle - 0.6) * (-3), (float)Math.Cos(angle - 0.6) * (-3)));
		projectiles.AddProjectile(new DLightProjectile(Position.X, Position.Y, (float)Math.Sin(angle + 0.3) * (-3), (float)Math.Cos(angle + 0.3) * (-3)));
		projectiles.AddProjectile(new DLightProjectile(Position.X, Position.Y, (float)Math.Sin(angle - 0.3) * (-3), (float)Math.Cos(angle - 0.3) * (-3)));

    }

    private void MoveBoss()
    {
        Position += new Vector2(0, 2);
		
		if(Position.Y < FinalPosition)
			return;
		
		_ySpeed = new WaveSpeed(-1, 5, Position.Y);
		_entreringStage = false;
    }

	public void OnPuncherDestroyed(Node2D node)
	{
		this.SetProcess(false);
	}

    public void Destroy()
    {
        return;
    }

    public bool IsImortal()
    {
        return true;
    }
}
