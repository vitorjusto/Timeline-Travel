using System;
using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.BossLevelNine.States;
using Shooter.Source.Models.Misc;

public partial class FourDWarMachine : Node2D, IEnemy
{
	private IState _state;
	private int _hp = 200;
	private int _orbiters = 8;
	private bool _HalfHealthEventTrigered = false;
	public override void _Ready()
	{
		_state = new MovingState(this);
		SetProcess(false);
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
		_orbiters--;

		if(_orbiters == 0)
			EmitHalfHealthEvent();
	}

    private void EmitHalfHealthEvent()
    {
		if(_HalfHealthEventTrigered)
			return;

        EmitSignal("OnHalfHealth");
		EmitSignal("ChangeShootingState", false);
		_HalfHealthEventTrigered = true;
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

		if(_hp == 100)
		{
			EmitHalfHealthEvent();
		}

		if(_hp == 0)
		{
			_state = _state.NextState();

			foreach(Node2D node in GetChildren())
			{
				if(node is not OrbiterProtection)
					continue;
					
				OnOrbiterDestroyed(node);
			}
		}
    }

    public bool IsImortal()
    {
        return true;
    }

	[Signal]
	public delegate void OnActivatedEventHandler();
	[Signal]
	public delegate void OnHalfHealthEventHandler();
	[Signal]
	public delegate void ChangeShootingStateEventHandler(bool state);
	public void TransitionEnded()
	{
		_state = _state.NextState();
	}

    public EnemyBoundy GetBoundy()
    {
        return new();
    }
}
