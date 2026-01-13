using System;
using Godot;
using Shooter.Source.Dumies.Enemies;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.SpaceshipPredador;
using Shooter.Source.Models.Misc;

namespace Shooter.Source.Models.Bosses.LevelSix.States
{
    public class LightningRodSatelliteLightningState : IState
    {
        private Node2D _node;
        private LightningRodSatelliteMovingAroundState _state;
        private EnemySpawner _enemySpawner;
        private QuickTimer _time = new(150);

        public LightningRodSatelliteLightningState(Node2D node, LightningRodSatelliteMovingAroundState state)
        {
            _node = node;
            _state = state;
            _enemySpawner = _node.GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");
        }

        public IState NextState()
        {
            Hud.ShowCustomWarning("None");
            return new Exploding(_node, 150);
        }

        public bool Process(double delta)
        {
            if(_time.Process(delta))
                ShootLightning();
            
            _state.Process(delta);
            return false;
        }

        private void ShootLightning()
        {
            _enemySpawner.AddEnemy(new DLighting((int)_node.Position.X + (new Random().Next(-1, 1) == 1? 40: -40)));
        }
    }
}