using Godot;
using System;

public partial class ShotgunBullet : Area2D
{
	[Export] public float Speed = 600f;
	public Vector2 Direction= Vector2.Zero;
	public override void _Process(double delta)
	{
		Position +=Direction*Speed*(float)delta;
	}
}
