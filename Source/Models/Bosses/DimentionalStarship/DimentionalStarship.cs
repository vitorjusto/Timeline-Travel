using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.SpaceshipPredador;
using Shooter.Source.Models.Misc;

public partial class DimentionalStarship : CharacterBody2D, IEnemy, IEnableNotifier
{
    private int _hp = 60;
    [Export]
    public bool EndLevel = true;
    private DamageAnimationPlayer _damageAnimator;
    public IState _state;

    public override void _Ready()
    {
        _damageAnimator = new DamageAnimationPlayer(GetNode<AnimatedSprite2D>("AnimatedSprite2D"));
        _state = new DimentionalStarshipGoingInvisibleState(this);
    }

    public override void _Process(double delta)
    {
      if(_state is null)
      {
          QueueFree();
          return;
      }

      if(_state.Process())
        _state = _state.NextState();
    
        _damageAnimator.Process();
    }

    public void Destroy()
    {
        _hp--;

        if(_hp == 0)
            _state = new Exploding(this, 300, removeEnemy: EndLevel, positionOffSet: new Vector2(0, 200));
        else if(_hp > 0)
            _damageAnimator.PlayDamageAnimation();
    }

    public bool IsImortal()
    {
        return true;
    }

    public void OnEnable()
    {
        _state = new DimentionalStarshipGoingInvisibleState(this);
    }

    public void OnFinalBossDestroyed(Node2D node)
    {
        _state = new DimentionalStarshipGoingInvisibleState(this);
    }

    public EnemyBoundy GetBoundy()
    {
        return new();
    }
}