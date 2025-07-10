using Godot;
using System;

public partial class Gun : Node2D
{
    [Export] public PackedScene ShotgunBulletScene = GD.Load<PackedScene>("res://scenes/ShotgunBullet.tscn");
    [Export] public int PelletCount = 8;
    [Export] public float SpreadAngle = 15f; // total spread in degrees
    [Export] public float BulletSpeed = 600f;

    public void FireShotgun()
    {
        var baseDirection = (GetGlobalMousePosition() - GlobalPosition).Normalized();

        for (int i = 0; i < PelletCount; i++)
        {
            // Calculate random spread
            float spread = (float)GD.RandRange(-SpreadAngle / 2f, SpreadAngle / 2f);
            float spreadRadians = Mathf.DegToRad(spread);
            Vector2 shotDirection = baseDirection.Rotated(spreadRadians);

            // Instance bullet
            ShotgunBullet bullet = ShotgunBulletScene.Instantiate<ShotgunBullet>();
            bullet.Position = GlobalPosition;
            bullet.Direction = shotDirection;
            bullet.Speed = BulletSpeed;

            GetTree().CurrentScene.AddChild(bullet);
        }
    }

}
