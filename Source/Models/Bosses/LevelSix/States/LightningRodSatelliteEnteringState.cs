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

        public bool Process(double delta)
        {
            _node.Position += new Vector2(0, 5) * (float)(delta * 60);

            return _node.Position.Y > 200;
        }
    }
}