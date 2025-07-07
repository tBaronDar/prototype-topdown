using Godot;
using System;

public partial class Gun : Node2D
{
    [Export] public PackedScene ShotgunConeScene;

    public void Shoot()
    {
        if (ShotgunConeScene == null)
        {
            GD.PrintErr("ShotgunConeScene is not assigned!");
            return;
        }

        var coneInstance = (ShotgunCone)ShotgunConeScene.Instantiate();

        // Add to scene
        GetTree().CurrentScene.AddChild(coneInstance);

        // Offset the cone in front of the gun
        Vector2 offset = new Vector2(0, -10); // adjust as needed
        offset = offset.Rotated(GlobalRotation);
        coneInstance.GlobalPosition = GlobalPosition + offset;
        coneInstance.Rotation = GlobalRotation;
    }
}
