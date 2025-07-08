using Godot;
using System;

public partial class Player : CharacterBody2D
{
    public const float Speed = 200.0f;

    [Export] public PackedScene ShotgunConeScene;
    private Gun gun;
    private AnimatedSprite2D bodySprite;
    private AnimatedSprite2D legSprite;

    public override void _Ready()
    {
        gun = GetNode<Gun>("gun");
        bodySprite = GetNode<AnimatedSprite2D>("BodySprite");
        legSprite = GetNode<AnimatedSprite2D>("LegSprite");

    }

    public override void _PhysicsProcess(double delta)
    {
        HandleMovement();
        RotateTowardsMouse();
    }

    public override void _Process(double delta)
    {
        HandleShoot();
    }

    private void HandleMovement()
    {
        Vector2 direction = Input.GetVector("move_left", "move_right", "move_up", "move_down");
        Vector2 velocity = Velocity;

        if (direction != Vector2.Zero)
        {
            velocity = direction.Normalized() * Speed;
            if (!bodySprite.IsPlaying() || bodySprite.Animation != "walk")
            {
                bodySprite.Play("walk");
                legSprite.Play("walk");
            }
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
            velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);

            if (bodySprite.Animation != "idle")
            {
                bodySprite.Stop();
                legSprite.Stop();
            }
        }

        Velocity = velocity;
        MoveAndSlide();
    }

    private void RotateTowardsMouse()
    {
        Vector2 toMouse = GetGlobalMousePosition() - GlobalPosition;
        Rotation = (float)toMouse.Angle();
    }

    private void HandleShoot()
    {
        if (Input.IsActionJustPressed("fire"))
        {
            gun.Shoot();
        }
    }
}
