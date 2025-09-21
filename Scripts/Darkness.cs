using Godot;
using System;

public partial class Darkness : ColorRect
{
    public bool IsActive = true;
    
    private ShaderMaterial _shaderMaterial;

    public override void _Ready()
    {
        _shaderMaterial = (ShaderMaterial)Material;

        _shaderMaterial.SetShaderParameter("screen_width", GetViewportRect().Size.X);
        _shaderMaterial.SetShaderParameter("screen_height", GetViewportRect().Size.Y);
    }

    public override void _PhysicsProcess(double delta)
    {
        if (!IsActive) return;
        SetSpotlight(GetViewport().GetMousePosition());
    }

    public void SetSpotlight(Vector2 pos)
    {
        _shaderMaterial.SetShaderParameter("circle_position",pos / GetViewportRect().Size);
    }
}
