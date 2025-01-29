using Godot;
public partial class Explosion : AnimatedSprite2D
{
    public bool MakeSound;
	public override void _Ready()
	{
        if(!MakeSound)
            GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D").Stop();

		Play("default");
	}

    public void onAnimationFinished()
    {
		CallDeferred("queue_free");
    }
}
