using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Misc;
using System;

public partial class Surpriser : Node2D, IEnemy
{
	private int _time;
    private Sprite2D _sprite;
    private Sprite2D _lightSprite;

    public override void _Ready()
    {

		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");

		var x = player.Position.X  + (new Random().Next(0,3) == 1? 100: -100);
		
        if(x < 5)
            x = player.Position.X + 100;
        else if(x > 1395)
            x = player.Position.X - 100;

		var y = player.Position.Y  + (new Random().Next(0,3) == 1? 100: new Random().Next(1,3) == 1? -100: 0);

        if(y < 5)
            y = player.Position.Y + 100;
        else if(y > 895)
            y = player.Position.Y - 100;

		Position = new Vector2(x, y);

        _lightSprite = GetNode<Sprite2D>("LevelThreeLight");
        _lightSprite.Modulate = Color.Color8(255, 255, 255, 0);

        _sprite = GetNode<Sprite2D>("Surpriser");
        _sprite.Modulate = Color.Color8(255, 255, 255, 0);
        _sprite.Rotation = new Random().Next(0, 90);
    }
    
    public override void _Process(double delta)
    {
        _time++;

        Animate();

        if(_time == 80)
            Explode();
    }

    private void Animate()
    {
        _sprite.Modulate = Color.Color8(255, 255, 255, (byte)(_time * 3));
        _lightSprite.Modulate = Color.Color8(255, 255, 255, (byte)(_time * 3));

        _sprite.Rotation += 0.005f;
    }

    private void Explode()
    {
        var projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");
        projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 5, 5));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 5, -5));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, -5, 5));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, -5, -5));

		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 5, 0));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 0, 5));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, -5, 0));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 0, -5));

		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 5, 2.5f));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, -5, 2.5f));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 2.5f, 5));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 2.5f, -5));

		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, 5, -2.5f));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, -5, -2.5f));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, -2.5f, 5));
		projectiles.AddProjectile(new DNormalProjectile(Position.X, Position.Y, -2.5f, -5));

        var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

        enemySpawner.RemoveEnemy(this);

    }


    public void Destroy()
    {
        Explode();
    }

    public bool IsImortal()
    {
        return false;
    }

    public EnemyBoundy GetBoundy()
    {
        return new();
    }
}
