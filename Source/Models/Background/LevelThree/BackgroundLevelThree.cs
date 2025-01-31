using System;
using System.Linq;
using Godot;

public partial class BackgroundLevelThree : Node2D, IBackground
{
    private Node2D _lightContainer;

	private int _time = 0;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");

		var scene = GD.Load<PackedScene>("res://Scenes/Background/LevelThreeLight.tscn");

        var instance = (LevelThreeLight)scene.Instantiate();

		instance.LightOwner = player;

		_lightContainer = GetNode<Node2D>("ParallaxBackground/LightCotainer");
		_lightContainer.AddChild(instance);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
		AddLightToEnemies();
		AddLightToProjectiles();

		AddStar();

		
	}

    private void AddStar()
    {
        if(_time == 40)
		{
			var scene = GD.Load<PackedScene>("res://Scenes/Background/StarLevelThree.tscn");

        	var instance = (StarLevelThree)scene.Instantiate();

			AddChild(instance);

			_time = 0;
		}

		_time++;
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
			    var scene = GD.Load<PackedScene>("res://Scenes/Background/LevelThreeLight.tscn");

        	    var instance = (LevelThreeLight)scene.Instantiate();
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

			var scene = GD.Load<PackedScene>("res://Scenes/Background/LevelThreeLight.tscn");

        	var instance = (LevelThreeLight)scene.Instantiate();
			instance.LightOwner = enemy;

			_lightContainer.AddChild(instance);
		}
    }

}
