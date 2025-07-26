using System;
using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

public partial class MothershipCore1 : Node2D, IEnemy
{
    [Export]
    public int FinalPosition = 175;
    private WaveSpeed _ySpeed;
	[Export]
	public bool EntreringStage = true;

    public override void _Ready()
	{
		_ySpeed = new WaveSpeed(-1, 5, Position.Y);
	}
	
	public override void _Process(double delta)
	{
		if(EntreringStage)
			MoveBoss();
		else
			Position = new Vector2(Position.X, _ySpeed.Update(delta));
		
	}

    private void MoveBoss()
    {
        Position += new Vector2(0, 2);
		
		if(Position.Y < FinalPosition)
			return;
		
        EnterOnFinalPosition();
    }

	public void OnPuncherDestroyed(Node2D node)
	{
		this.SetProcess(false);
	}

    public void EnterOnFinalPosition()
    {
        Position = new Vector2(Position.X, FinalPosition);

		_ySpeed = new WaveSpeed(-1, 5, Position.Y);
		EntreringStage = false;

		GetNode<ShootPoint>("ShootPoint").Active = true;
		GetNode<ShootPoint>("ShootPoint2").Active = true;
		GetNode<ShootPoint>("ShootPoint3").Active = true;
		GetNode<ShootPoint>("ShootPoint4").Active = true;
		GetNode<ShootPoint>("ShootPoint5").Active = true;
		GetNode<ShootPoint>("ShootPoint6").Active = true;
    }

	public void Disable()
	{
		GetNode<ShootPoint>("ShootPoint").Active = false;
		GetNode<ShootPoint>("ShootPoint2").Active = false;
		GetNode<ShootPoint>("ShootPoint3").Active = false;
		GetNode<ShootPoint>("ShootPoint4").Active = false;
		GetNode<ShootPoint>("ShootPoint5").Active = false;
		GetNode<ShootPoint>("ShootPoint6").Active = false;
	}

    public void Destroy(){ }

    public bool IsImortal()
    	=> true;

    public EnemyBoundy GetBoundy()
    	=> new();

    internal void Enable()
    {
        GetNode<ShootPoint>("ShootPoint").Active = true;
		GetNode<ShootPoint>("ShootPoint2").Active = true;
		GetNode<ShootPoint>("ShootPoint3").Active = true;
		GetNode<ShootPoint>("ShootPoint4").Active = true;
		GetNode<ShootPoint>("ShootPoint5").Active = true;
		GetNode<ShootPoint>("ShootPoint6").Active = true;
    }
}