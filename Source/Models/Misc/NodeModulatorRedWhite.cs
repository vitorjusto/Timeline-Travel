using Godot;
using System;

public partial class NodeModulatorRedWhite : Node2D
{
	private bool _onRed;
	private float _timer;
	
	public override void _Process(double delta)
	{
		_timer+= (float)(delta * 60);
		if(_timer >= 20)
		{
			_onRed = !_onRed;
			Modulate = Color.Color8(255, (byte)(_onRed ?0: 255), (byte)(_onRed ?0: 255), 255);
			_timer -= 20;
		}
	}
}
