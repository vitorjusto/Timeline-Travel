using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;
using System;

public partial class Concept : Node2D, IEnemy, INonExplodable
{
	
	private int _speed = -3;
    private bool _isDestroing = false;
    private int _time = 0;

	private int _hp = 3;

	private int _damageAnimation = 0;

    private EnemySpawner _enemySpawner;

	[Export]
	public bool AutoEndLevel = true;
    public override void _Ready()
	{
		_enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
	}

    public override void _Process(double delta)
	{


	}

	public void Destroy()
	{

	}

	public bool IsImortal()
	{
		return true;
	}

	public void OnConceptPartOnPartDestroyed()
	{
		_hp--;

		if(_hp == 0)
		{
			EmitSignal("OnAllBodyPartDestroyed");
		}else if(_hp == 1)
		{
			EmitSignal("OnActivateHeadShooting");

		}
	}

	public void OnHeadDestroyed()
	{
		EmitSignal("OnConceptDestroyed");
		
		if(AutoEndLevel)
		{
			_enemySpawner.EndLevel();
			_enemySpawner.RemoveEnemy(this);
		}

	}

    public EnemyBoundy GetBoundy()
    {
        return new(); 
    }

    [Signal]
	public delegate void OnAllBodyPartDestroyedEventHandler();
	
	[Signal]
	public delegate void OnActivateHeadShootingEventHandler();

	[Signal]
	public delegate void OnConceptDestroyedEventHandler();
}
