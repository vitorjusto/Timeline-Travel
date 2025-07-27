using System;
using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.BossLevelEight.States;
using Shooter.Source.Models.Misc;

public partial class BlackholeGeneratorV2Part : CharacterBody2D, IEnemy, INonExplodable
{
	private int _hp = 50;
    private ProjectileManager _projectiles;
    private int _timer;
    public BlackholeGeneratorV2 Boss;
	private DamageAnimationPlayer _damageAnimator;
    public override void _Ready()
    {
        _projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");
        _damageAnimator = new DamageAnimationPlayer(GetNode<AnimatedSprite2D>("AnimatedSprite2D"));

    }
    public override void _Process(double delta)
	{
        _damageAnimator.Process(delta);
        
        if(Boss.State is EnteringState)
            return;
            
        _timer++;

        if(_timer < 90)
            return;

        var position = Boss.Position + Position;

        var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
		var angle = Math.Atan2(position.X - player.Position.X, position.Y - player.Position.Y);

		_projectiles.AddProjectile(new DLightProjectile(position.X, position.Y, (float)Math.Sin(angle) * (-2), (float)Math.Cos(angle) * (-2)));
		_projectiles.AddProjectile(new DLightProjectile(position.X, position.Y, (float)Math.Sin(angle - 0.5) * (-2), (float)Math.Cos(angle - 0.5) * (-2)));
		_projectiles.AddProjectile(new DLightProjectile(position.X, position.Y, (float)Math.Sin(angle + 0.5) * (-2), (float)Math.Cos(angle + 0.5) * (-2)));

        _timer = 0;

	}
	
	public void Destroy()
    {
        _hp--;
		
		if(_hp == 0)
			EmitSignal("PartDestroyed", this);
        else
            _damageAnimator.PlayDamageAnimation();	
    }

	[Signal]
	public delegate void PartDestroyedEventHandler(Node2D node);

    public bool IsImortal()
    {
        return true;
    }

    public EnemyBoundy GetBoundy()
    {
        return new();
    }
}
