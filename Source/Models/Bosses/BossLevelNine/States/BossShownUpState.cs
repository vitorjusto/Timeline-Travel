using Godot;
using Shooter.Source.Interfaces;

namespace Shooter.Source.Models.Bosses.BossLevelNine.States
{
    public class BossShownUpState : IState
    {
        private Node2D _boss;

        public BossShownUpState(Node2D boss)
        {
            _boss = boss;
            _boss.Visible = true;
            _boss.SetProcess(true);
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