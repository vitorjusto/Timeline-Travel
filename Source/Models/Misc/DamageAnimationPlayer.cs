using Godot;

public class DamageAnimationPlayer
{
    private AnimatedSprite2D _sprite;
    private double _animationFrames;
    private const int MAX_ANIMATION_FRAME = 3;

    public DamageAnimationPlayer(AnimatedSprite2D sprite)
    {
        _sprite = sprite;
    }

    public void Process(double delta)
    {
        if(_animationFrames <= 0)
            PlayDefaultAnimation();
        else if(_animationFrames > 0)
            _animationFrames-= (float)(delta * 60);
    }

    public void PlayDamageAnimation()
    {
        _sprite.Play("Damage");
        _animationFrames = MAX_ANIMATION_FRAME;
    }

    public void PlayDefaultAnimation()
    {
        _sprite.Play("default");
        _animationFrames = 0;
    }
}