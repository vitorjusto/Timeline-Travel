using System;
using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;

public partial class DimentionalStarship : CharacterBody2D, IEnemy, IEnableNotifier
{
	private int _time;
  private int _hp = 50;
  private EnemySpawner _enemySpawner;
  private CollisionShape2D _collisionBox;
  private bool _destroing;
  [Export]
  public bool EndLevel = true;

  public override void _Ready()
  {
    _enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
    _collisionBox = GetNode<CollisionShape2D>("CollisionShape2D");
    MakeInvisible();
  }

  public override void _Process(double delta)
  {
    if(_destroing)
    {
      DestroingAnimation();
      return;
    }

    if(_time == 100)
		  MakeVisible();
    if(_time == 150)
      Shoot();
	
	  if(_time == 200)
		  MakeInvisible();

	  _time++;
  }

  private void Shoot()
  {
    var player = GetTree().Root.GetNode<Player>("/root/Main/Player");
		var angle = Math.Atan2(Position.X - player.Position.X, Position.Y - player.Position.Y);
		var projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager"); 
       
		projectiles.AddProjectile(new DLightProjectile(Position.X, Position.Y, (float)Math.Sin(angle) * (-3), (float)Math.Cos(angle) * (-3)));
		projectiles.AddProjectile(new DLightProjectile(Position.X, Position.Y, (float)Math.Sin(angle + 0.6) * (-3), (float)Math.Cos(angle + 0.6) * (-3)));
		projectiles.AddProjectile(new DLightProjectile(Position.X, Position.Y, (float)Math.Sin(angle - 0.6) * (-3), (float)Math.Cos(angle - 0.6) * (-3)));
		projectiles.AddProjectile(new DLightProjectile(Position.X, Position.Y, (float)Math.Sin(angle + 0.3) * (-3), (float)Math.Cos(angle + 0.3) * (-3)));
		projectiles.AddProjectile(new DLightProjectile(Position.X, Position.Y, (float)Math.Sin(angle - 0.3) * (-3), (float)Math.Cos(angle - 0.3) * (-3)));
		
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

    private void MakeInvisible()
  {
    Visible = false;
	  _time = 0;
    _collisionBox.Disabled = true;
  }


  private void MakeVisible()
  {
    var viewPortHeight = (int)ProjectSettings.GetSetting("display/window/size/viewport_height") - 100;
    var viewPortWidth = (int)ProjectSettings.GetSetting("display/window/size/viewport_width") - 100;
    var player = GetTree().Root.GetNode<Player>("/root/Main/Player");

    while(true)
    {
	    var height = new Random().Next(100, viewPortHeight);
	    var width = new Random().Next(100, viewPortWidth);

      var diference = Math.Abs(player.Position.X - width) + Math.Abs(player.Position.Y - height);

      if(diference > 200)
      {
	      Position = new Vector2(width, height);
        break;
      }
    }

	  Visible = true;
    _collisionBox.Disabled = false;
  }

  public void Destroy()
  {
    _hp--;

    if(_hp == 0)
    {
      _destroing = true;
      _time = 0;
    }
      
  }

  public bool IsImortal()
  {
    return true;
  }

  public void OnEnable()
  {
    MakeInvisible();
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
