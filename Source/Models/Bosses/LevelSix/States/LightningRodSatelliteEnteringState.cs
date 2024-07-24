using Godot;
using Shooter.Source.Interfaces;

namespace Shooter.Source.Models.Bosses.LevelSix.States
{
    public class LightningRodSatelliteEnteringState : IState
    {
        private LightningRodSatellite _node;

        public LightningRodSatelliteEnteringState(LightningRodSatellite node)
        {
            _node = node;
        }

        public IState NextState()
        {
            return new LightningRodSatelliteShootingState(_node); 
        }

        public bool Process()
        {
            _node.Position = new Vector2(_node.Position.X, _node.Position.Y + 5);

            return _node.Position.Y > 200;
        }
    }
}