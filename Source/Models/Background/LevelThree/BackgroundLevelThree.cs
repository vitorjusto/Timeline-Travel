using System;
using System.Linq;
using Godot;

public partial class BackgroundLevelThree : Node2D, IBackground
{
    private Node2D _lightContainer;

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

		GD.Print(_lightContainer.GetChildCount());
	}

    private void AddLightToProjectiles()
    {
        var projectileManager = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");

		var lights = _lightContainer.GetChildren().ToList();

		var projectilesWithoutLight = projectileManager.EnemiesProjectiles.Where((x) => !lights.Select((x) => ((LevelThreeLight)x).LightOwner).Contains(x));

		foreach(var projectile in projectilesWithoutLight)
		{
			var scene = GD.Load<PackedScene>("res://Scenes/Background/LevelThreeLight.tscn");

        	var instance = (LevelThreeLight)scene.Instantiate();
			instance.LightOwner = projectile;
			instance.ShrinkLight();

			_lightContainer.AddChild(instance);
		}
    }

    private void AddLightToEnemies()
    {
        var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

		var lights = _lightContainer.GetChildren().ToList();

		var enemiesWithoutLight = enemySpawner.Enemies.Where((x) => !lights.Select((x) => ((LevelThreeLight)x).LightOwner).Contains(x));

		foreach(var enemy in enemiesWithoutLight)
		{
			var scene = GD.Load<PackedScene>("res://Scenes/Background/LevelThreeLight.tscn");

        	var instance = (LevelThreeLight)scene.Instantiate();
			instance.LightOwner = enemy;

			_lightContainer.AddChild(instance);
		}
    }

    public void PauseBackground(bool isPaused)
    {

    }

}
