using Godot;

public partial class FinalEndingScene : Node2D
{
    private AnimatedSprite2D _backgroundPlayer;
    private Node2D _player;
    private bool _playerGoingToLeft;

    public override void _Ready()
	{
        _backgroundPlayer = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        _backgroundPlayer.Play();

        _player = GetNode<Node2D>("SpaceshipUpgrade");
	}

	public override void _Process(double delta)
	{
        if(_playerGoingToLeft)
            _player.Position += new Vector2(-24, 0) * (float)(delta * 60);
        else
            _backgroundPlayer.Position += new Vector2(6, 2) * (float)(delta * 60);
	}

    public void OnAnimationFinished()
    {
        _playerGoingToLeft = true;
    }
    
    public void OnPlayerExited()
    {
        GetNode<AnimationPlayer>("AnimationPlayer").Play("new_animation");
    }

    
    public void OnAnimationFinished(string animationName)
    {
        EmitSignal("OnFirstSceneEnded");
    }

    [Signal]
    public delegate void OnFirstSceneEndedEventHandler();
}
