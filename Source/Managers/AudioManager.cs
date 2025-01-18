using Godot;
using System;

public partial class AudioManager : Node2D
{
    private AudioStream audio;
    private AudioStreamPlayer player;
	public override void _Ready()
	{
                // Carregar o áudio
        audio = ResourceLoader.Load<AudioStream>("res://Assets/Songs/Timeline3.wav");

        // Criar e configurar o AudioStreamPlayer
        player = GetNode<AudioStreamPlayer>("AudioStreamPlayer");
        player.Stream = audio;
        player.Play(0);

	}

	public override void _Process(double delta)
	{
	}

    public void OnAudioFinished()
            => player.Play(0);

}
