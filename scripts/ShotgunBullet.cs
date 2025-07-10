using Godot;
using System;

public partial class ShotgunBullet : Area2D
{
	[Export] public float Speed = 600f;
	[Export] public float MaxDistance = 1000f;
	public Vector2 Direction = Vector2.Zero;
	private Vector2 _startPosition;

	public override void _Ready()
	{
		_startPosition = Position;
	}

	public override void _Process(double delta)
	{
		Position += Direction * Speed * (float)delta;

		float travelled = Position.DistanceTo(_startPosition);

		if (travelled > MaxDistance)
		{
			QueueFree();
		}
	}
}
