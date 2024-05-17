using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.LevelSeven.States;
using System;

public partial class SeasoningAdpter : Node2D, IEnemy
{
	public IState _state;
	private int _hp = 100;
	
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_state?.Process();
	}

    internal void StartProcess()
    {
        GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;
		Visible = true;

		_state = new SpringSeasoningAdpterState(this);

    }

    public void Destroy()
    {
        _hp--;
    }

    public bool IsImortal()
    {
       return true;
    }
}
