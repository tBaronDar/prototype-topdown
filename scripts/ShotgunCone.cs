using Godot;
using System;

public partial class ShotgunCone : Area2D
{
	 public float Lifetime = 0.2f; // seconds the cone stays alive
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// Optional: play an animation
		var animPlayer = GetNodeOrNull<AnimationPlayer>("AnimationPlayer");
		animPlayer?.Play("shoot"); // if you have one

		// Queue the cone for deletion after its lifetime
		GetTree().CreateTimer(Lifetime).Timeout += QueueFree;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
