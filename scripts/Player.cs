using Godot;
using System;

public partial class Player : CharacterBody2D
{
    public const float Speed = 200.0f;

    [Export] public PackedScene ShotgunConeScene;
    private Gun gun;

    public override void _Ready()
    {
        gun = GetNode<Gun>("gun");
    }

    public override void _PhysicsProcess(double delta)
    {
        HandleMovement();
        RotateTowardsMouse();
    }

    public override void _Process(double delta)
    {
        HandleInput();
    }

    private void HandleMovement()
    {
        Vector2 direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");
        Vector2 velocity = Velocity;

        if (direction != Vector2.Zero)
        {
            velocity = direction * Speed;
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
            velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
        }

        Velocity = velocity;
        MoveAndSlide();
    }

    private void RotateTowardsMouse()
    {
        Vector2 toMouse = GetGlobalMousePosition() - GlobalPosition;
        Rotation = (float)(toMouse.Angle() + Math.PI / 2);
    }

    private void HandleInput()
    {
        if (Input.IsActionJustPressed("fire"))
        {
            gun.Shoot();
        }
    }
}
