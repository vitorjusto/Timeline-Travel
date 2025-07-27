using System;
using System.Linq;
using Godot;
using Shooter.Source.Models.Enemies;
using Shooter.Source.Models.Misc;

public partial class BackgroundLevelThree : Node2D, IBackground
{
    private Node2D _lightContainer;

	private readonly QuickTimer _timer = new(40);
    private PackedScene _starScene;
    private PackedScene _lightScene;

    public override void _Ready()
	{
        _starScene = GD.Load<PackedScene>("res://Scenes/Background/StarLevelThree.tscn");
        _lightScene = GD.Load<PackedScene>("res://Scenes/Background/LevelThreeLight.tscn");

		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");

        var instance = (LevelThreeLight)_lightScene.Instantiate();
		instance.LightOwner = player;

		_lightContainer = GetNode<Node2D>("ParallaxBackground/LightCotainer");
		_lightContainer.AddChild(instance);
	}

	public override void _Process(double delta)
	{
		
		AddLightToEnemies();
		AddLightToProjectiles();

		AddStar(delta);
	}

    private void AddStar(double delta)
    {
        if(!_timer.Process(delta))
            return;

		AddChild(_starScene.Instantiate());
		_timer.Reset();
    }

    private void AddLightToProjectiles()
    {
        var projectileManager = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");

		var lights = _lightContainer.GetChildren().ToList();

		var projectilesWithoutLight = projectileManager.GetChildren().Where((x) => !lights.Select((y) => ((LevelThreeLight)y).LightOwner).Contains(x)).ToList();

		foreach(Node projectile in projectilesWithoutLight)
		{
            if(projectile is Node2D node2d)
            {
        	    var instance = (LevelThreeLight)_lightScene.Instantiate();
			    instance.LightOwner = node2d;
			    instance.ShrinkLight();

			    _lightContainer.AddChild(instance);
            }
		}
    }

    private void AddLightToEnemies()
    {
        var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

		var lights = _lightContainer.GetChildren().ToList();

		var enemiesWithoutLight = enemySpawner.Enemies.Where((x) => !lights.Select((y) => ((LevelThreeLight)y).LightOwner).Contains(x));

		foreach(var enemy in enemiesWithoutLight)
		{
			if(enemy is DimentionalStarship  || enemy is Surpriser)
				continue;

        	var instance = (LevelThreeLight)_lightScene.Instantiate();
			instance.LightOwner = enemy;

			_lightContainer.AddChild(instance);
		}
    }
}