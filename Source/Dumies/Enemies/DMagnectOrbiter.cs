using Godot;
using Shooter.Source.Dumies.Interfaces;
using Shooter.Source.Enums;

namespace Shooter.Source.Dumies.Enemies
{
    public class DMacnectOrbiter : IEnemyDummy
    {
        private ESpawnPosition _spawnPosition;


        public DMacnectOrbiter(ESpawnPosition spawnPosition)
        {
            _spawnPosition = spawnPosition;
        }

        public Node2D GetInstance()
        {
            var scene = GD.Load<PackedScene>("res://Scenes/Bosses/BossLevelFive/MacnectOrbiter.tscn");

            var instance = (MacnectOrbiter)scene.Instantiate();

            instance.SpawnPosition = _spawnPosition;

            return instance;
        }
    }
}