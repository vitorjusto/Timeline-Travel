using System;
using Godot;
using Shooter.Source.Interfaces;

public partial class ConceptHead : CharacterBody2D, IEnemy
{

	private int _hp = 20;
    private int _speed = -4;
	private bool _forceFieldDestroyed = false;
    private bool _isDestroyng;
	public int _time = 0;
    private EnemySpawner _enemySpawner;
    public override void _Ready()
    {
        Position = new Vector2(x: Position.X + GetViewport().GetWindow().Size.X, y: Position.Y);
		_enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
    }
    public override void _Process(double delta)
	{
		if(_isDestroyng)
			DestroyAnimation();
		else			
			MoveEnemy();
	}

    private void DestroyAnimation()
    {
		_enemySpawner.AddExplosion(Position.X + (new Random().Next(-100, 100)), Position.Y + (new Random().Next(-100, 100)));

		if(_time == 300)
		{
			EmitSignal("OnHeadDestroyed");
		}

		_time++;
    }

    private void MoveEnemy()
    {
        Position = new Vector2(x: Position.X + _speed, y: Position.Y);

		if(Position.X - 96 <= 0 && _speed < 0)
			_speed *= -1;
		else if(Position.X + 96 >= GetViewport().GetWindow().Size.X && _speed > 0)
			_speed *= -1;
    }

	public void Destroy()
    {
		if(_forceFieldDestroyed)
			_hp--;
		
		if(_hp == 0)
			_isDestroyng = true;

    }

    public bool IsImortal()
    {
        return true;
    }

	[Signal]
	public delegate void OnHeadDestroyedEventHandler();

	public void OnAllBodyPartDestroyed()
	{
		_forceFieldDestroyed = true;

		GetNode<Node2D>("ForceField").CallDeferred("queue_free");
		GetNode<Node2D>("CollisionForceField").CallDeferred("queue_free");
		GetNode<CollisionShape2D>("CollisionHead").SetDeferred("disabled", false);

	}
}