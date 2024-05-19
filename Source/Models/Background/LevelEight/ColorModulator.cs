using Godot;
using Shooter.Source.Enums;

public partial class ColorModulator : Node2D
{
	private int _timer = 0;
	public override void _Ready()
	{
		ChangeColor();
	}

	public override void _Process(double delta)
	{
		_timer++;

		if(_timer < 40)
			return;
		
		ChangeColor();

		_timer = 0;
	}

    private void ChangeColor()
    {
        this.Modulate = Color.FromString(((EColor)GD.RandRange(0, 6)).ToString(), Color.Color8(0, 0, 0));
    }
}
