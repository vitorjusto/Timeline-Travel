using Godot;

public class DamageAnimationPlayer
{
    private AnimatedSprite2D _sprite;
    private int _animationFrames;
    private const int MAX_ANIMATION_FRAME = 3;

    public DamageAnimationPlayer(AnimatedSprite2D sprite)
    {
        _sprite = sprite;
    }

    public void Process()
    {
        if(_animationFrames == 0)
            _sprite.Play("default");
        else
            _animationFrames--;
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