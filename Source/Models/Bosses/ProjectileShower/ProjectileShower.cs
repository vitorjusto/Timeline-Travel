using System;
using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.ProjectileShowerState;
using Shooter.Source.Models.Bosses.SpaceshipPredador;

public partial class ProjectileShower : Node2D, IEnemy
{
	private IState _state;
	public int Hp = 150;
	public bool IsExploding => _state is Exploding;
	public override void _Ready()
	{
		_state = new ProjectileShowerEntreringState(this);
	}

	public override void _Process(double delta)
	{
		if(_state.Process())
		{
			_state = _state.NextState();

			if(_state == null && Hp > 0)
				ShowSmallBoss();
		}
	}

    private void ShowSmallBoss()
    {
        GetNode<Node2D>("SmallBoss").Visible = true;
        GetNode<CollisionShape2D>("SmallBossCollision").Disabled = false;

		GetNode<Node2D>("BigBoss").Visible = false;
        GetNode<CollisionShape2D>("BigBossCollision").Disabled = true;

		_state = new ProjectileShowerRunningAroundState(this);
    }

    public void Destroy()
    {
		if(IsExploding)
			return;

        Hp--;
		GD.Print(Hp);

		if(Hp == 30)
			_state = new Exploding(this, 500, removeEnemy: false);
		if(Hp == 0)
			_state = new Exploding(this, 32);
    }

    public bool IsImortal()
    {
        return true;
    }
}
