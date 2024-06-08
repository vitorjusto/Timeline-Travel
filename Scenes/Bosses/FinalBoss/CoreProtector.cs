using Godot;
using Shooter.Source.Interfaces;

public partial class CoreProtector : CharacterBody2D, IEnemy
{
	private int _hp = 50;
	private bool _canTakeDamage = true;

    public void Destroy()
    {
		if(_canTakeDamage)
        	_hp--;

		if(_hp == 0)
		{
			GetNode<Node2D>("ChequerAtackContainer").CallDeferred("queue_free");
			EmitSignal("OnProtectorDestoyed", this);
		}
    }

    public bool IsImortal()
    {
        return true;
    }

    public override void _Process(double delta)
	{
	}

	public void OnOtherProtectorDestroyed(Node2D node)
	{
		_canTakeDamage = false;
	}

	[Signal]
	public delegate void OnProtectorDestoyedEventHandler(Node2D node);
}
