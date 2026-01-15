using Godot;
using Shooter.Source.Dumies.Interfaces;
using Shooter.Source.Models.Enemies;
using TimelineTravel.Source.Managers;

namespace Shooter.Source.Dumies.Enemies
{
    public class DGooder : IEnemyDummy
    {
        private readonly int _x;
        private readonly bool _walk;
        private readonly int _maxTimer;

		public DGooder(int x, bool walk, int maxTimer = 900)
        {
            _x = x;
            _walk = walk;
            _maxTimer = maxTimer;
        }

        public Node2D GetInstance()
        {
            var instance = LoaderManager.GetEnemy<Gooder>("Gooder");

            instance.Position = new Vector2(_x, y: -30);
            instance.Walk = _walk;
            instance.MaxTimer = _maxTimer;

            if(GameManager.IsSpecialMode)
                instance.MakeAngry();
                
            return instance;
        }
    }
}