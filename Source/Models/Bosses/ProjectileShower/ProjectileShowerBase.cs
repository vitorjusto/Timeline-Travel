using System;
using Godot;
using Shooter.Source.Dumies.Projectiles;

public partial class ProjectileShowerBase : Node2D
{
	private int _timer;
	private int _timerCowdown = 20;
    private ProjectileManager _projectiles;
    private ProjectileShower _boss;

    public override void _Ready()
	{
		_projectiles = GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");
		_boss = GetNode<ProjectileShower>("ProjectileShower");
	}

	public override void _Process(double delta)
	{

		_timer++;

		if(_timer < _timerCowdown)
			return;

		_timer = 0;

		if(_boss.IsExploding)
		{
			return;
		}

		_projectiles.AddProjectile(new DLightProjectile(new Random().Next(100, 1700) , -32, -2, 4));

		if(_boss.Hp < 100)
		{
			_projectiles.AddProjectile(new DLightProjectile(new Random().Next(100, 1700) , -32, -2, 4));
		}

		if(_boss.Hp < 70)
		{
			_timerCowdown = 15;
			_projectiles.AddProjectile(new DLightProjectile(new Random().Next(100, 1700) , -32, -2, 4));
		}

		if(_boss.Hp <= 30)
			_timerCowdown = 30;

		if(_boss.Hp < 20)
			_projectiles.AddProjectile(new DNormalProjectile(new Random().Next(100, 1600) , -10, -1, 3));
		
		if(_boss.Hp < 10)
			_projectiles.AddProjectile(new DStrongProjectile(new Random().Next(100, 1600) , -10, -1, 2));
	}
}
