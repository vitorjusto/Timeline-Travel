using Godot;
using Shooter.Source.Interfaces;

namespace Shooter.Source.Models.Bosses.BossLevelNine.States
{
    public class BossShownUpState : IState
    {
        private FourDWarMachine _boss;

        public BossShownUpState(FourDWarMachine boss)
        {
            _boss = boss;
            _boss.Visible = true;
            _boss.Active = true;
            _boss.GetNode<CollisionShape2D>("CollisionShape2D").Disabled = false;
            _boss.EmitSignal("OnActivated");
        }

        public IState NextState()
        {
            throw new System.NotImplementedException();
        }

        public bool Process()
        {
            return false;
        }
    }
}