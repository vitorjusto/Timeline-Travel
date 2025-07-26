namespace Shooter.Source.Interfaces
{
    public interface IState
    {
        public bool Process(double delta);
        public IState NextState();
    }
}