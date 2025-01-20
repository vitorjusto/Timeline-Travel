using Godot;

public partial class AudioManager : Node2D
{
    private static AudioManager _manager;
    
    public static void SetTimelineSong(int level)
    {
        GD.Print(level);

        switch (level)
        {
            case 1:
                _audio = ResourceLoader.Load<AudioStream>("res://Assets/Songs/TheirTimeline.wav");
                break;
            case 2:
                _audio = ResourceLoader.Load<AudioStream>("res://Assets/Songs/Timeline2Or7.wav");
                break;
            case 3:
                _audio = ResourceLoader.Load<AudioStream>("res://Assets/Songs/Timeline3.wav");
                break;
            case 4:
                break;
            case 5:
                _audio = ResourceLoader.Load<AudioStream>("res://Assets/Songs/Timeline5.wav");
                break;
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
                _audio = ResourceLoader.Load<AudioStream>("res://Assets/Songs/TheirTimeline.wav");
                break;
            case 11:
                break;
            case 12:
                _audio = ResourceLoader.Load<AudioStream>("res://Assets/Songs/Boss.wav");
                break;

        }

        _player.Stream = _audio;
        
    }

    public static void Play()
        => _player.Play(0);
        
    public static void Stop()
    {
        _player.Stop();
    }

    private static AudioStream _audio;
    private static AudioStreamPlayer _player;
	public override void _Ready()
	{
        _player = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
	}

    public void OnAudioFinished()
            => _player.Play(0);

}
