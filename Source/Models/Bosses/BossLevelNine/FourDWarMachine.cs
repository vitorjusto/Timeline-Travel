using System;
using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.BossLevelNine.States;

public partial class FourDWarMachine : Node2D, IEnemy
{
	private IState _state;
	private int _hp = 200;
	public override void _Ready()
	{
		SetProcess(false);
		_state = new MovingState(this);

	}

	public override void _Process(double delta)
	{
		if(_state.Process())
			_state = _state.NextState();
	}

	public void OnOrbiterDestroyed(Node2D node)
	{
		GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner").AddExplosion(node.Position + Position);
		node.CallDeferred("queue_free");

	}

	public void OnOrbiterShoot(Node2D node)
	{
		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
		var angle = Math.Atan2(Position.X + node.Position.X - player.Position.X, Position.Y + node.Position.Y - player.Position.Y);
		var projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");

		projectiles.AddProjectile(new DLightProjectile(Position.X + node.Position.X, Position.Y + node.Position.Y, (float)Math.Sin(angle) * (-3), (float)Math.Cos(angle) * (-3)));
		projectiles.AddProjectile(new DLightProjectile(Position.X + node.Position.X, Position.Y + node.Position.Y, (float)Math.Sin(angle + 0.7) * (-3), (float)Math.Cos(angle + 0.6) * (-3)));
		projectiles.AddProjectile(new DLightProjectile(Position.X + node.Position.X, Position.Y + node.Position.Y, (float)Math.Sin(angle - 0.7) * (-3), (float)Math.Cos(angle - 0.6) * (-3)));
		projectiles.AddProjectile(new DNormalProjectile(Position.X + node.Position.X, Position.Y + node.Position.Y, (float)Math.Sin(angle + 0.3) * (-3), (float)Math.Cos(angle + 0.3) * (-3)));
		projectiles.AddProjectile(new DNormalProjectile(Position.X + node.Position.X, Position.Y + node.Position.Y, (float)Math.Sin(angle - 0.3) * (-3), (float)Math.Cos(angle - 0.3) * (-3)));
	}

    public void Destroy()
    {
        _hp--;
    }

    public bool IsImortal()
    {
        return true;
    }

	[Signal]
	public delegate void OnActivatedEventHandler();
}
