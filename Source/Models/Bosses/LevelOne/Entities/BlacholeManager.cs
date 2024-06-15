using System;
using System.Collections.Generic;

namespace Shooter.Source.Models.Bosses.LevelOne.Entities
{
    public class BlackholeManager
    {
        private List<BlackHoleGeneratorPart> _parts;
        private BlackHoleGenerator _boss;
	    private int _blackHoleTime;
        private EnemySpawner _enemySpawner;

        public BlackholeManager(BlackHoleGenerator boss, BlackHoleGeneratorPart _leftPart, BlackHoleGeneratorPart _rightPart )
        {
            _boss = boss;
            _parts = new();

            _parts.Add(_leftPart);
            _parts.Add(_rightPart);

            _leftPart.Boss = _boss;
            _rightPart.Boss = _boss;

            _enemySpawner = _boss.GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

        }

        public void Update()
        {
            _blackHoleTime++;
		    if(_blackHoleTime == 200)
			    ShowBlackHole();
        }

        private void ShowBlackHole()
        {
            var part = _parts[new Random().Next(0, _parts.Count)];
    
	    	part.OnShowBlackHole();
	    	_blackHoleTime = 0;
        }

        public void RemovePart(BlackHoleGeneratorPart _part)
        {
            _enemySpawner.AddExplosion(_part.Position + _boss.Position);
            _parts.Remove(_part);
        }
    }
}