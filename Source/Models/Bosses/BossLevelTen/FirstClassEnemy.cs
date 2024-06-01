using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;
using Shooter.Source.Models.Bosses.SpaceshipPredador;

public partial class FirstClassEnemy : Node2D, IEnemy
{
	private int _hp = 10;
	private int _Iframe = 0;
    private ProjectileManager _projectiles;
	private int _timer;
    private Player _player;
    private bool _showingIFrameAnimation;

    public override void _Ready()
	{
		_projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");
		Position = new Vector2((int)ProjectSettings.GetSetting("display/window/size/viewport_width")/2, -100);

		_player = GetTree().Root.GetNode<Player>("/root/Main/Player");
	}

    public override void _Process(double delta)
	{

		if(Position.Y < 100)
		{
			Position += new Vector2(0, 12);
			return;
		}
		if(Position.X < _player.Position.X - 5)
		{
			Position += new Vector2(10, 0);
		}else if(Position.X > _player.Position.X + 5)
		{
			Position -= new Vector2(10, 0);
		}

		if(_Iframe > 0)
		{
			if(_Iframe % 5 == 0)
			{
				_showingIFrameAnimation = !_showingIFrameAnimation;
			}
			_Iframe--;
			Visible = _showingIFrameAnimation;

		}else
			Visible = true;

		_timer++;
		if(_timer == 10)
			Shoot();
	}

    private void Shoot()
    {
        _timer = 0;

		_projectiles.AddProjectile(new DLightProjectile(Position.X, Position.Y, 0, 4));
    }

    public void Destroy()
    {
		if(_Iframe > 0)
			return;
		
		_Iframe = 60;
        _hp--;

		if(_hp == 0)
		{
			GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner").RemoveEnemy(this);
			GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner").EndLevel();

		}
    }

    public bool IsImortal()
    {
        return true;
    }
}
