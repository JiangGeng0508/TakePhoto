using Godot;
using System;

public partial class PhoneFace : SubViewport
{
    private Camera2D _phoneCamera;
    public override void _Ready()
    {
         _phoneCamera = GetNode<Camera2D>("%PhoneCamera");
    }
}
