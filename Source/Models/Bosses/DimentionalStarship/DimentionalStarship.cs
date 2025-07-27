using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.SpaceshipPredador;
using Shooter.Source.Models.Misc;

public partial class DimentionalStarship : CharacterBody2D, IEnemy, IEnableNotifier
{
    private int _hp = GameManager.IsSpecialMode?200:60;
    [Export]
    public bool EndLevel = true;
    [Export]
    public bool EmitLight = true;
    private DamageAnimationPlayer _damageAnimator;
    public IState _state;

    public override void _Ready()
    {
        _damageAnimator = new DamageAnimationPlayer(GetNode<AnimatedSprite2D>("AnimatedSprite2D"));
        _state = new DimentionalStarshipGoingInvisibleState(this);
        EmitLight = EmitLight && !EnemySpawner.GetEnemySpawner().isBossRush;

    }

    public override void _Process(double delta)
    {
      if(_state is null)
      {
          QueueFree();
          return;
      }

      if(_state.Process(delta))
        _state = _state.NextState();
    
        _damageAnimator.Process(delta);
        GetNode<Node2D>("LevelThreeLight").Visible = EmitLight;
        
    }

    public void Destroy()
    {
        _hp--;

        if(_hp == 0)
            _state = new Exploding(this, 150, removeEnemy: EndLevel, positionOffSet: new Vector2(GetNode<Node2D>("AnimatedSprite2D").Scale.X < 0? -150: 150, 200));
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
        _state = new Exploding(this, 150, removeEnemy: EndLevel, positionOffSet: new Vector2(GetNode<Node2D>("AnimatedSprite2D").Scale.X < 0? -150: 150, 200));
    }

    public EnemyBoundy GetBoundy()
    {
        return new();
    }
}