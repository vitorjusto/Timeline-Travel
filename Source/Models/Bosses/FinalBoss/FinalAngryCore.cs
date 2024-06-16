using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;
public partial class FinalAngryCore : Node2D, IEnemy
{

	private int _hp = 70;
	private WaveSpeed _ySpeed;

	public override void _Ready()
	{
		_ySpeed = new WaveSpeed(-2, 10, Position.Y);
	}

    public override void _Process(double delta)
	{
		Position = new Vector2(Position.X, _ySpeed.Update());
	}

	public void Destroy()
    {
        _hp--;

		if(_hp == 0)
			EmitSignal("OnDestroyed", this);
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
	public delegate void OnDestroyedEventHandler(Node2D node);
}
