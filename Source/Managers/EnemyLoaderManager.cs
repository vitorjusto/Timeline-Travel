using System.Collections.Generic;
using System.Linq;
using Godot;

namespace TimelineTravel.Source.Managers
{
    public class LoaderManager
    {
        private static List<EnemyLoad> _enemies = new();

		public static T GetEnemy<T>(string name) where T : Node2D
		{
			var enemy = _enemies.FirstOrDefault((x) => x.Name.Equals(name));

			if(enemy is not null)
				return (T)(enemy.Scene.Instantiate());
			
			enemy = new EnemyLoad(name, GD.Load<PackedScene>($"res://Scenes/Enemies/{name}.tscn"));
			_enemies.Add(enemy);

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
}