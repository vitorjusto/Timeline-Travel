using Godot;
using Shooter.Source.Enums;
using Shooter.Source.Models.Misc;

public partial class ColorModulator : Node2D
{
	private readonly QuickTimer _timer = new(40);
	public override void _Ready()
	    => ChangeColor();

	public override void _Process(double delta)
	{
		if(!_timer.Process(delta))
			return;
		
		ChangeColor();
	}

    private void ChangeColor()
    {
        this.Modulate = Color.FromString(((EColor)GD.RandRange(0, 6)).ToString(), Color.Color8(0, 0, 0));
    }
}
