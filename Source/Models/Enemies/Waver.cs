using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

public partial class Waver : CharacterBody2D, IEnemy
{
	private WaveSpeed _yWaveSpeed;
	private int _speed = 15;
	private int _time = 0;
	private const int Y_START_POSITION = -100;


    public int WaveCooldown { get; set; }

    public override void _Ready()
	{
		_yWaveSpeed = new WaveSpeed(-3, 15, Position.Y, WaveCooldown);

	}

    public override void _Process(double delta)
    {
		_time++;

		if(Position.X < -30)
		{
			Position = new Vector2((int)ProjectSettings.GetSetting("display/window/size/viewport_width") + 30, Position.Y);
		}
		
		if(_time > 1532)
		{
			Position = new Vector2(Position.X, Y_START_POSITION);

			_time = 0;
			_yWaveSpeed = new WaveSpeed(-3, 20, Position.Y, startCooldown: WaveCooldown);
		}

        Position = new Vector2(Position.X - _speed,_yWaveSpeed.Update() + _time);
    }

	public void OnScreenExited()
    {

    }

    public void Destroy()
    {
		
    }

    public bool IsImortal()
    {
        return true;
    }

	public int GetStartPosition() => Y_START_POSITION;

    public EnemyBoundy GetBoundy()
    {
        return new EnemyBoundy();
    }
}
