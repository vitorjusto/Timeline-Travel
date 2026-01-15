using Godot;
using Shooter.Source.Dumies.Interfaces;
using Shooter.Source.Models.Enemies.Parts;
using TimelineTravel.Source.Managers;

namespace Shooter.Source.Dumies.Enemies.EnemiesPart
{
    public class DLazerPart: IEnemyDummy
    {
        private readonly float _x;
        private readonly float _y;
        private readonly int _maxTimer;
        public DLazerPart(float x, float y, int maxTimer)
        {
            _x = x;
            _y = y;
            _maxTimer = maxTimer;
        }

        public Node2D GetInstance()
        {
            var instance = LoaderManager.GetEnemy<LazerPart>("EnemiesPart/LazerPart");

            instance.Position = new Vector2(_x, _y);
            instance.SetMaxTimer(_maxTimer);

            return instance;
        }
    }
}