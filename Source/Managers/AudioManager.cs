using Godot;

public partial class AudioManager : Node2D
{
    private static AudioManager _manager;
    private static bool _startingBossTransition;
    public static void SetTimelineSong(int level)
    {
        _player.VolumeDb = 0;
        _audio = null;
        switch (level)
        {
            case 1:
                _audio = ResourceLoader.Load<AudioStream>("res://Assets/Songs/OurTimeline.wav");
                break;
            case 2:
                _audio = ResourceLoader.Load<AudioStream>("res://Assets/Songs/Timeline2Or7.wav");
                break;
            case 3:
                _audio = ResourceLoader.Load<AudioStream>("res://Assets/Songs/Timeline3.wav");
                break;
            case 4:
                _audio = ResourceLoader.Load<AudioStream>("res://Assets/Songs/Timeline4.wav");
                break;
            case 5:
                _audio = ResourceLoader.Load<AudioStream>("res://Assets/Songs/Timeline5.wav");
                break;
            case 6:
                _audio = ResourceLoader.Load<AudioStream>("res://Assets/Songs/Timeline6.wav");
                break;
            case 7:
                _audio = ResourceLoader.Load<AudioStream>("res://Assets/Songs/Timeline7.wav");
                break;
            case 8:
                _audio = ResourceLoader.Load<AudioStream>("res://Assets/Songs/Timeline8.wav");
                break;
            case 9:
                _audio = ResourceLoader.Load<AudioStream>("res://Assets/Songs/Timeline9.wav");
                break;
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

    public static void Pause()
    {
        _pausedPosition = _player.GetPlaybackPosition();
        _player.Stop();
    }

    public static void Unpause()
    {
        _player.Play(_pausedPosition);
        _pausedPosition = 0;
    }

    private static AudioStream _audio;

    public static AudioStreamPlayer AudioStreamPlayer => _player;
    public static void SetCustonMusic(string song)
    {
        _audio = ResourceLoader.Load<AudioStream>(song);
        _player.Stream = _audio;
        _player.Play(0);
    }

    private static AudioStreamPlayer _player;
    private static float _pausedPosition;

    public override void _Ready()
	{
        _player = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
	}

    public override void _Process(double delta)
    {
        if(_startingBossTransition)
        {
            _player.VolumeDb -= 0.5f;
        }
    }
    
    public static void StartBossTransition()
        => _startingBossTransition = true;

    public static void SetBossMusic()
    {
        _audio = ResourceLoader.Load<AudioStream>("res://Assets/Songs/Boss.wav");
        _player.Stream = _audio;
        _startingBossTransition = false;
        _player.VolumeDb = 0;
        Play();
    } 
    public void OnAudioFinished()
        => _player.Play(0);

}
