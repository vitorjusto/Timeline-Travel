using Godot;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.BossLevelNine.States;

public partial class FourDWarMachineBase : Node2D, ICustomBossPosition
{
	private AnimatedSprite2D _aniEntreringPortal;
    private FourDWarMachine _boss;
    private IState _state;
	public override void _Ready()
	{
		_aniEntreringPortal = GetNode<AnimatedSprite2D>("aniEntreringPortal");
		_boss = GetNode<FourDWarMachine>("4DWarMachine");
		_state = new BossEntreringAnimationState(_aniEntreringPortal, _boss);
	}

	public override void _Process(double delta)
	{
		if(_state.Process())
		{
			_state = _state.NextState();
		}
	}

	public void OnHalfHealth()
	{
		_state = new BackInTimeTransitionState(_aniEntreringPortal, _boss, GetNode<Panel>("ParallaxBackground/Panel"));
	}

    public Vector2 GetPosition()
    {
        return GetNode<Node2D>("4DWarMachine").Position;
    }
}
