using System;
using Godot;
using Shooter.Source.Dumies.Enemies;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.SpaceshipPredador;

namespace Shooter.Source.Models.Bosses.LevelSix.States
{
    public class LightningRodSatelliteLightningState : IState
    {
        private Node2D _node;
        private LightningRodSatelliteMovingAroundState _state;
        private EnemySpawner _enemySpawner;
        private int _time = 0;

        public LightningRodSatelliteLightningState(Node2D node, LightningRodSatelliteMovingAroundState state)
        {
            _node = node;
            _state = state;
            _enemySpawner = _node.GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
        }

        public IState NextState()
        {
            _node.GetTree().Root.GetNode<Hud>("/root/Main/Hud").ShowCustomWarning("None");
            return new Exploding(_node, 150);
        }

        public bool Process(double delta)
        {
            if(_time == 150)
                ShootLightning();
            
            _time++;
            _state.Process(delta);
            return false;
        }

        private void ShootLightning()
        {
            _enemySpawner.AddEnemy(new DLighting((int)_node.Position.X + (new Random().Next(-1, 1) == 1? 40: -40)));

            _time = 0;
        }
    }
}