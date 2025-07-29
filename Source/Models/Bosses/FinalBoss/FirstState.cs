using System;
using Godot;
using Shooter.Source.Dumies.Enemies.EnemiesPart;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.SpaceshipPredador;
using Shooter.Source.Models.Misc;

public partial class FirstState : Node2D, IEnemy
{
	private Player _player;
	private bool _isEntrering = true;
	private int _hp = 100;
    private QuickTimer _time = new(100);
    private float _lazerCooldown;
	private int _lazerPosition1 = 0;
	private int _lazerPosition2 = 50;
	private int _lazerPosition3 = -50;
	private float _shootingCooldown = 0;
	private IState _exploding;
    private DamageAnimationPlayer _damageAnimator;

    public override void _Ready()
	{
		_player = GetTree().Root.GetNode<Player>("/root/Main/Player");

		_damageAnimator = new DamageAnimationPlayer(GetNode<AnimatedSprite2D>("AnimatedSprite2D"));
	}

	public override void _Process(double delta)
	{
		if(_exploding is not null)
		{
			if(_exploding.Process(delta))
				EndPhase();
			
			return;
		}

		if(_isEntrering)
		{
			EntreringState(delta);
			return;
		}

		if(_lazerCooldown <= 0)
			ShootLazers(delta);
		else
			_lazerCooldown -= (float)(delta * 60);

		if(_shootingCooldown <= 0)
			ShootProjectile();
		else
			_shootingCooldown -= (float)(delta * 60);

		_damageAnimator.Process(delta);
	}

    private void EndPhase()
    {
		EmitSignal("OnDestroyed");
       	QueueFree();
    }

    private void ShootProjectile()
    {
		ShootFromAnchor(GetNode<Node2D>("ShootAnchor1").Position + Position);
		ShootFromAnchor(GetNode<Node2D>("ShootAnchor2").Position + Position);

		_shootingCooldown = 100;
    }

    private void ShootFromAnchor(Vector2 position)
    {
        var angle = Math.Atan2(position.X - _player.Position.X, position.Y - _player.Position.Y);
		var projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");

		projectiles.AddProjectile(new DNormalProjectile(position.X, position.Y, (float)Math.Sin(angle) * (-3), (float)Math.Cos(angle) * (-3)));
		projectiles.AddProjectile(new DNormalProjectile(position.X, position.Y, (float)Math.Sin(angle + 0.6) * (-3), (float)Math.Cos(angle + 0.5) * (-3)));
		projectiles.AddProjectile(new DNormalProjectile(position.X, position.Y, (float)Math.Sin(angle - 0.6) * (-3), (float)Math.Cos(angle - 0.5) * (-3)));
		
    }

    private void ShootLazers(double delta)
    {
        if(_time.Time == 0)
            AudioManager.OnLaser();
            
        var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
        enemySpawner.AddEnemy(new DLazerPart(Position.X + _lazerPosition1, Position.Y + 20 + (20 * (float)_time.Time), 200));
        enemySpawner.AddEnemy(new DLazerPart(Position.X + _lazerPosition2, Position.Y + 20 + (20 * (float)_time.Time), 200));
        enemySpawner.AddEnemy(new DLazerPart(Position.X + _lazerPosition3, Position.Y + 20 + (20 * (float)_time.Time), 200));

		if(_time.Process(delta))
		{
            _time.Reset();
            _lazerCooldown = 150;

			_lazerPosition1 = new Random().Next(-2, 3) * 100;
			_lazerPosition2 = (new Random().Next(0, 3) * 100) + 50;
			_lazerPosition3 = _lazerPosition2 * -1;
		}
    }

    private void EntreringState(double delta)
    {
		var hud = GetTree().Root.GetNode<Hud>("/root/Main/Hud");

		if(hud.IsShowingTimelineLabel)
			return;

        Position += new Vector2(0, 10) * (float)(delta * 60);

		if(Position.Y > 50)
		{
			_isEntrering = false;
			EmitSignal("OnWallEntered");
		}
    }

    public void Destroy()
    {
        _hp--;

		if(_hp == 0)
			_exploding = new Exploding(this, size: new Vector2(230, 100), removeEnemy: false);
		else if(_hp > 0)
			_damageAnimator.PlayDamageAnimation();
    }

    public bool IsImortal()
    {
        return true;
    }

    public EnemyBoundy GetBoundy()
    {
        return new();
    }

    [Signal]
	public delegate void OnDestroyedEventHandler();
	
    [Signal]
	public delegate void OnWallEnteredEventHandler();
}
