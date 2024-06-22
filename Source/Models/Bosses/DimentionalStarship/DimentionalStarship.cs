using System;
using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.SpaceshipPredador;
using Shooter.Source.Models.Misc;

public partial class DimentionalStarship : CharacterBody2D, IEnemy, IEnableNotifier
{
	  private int _time;
    private int _hp = 50;
    private EnemySpawner _enemySpawner;
    private bool _destroing;
    [Export]
    public bool EndLevel = true;

    public IState _state;

    public override void _Ready()
    {
      _enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

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
    }

    private void DestroingAnimation()
    {
	  	  _enemySpawner.AddExplosion(Position.X + (new Random().Next(-100, 100)), Position.Y + (new Random().Next(-100, 100)));

	  	  if(_time == 300)
	  	  {
          if(EndLevel)
	  	      _enemySpawner.EndLevel();

	  	    _enemySpawner.RemoveEnemy(this);
	  	  }

	  	  _time++;
    }

    public void Destroy()
    {
        _hp--;

        if(_hp == 0)
        {
            _state = new Exploding(this, removeEnemy: EndLevel);
            _time = 0;
        }

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
        _destroing = true;
    }

    public EnemyBoundy GetBoundy()
    {
        return new();
    }
}
