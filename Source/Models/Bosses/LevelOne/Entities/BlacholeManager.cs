using System;
using System.Collections.Generic;
using Godot;
using Shooter.Source.Models.Bosses.LevelOne.Enums;

namespace Shooter.Source.Models.Bosses.LevelOne.Entities
{
    public class BlackholeManager
    {
        private List<BlackHoleGeneratorPart> _parts;
        private BlackHoleGenerator _boss;
	    private int _blackHoleTime;
        private EnemySpawner _enemySpawner;
        private Node2D _leftArm;
        private Node2D _rightArm;

        public BlackholeManager(BlackHoleGenerator boss, BlackHoleGeneratorPart _leftPart, BlackHoleGeneratorPart _rightPart, Node2D leftArm, Node2D rightArm )
        {
            _boss = boss;
            _parts = new();

            _parts.Add(_leftPart);
            _parts.Add(_rightPart);

            _leftPart.Boss = _boss;
            _rightPart.Boss = _boss;

            _enemySpawner = _boss.GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

            _leftArm = leftArm;
            _rightArm = rightArm;
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

            if(_part.PartSide == EPartSide.Left)
                ExplodeLeftArm();
            else
                ExplodeRightArm();
        }

        public void ExplodeLeftArm()
        {
            _leftArm.QueueFree();
            _enemySpawner.AddExplosion(_boss.Position + new Vector2(-100, 0));
            _enemySpawner.AddExplosion(_boss.Position + new Vector2(-180, 0));
            _enemySpawner.AddExplosion(_boss.Position + new Vector2(-260, 0));
            _enemySpawner.AddExplosion(_boss.Position + new Vector2(-260, 20));
        }

        public void ExplodeRightArm()
        {
            _rightArm.QueueFree();
            _enemySpawner.AddExplosion(_boss.Position + new Vector2(100, 0));
            _enemySpawner.AddExplosion(_boss.Position + new Vector2(180, 0));
            _enemySpawner.AddExplosion(_boss.Position + new Vector2(260, 0));
            _enemySpawner.AddExplosion(_boss.Position + new Vector2(260, 40));
        }
    }
}