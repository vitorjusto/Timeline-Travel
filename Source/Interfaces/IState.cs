namespace Shooter.Source.Interfaces
{
    public interface IState
    {
        public bool Process();
        public IState NextState();
    }
}