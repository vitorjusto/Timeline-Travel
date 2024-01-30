using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.SpaceshipPredador;

public partial class SpaceshipPredadorModel : CharacterBody2D, IEnemy
{
    private IState _currentState;
    public int Hp = 100;

    public override void _Ready()
    {
        Position = new Vector2((int)ProjectSettings.GetSetting("display/window/size/viewport_width") / 2, -100);

        _currentState = new EnteringScreen(this);
    }
    public override void _Process(double delta)
    {
        if(_currentState.Process())
            _currentState = _currentState.NextState();
    }

    public void Destroy()
    {
        Hp--;

        if(Hp == 0)
            _currentState = new Exploding(this);
    }

    public bool IsImortal()
    {
        return true;
    }

}
