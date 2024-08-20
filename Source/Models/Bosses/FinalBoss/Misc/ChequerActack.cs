using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

public partial class ChequerActack : Node2D, IEnemy, IEnableNotifier
{
	[Export]
	public int column = 0;
	[Export]
	public int row = 0;

	public ChequerActackContainer BaseContainer;

	private bool _activated = false;
	private int _timer = 0;
	private byte _opacity = 0;

	public override void _Ready()
	{
		GetNode<CollisionShape2D>("CollisionShape2D").Disabled = true;
	}

	public override void _Process(double delta)
	{
		if(!_activated)
		{
			Visible = false;
			return;
		}
		
		_timer++;

		if(_timer > 10)
			Deactivate();
		else
		{
			Modulate = Color.Color8(255, 255, 255, _opacity);
			_opacity -= 15;
		}
	}

    private void Deactivate()
    {
        BaseContainer.OnActivation(this);
		Visible = false;
		_activated = false;
		GetNode<CollisionShape2D>("CollisionShape2D").Disabled = true;
    }

	public void Activate()
    {
		_activated = true;
		Visible = true;
		_timer = 0;
		GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;

		_opacity = 150;
    }

    public void Destroy()
    {
        
    }

    public bool IsImortal()
    {
        return false;
    }

    public void OnEnable()
    {
        Visible = false;
		_activated = false;
		GetNode<CollisionShape2D>("CollisionShape2D").Disabled = true;
    }

    public EnemyBoundy GetBoundy()
    {
        return new();
    }

    [Signal]
	public delegate void OnDeactivatedEventHandler(ChequerActack node);
}
