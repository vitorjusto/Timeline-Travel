using System.Text.RegularExpressions;
using Godot;
using System;
using Shooter.Source.Interfaces;

public partial class Curver : CharacterBody2D, IEnemy
{
	private int _speed = 3;
	private float _time = 0f;
	private float _originalPosition = 0;
	private float _xspeedModifier = 3;

    public override void _Process(double delta)
	{
		MoveEnemy();
	}

    private void MoveEnemy()
    {

		//se você quiser aumentar a distancia, altere o B (30), se você quiser aumentar a velocidade altere o A (-6)
		float _xspeed = (-6 * (_time * _time)) + (_time * 30f);

		_xspeed *= _xspeedModifier; 

        Position = new Vector2(x:_originalPosition + _xspeed, y: Position.Y + _speed);

		_time += 0.1f;

		//Caso altere o A ou o B, faça |B/A| e coloca aqui
		if(_time > 5)
		{
			_time = 0;
			_xspeedModifier *= (-1);
		}

    }

    public void OnScreenExited()
    {
        var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

        enemySpawner.RemoveEnemy(this);
    }

	public bool IsImortal()
	{
		return false;
	}

	public void SetPosition(float x)
	{
		_originalPosition = x;
		Position = new Vector2(x, y: -30);
	}

    public void Destroy()
    {
        var enemySpawner = GetTree().Root.GetNode<EnemySpawner>("/root/Main/EnemySpawner");

        enemySpawner.RemoveEnemy(this);
    }
}
