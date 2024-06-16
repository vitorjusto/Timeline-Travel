using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;
using System;

public partial class ConceptPart : CharacterBody2D, IEnemy
{

	private int _hp = 20;
    private int _speed = -4;
    private ProjectileManager _projectiles;
    private WaveSpeed _ySpeed;
    private AnimatedSprite2D _aniSprite;
    [Export]
    public int StartWaveSpeedCooldown;
    public int _animationTime = 0;

    public override void _Ready()
    {
        _ySpeed = new WaveSpeed(-2, 10, Position.Y, StartWaveSpeedCooldown);
        _aniSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }

    public override void _Process(double delta)
	{
        if(_animationTime == 0)
            _aniSprite.Play("default");
        else
            _animationTime--;

		MoveEnemy();
	}

    private void MoveEnemy()
    {
        Position = new Vector2(x: Position.X + _speed, y: _ySpeed.Update());

		if(Position.X - 64 <= 0 && _speed < 0)
			_speed *= -1;
		else if(Position.X + 64 >= GetViewport().GetWindow().Size.X && _speed > 0)
			_speed *= -1;
    }

	public void Destroy()
    {
        _hp--;
        _aniSprite.Play("damage");
        _animationTime = 3;

		if(_hp == 0)
		{
			EmitSignal("OnPartDestroyed");
			QueueFree();
            var enemy = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
            enemy.AddExplosion(Position);
		}
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
	public delegate void OnPartDestroyedEventHandler();
}
