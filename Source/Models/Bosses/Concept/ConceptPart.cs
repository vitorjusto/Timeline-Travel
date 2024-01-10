using Godot;
using Shooter.Source.Dumies.Enemies.EnemiesPart;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;
using System;

public partial class ConceptPart : CharacterBody2D, IEnemy
{

	private int _hp = 20;
    private int _speed = -4;
    private int _time = 0;
    private bool _isShooting;
    private ProjectileManager _projectiles;
    private int _shootingCooldown = 0;

    public override void _Process(double delta)
	{
		MoveEnemy();
        Shoot();
	}

    private void Shoot()
    {
        if(_time == 70)
        {
            _time= 0;
        
            _projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");

            var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
		    var angle = Math.Atan2(Position.X - player.Position.X, Position.Y - player.Position.Y);

            _projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, (float)Math.Sin(angle) * -3, (float)Math.Cos(angle) * -3));
            _projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, (float)Math.Sin(angle + 0.6) * -3, (float)Math.Cos(angle + 0.6) * -3));
            _projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, (float)Math.Sin(angle - 0.6) * -3, (float)Math.Cos(angle - 0.6) * -3));
        }
        _time++;
    }


    private void MoveEnemy()
    {
        Position = new Vector2(x: Position.X + _speed, y: Position.Y);

		if(Position.X - 64 <= 0 && _speed < 0)
			_speed *= -1;
		else if(Position.X + 64 >= GetViewport().GetWindow().Size.X && _speed > 0)
			_speed *= -1;
    }

	public void Destroy()
    {
        _hp--;

		if(_hp == 0)
		{
			EmitSignal("OnPartDestroyed");
			QueueFree();
		}
    }

    public bool IsImortal()
    {
        return true;
    }

	[Signal]
	public delegate void OnPartDestroyedEventHandler();
}
