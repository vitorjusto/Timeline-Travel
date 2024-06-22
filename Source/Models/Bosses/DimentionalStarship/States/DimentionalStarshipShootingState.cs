using System;
using Godot;
using Shooter.Source.Dumies.Projectiles;
using Shooter.Source.Interfaces;

public class DimentionalStarshipShootingState : IState
{
    private Node2D _node;
    private Player _player;
    private ProjectileManager _projectiles;
    private int _time;

    public DimentionalStarshipShootingState(Node2D node)
    {
        _node = node;
        _player =  _node.GetTree().Root.GetNode<Player>("/root/Main/Player");
        _projectiles = _node.GetTree().Root.GetNode<ProjectileManager>("/root/Main/ProjectileManager");
    }


    public IState NextState()
    {
        return new DimentionalStarshipGoingInvisibleState(_node);
    }

    public bool Process()
    {
        if(_time == 0)
            Shoot();

        _time++;

        return _time > 100;
    }

    private void Shoot()
    {
		var angle = Math.Atan2(_node.Position.X - _player.Position.X, _node.Position.Y - _player.Position.Y);

       
		_projectiles.AddProjectile(new DLightProjectile(_node.Position.X, _node.Position.Y, (float)Math.Sin(angle) * (-3), (float)Math.Cos(angle) * (-3)));
		_projectiles.AddProjectile(new DLightProjectile(_node.Position.X, _node.Position.Y, (float)Math.Sin(angle + 0.6) * (-3), (float)Math.Cos(angle + 0.6) * (-3)));
		_projectiles.AddProjectile(new DLightProjectile(_node.Position.X, _node.Position.Y, (float)Math.Sin(angle - 0.6) * (-3), (float)Math.Cos(angle - 0.6) * (-3)));
		_projectiles.AddProjectile(new DLightProjectile(_node.Position.X, _node.Position.Y, (float)Math.Sin(angle + 0.3) * (-3), (float)Math.Cos(angle + 0.3) * (-3)));
		_projectiles.AddProjectile(new DLightProjectile(_node.Position.X, _node.Position.Y, (float)Math.Sin(angle - 0.3) * (-3), (float)Math.Cos(angle - 0.3) * (-3)));
		
    }
}
