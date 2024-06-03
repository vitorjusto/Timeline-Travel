using System;
using System.Linq;
using Godot;

public partial class BackgroundLevelFour : Node2D, IBackground
{
	private Node2D _shadowContainer;
	public override void _Ready()
	{
		var player = GetTree().Root.GetNode<Player>("/root/Main/Player");

		var scene = GD.Load<PackedScene>("res://Scenes/Background/ShadowLevelFour.tscn");

        var instance = (ShadowLevelFour)scene.Instantiate();

		instance.ShadowOwner = player;

		_shadowContainer = GetNode<Node2D>("ParallaxBackground/ParallaxLayer3/ShadowContainer");
		_shadowContainer.AddChild(instance);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		AddLightToEnemies();
		AddLightToProjectiles();
	}

    private void AddLightToProjectiles()
    {
        var projectileManager = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");

		var lights = _shadowContainer.GetChildren().ToList();

		var projectilesWithoutLight = projectileManager.EnemiesProjectiles.Where((x) => !lights.Select((y) => ((ShadowLevelFour)y).ShadowOwner).Contains(x)).ToList();

		foreach(var projectile in projectilesWithoutLight)
		{
			var scene = GD.Load<PackedScene>("res://Scenes/Background/ShadowLevelFour.tscn");

        	var instance = (ShadowLevelFour)scene.Instantiate();
			instance.ShadowOwner = projectile;

			_shadowContainer.AddChild(instance);

		}
    }

    private void AddLightToEnemies()
    {
        var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

		var lights = _shadowContainer.GetChildren().ToList();

		var enemiesWithoutLight = enemySpawner.Enemies.Where((x) => !lights.Select((y) => ((ShadowLevelFour)y).ShadowOwner).Contains(x));

		foreach(var enemy in enemiesWithoutLight)
		{
			if(enemy is DimentionalStarship)
				continue;

			var scene = GD.Load<PackedScene>("res://Scenes/Background/ShadowLevelFour.tscn");

        	var instance = (ShadowLevelFour)scene.Instantiate();
			instance.ShadowOwner = enemy;

			_shadowContainer.AddChild(instance);
		}
    }

    public void PauseBackground(bool isPaused)
    {
        
    }
}
