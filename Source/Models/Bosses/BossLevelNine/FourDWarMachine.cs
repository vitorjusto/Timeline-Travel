using System;
using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.BossLevelNine.States;
using Shooter.Source.Models.Misc;

public partial class FourDWarMachine : Node2D, IEnemy
{
	private IState _state;
	private int _hp = GameManager.IsSpecialMode?1000:300;
	private int _orbiters = 8;
	private bool _HalfHealthEventTrigered = false;
	public bool DestroingPlayer = false;
	public bool Active = false;

    private DamageAnimationPlayer _damageAnimator;

	public override void _Ready()
	{
		_state = new MovingState(this);
		Active = false;
		_damageAnimator = new DamageAnimationPlayer(GetNode<AnimatedSprite2D>("AnimatedSprite2D"));
	}

	public override void _Process(double delta)
	{
		if(_state.Process())
			_state = _state.NextState();
		
		if(!IsTimeTravelTransition() && !DestroingPlayer)
			_damageAnimator.Process();

		if(_hp > 0 && !DestroingPlayer && _HalfHealthEventTrigered && !IsTimeTravelTransition() && GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner").EnemiesSectionEmpty)
		{
			foreach(Node2D node in GetChildren())
			{
				if(node is not OrbiterProtection)
					continue;
					
				OnOrbiterDestroyed(node);
			}

			DestroingPlayer = true;
			_state = new StartCruchingPlayerState(this);
		}
	}

	public void OnOrbiterDestroyed(Node2D node)
	{
		GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner").AddExplosion(node.Position + Position);
		node.CallDeferred("queue_free");
		_orbiters--;

		ExplodeOrbiter(node);
		
		if(_orbiters == 0)
			EmitHalfHealthEvent();
	}

    private void ExplodeOrbiter(Node2D node)
    {
		var projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");

		projectiles.AddProjectile(new DLightProjectile(Position.X + node.Position.X, Position.Y + node.Position.Y, -3,-3));
		projectiles.AddProjectile(new DLightProjectile(Position.X + node.Position.X, Position.Y + node.Position.Y, 0, -3));
		projectiles.AddProjectile(new DLightProjectile(Position.X + node.Position.X, Position.Y + node.Position.Y, 3, -3));
		projectiles.AddProjectile(new DLightProjectile(Position.X + node.Position.X, Position.Y + node.Position.Y, 3, 0));
		projectiles.AddProjectile(new DLightProjectile(Position.X + node.Position.X, Position.Y + node.Position.Y, 3, 3));
		projectiles.AddProjectile(new DLightProjectile(Position.X + node.Position.X, Position.Y + node.Position.Y, 0, 3));
		projectiles.AddProjectile(new DLightProjectile(Position.X + node.Position.X, Position.Y + node.Position.Y, -3, 3));
		projectiles.AddProjectile(new DLightProjectile(Position.X + node.Position.X, Position.Y + node.Position.Y, -3, 0));

		projectiles.AddProjectile(new DNormalProjectile(Position.X + node.Position.X, Position.Y + node.Position.Y, -3,-3));
		projectiles.AddProjectile(new DNormalProjectile(Position.X + node.Position.X, Position.Y + node.Position.Y, 0, -3));
		projectiles.AddProjectile(new DNormalProjectile(Position.X + node.Position.X, Position.Y + node.Position.Y, 3, -3));
		projectiles.AddProjectile(new DNormalProjectile(Position.X + node.Position.X, Position.Y + node.Position.Y, 3, 0));
		projectiles.AddProjectile(new DNormalProjectile(Position.X + node.Position.X, Position.Y + node.Position.Y, 3, 3));
		projectiles.AddProjectile(new DNormalProjectile(Position.X + node.Position.X, Position.Y + node.Position.Y, 0, 3));
		projectiles.AddProjectile(new DNormalProjectile(Position.X + node.Position.X, Position.Y + node.Position.Y, -3, 3));
		projectiles.AddProjectile(new DNormalProjectile(Position.X + node.Position.X, Position.Y + node.Position.Y, -3, 0));
    }

    private void EmitHalfHealthEvent()
    {
		if(_HalfHealthEventTrigered)
			return;

		GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("BreakingFourthDimention");
        EmitSignal("OnHalfHealth");
		EmitSignal("ChangeShootingState", false);
		_HalfHealthEventTrigered = true;
    }

    public void OnOrbiterShoot(Node2D node)
	{
		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
		var angle = Math.Atan2(Position.X + node.Position.X - player.Position.X, Position.Y + node.Position.Y - player.Position.Y);
		var projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");

		projectiles.AddProjectile(new DLightProjectile(Position.X + node.Position.X, Position.Y + node.Position.Y + 28, (float)Math.Sin(angle) * (-3), (float)Math.Cos(angle) * (-3)));
		projectiles.AddProjectile(new DLightProjectile(Position.X + node.Position.X + 29, Position.Y + node.Position.Y + 19, (float)Math.Sin(angle + 0.7) * (-3), (float)Math.Cos(angle + 0.6) * (-3)));
		projectiles.AddProjectile(new DLightProjectile(Position.X + node.Position.X - 29, Position.Y + node.Position.Y + 19, (float)Math.Sin(angle - 0.7) * (-3), (float)Math.Cos(angle - 0.6) * (-3)));
		projectiles.AddProjectile(new DNormalProjectile(Position.X + node.Position.X + 17, Position.Y + node.Position.Y + 28, (float)Math.Sin(angle + 0.3) * (-3), (float)Math.Cos(angle + 0.3) * (-3)));
		projectiles.AddProjectile(new DNormalProjectile(Position.X + node.Position.X - 17, Position.Y + node.Position.Y + 28, (float)Math.Sin(angle - 0.3) * (-3), (float)Math.Cos(angle - 0.3) * (-3)));
	}

    public void Destroy()
    {
		if(_hp < 0)
			return;

		if(IsTimeTravelTransition())
			return;

		if(DestroingPlayer)
			return;

        _hp--;
		GD.Print(_hp);

		if(_hp == 150)
		{
			EmitHalfHealthEvent();
		}

		else if(_hp == 0)
		{
			_state = _state.NextState();
			GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner").ClearEnemySection();

			foreach(Node2D node in GetChildren())
			{
				if(node is not OrbiterProtection)
					continue;
					
				OnOrbiterDestroyed(node);
			}
		}else
		{
			_damageAnimator.PlayDamageAnimation();
		}
    }

    private bool IsTimeTravelTransition()
    	=> _HalfHealthEventTrigered && _state is MovingState;

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
