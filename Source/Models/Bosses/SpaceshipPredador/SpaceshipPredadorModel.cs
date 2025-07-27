using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.SpaceshipPredador;
using Shooter.Source.Models.Misc;

public partial class SpaceshipPredadorModel : CharacterBody2D, IEnemy
{
    private IState _currentState;
    public int Hp = GameManager.IsSpecialMode?1000:150;
    private DamageAnimationPlayer _damageAnimator;
    public override void _Ready()
    {
        Position = new Vector2((int)ProjectSettings.GetSetting("display/window/size/viewport_width") / 2, -100);

        _currentState = new EnteringScreen(this);

        _damageAnimator = new DamageAnimationPlayer(GetNode<AnimatedSprite2D>("AnimatedSprite2D"));
    }
    public override void _Process(double delta)
    {
        if(_currentState.Process(delta))
            _currentState = _currentState.NextState();

        _damageAnimator.Process(delta);
    }

    public void Destroy()
    {
        Hp--;

        if(Hp == 0)
        {
            _currentState = new Exploding(this, new Vector2(200, 100));
            GetNode<AnimatedSprite2D>("AnimatedSprite2D").SpeedScale = 0;
        }
        else if(Hp > 0)
            _damageAnimator.PlayDamageAnimation();
    }

    public bool IsImortal()
    {
        return true;
    }

    public EnemyBoundy GetBoundy()
    {
        return new();
    }
}
