using Godot;
using Shooter.Source.Dumies.Interfaces;
using Shooter.Source.Models.Enemies;
using TimelineTravel.Source.Managers;

namespace Shooter.Source.Dumies.Enemies
{
    public class DOrbiter : IEnemyDummy
    {
		public Node2D GetInstance()
        	=> LoaderManager.GetEnemy<Orbiter>("Orbiter");

    }
}