using System.Collections.Generic;
using System.Linq;
using Godot;

namespace TimelineTravel.Source.Managers;

public class LoaderManager
{
	private readonly static List<EnemyLoad> _objects = new();

	public static T GetEnemy<T>(string name) where T : Node2D
	{
		return GetObjectPool<T>($"res://Scenes/Enemies/{name}.tscn");
	}

	public static T GetObjectPool<T>(string path) where T : Node2D
	{
		var enemy = _objects.FirstOrDefault((x) => x.Name.Equals(path));

		if(enemy is not null)
			return (T)(enemy.Scene.Instantiate());
		
		enemy = new EnemyLoad(path, GD.Load<PackedScene>(path));
		_objects.Add(enemy);

		return (T)(enemy.Scene.Instantiate());
	}
}

public class EnemyLoad
{
	public string Name;
	public PackedScene Scene;

	public EnemyLoad(string name, PackedScene scene)
	{
		Name = name;
		Scene = scene;
	}
}
