using System;
using Godot;

public partial class BackgroundLevelSix : Node2D
{
	private Panel _panel;
    private Node2D _rainDropParallax;
    private int _time = 0;
	private int _cycle = 0;
	private bool _lightOn = false;
	private int _lightningCycle = 0;
	private int _rainDropGenerationCycle = 1;
	private int _rainDropTimer = 0;

    public override void _Ready()
	{
		_panel = GetNode<Panel>("ParallaxBackground/ParallaxLayer2/Panel2");
		_rainDropParallax = GetNode<Node2D>("ParallaxBackground/RainDropParallax");

		SetCycle();
	}

    private void SetCycle()
    {
        _cycle = new Random().Next(100, 900);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
		if(_time > _cycle)
			MakeLightning();
		
		if(_rainDropTimer > _rainDropGenerationCycle)
		{
			MakeRainDrop();
			MakeRainDrop();
			MakeRainDrop();
		}

		_rainDropTimer++;
		_time++;
	}

    private void MakeRainDrop()
    {
        var scene = GD.Load<PackedScene>("res://Scenes/Background/RainDrop.tscn");

        var instance = (Node2D)scene.Instantiate();
        instance.Position = new Vector2(new Random().Next(30, 1500), -30);

		_rainDropParallax.AddChild(instance);
		_rainDropTimer = 0;
    }


    private void MakeLightning()
    {
        if(!(_time % 6 == 0))
			return;
		
		_lightOn = !_lightOn;
		_panel.Visible = _lightOn;
		_lightningCycle++;

		if(_lightningCycle < 6)
			return;
			
		_time = 0;
		_lightningCycle = 0;
		SetCycle();
    }

}
