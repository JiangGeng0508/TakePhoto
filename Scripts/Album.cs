using Godot;
using System;

namespace TakePhoto.Scripts;
public partial class Album : Sprite2D
{
    [Export] public SubViewport Phone;

    public override void _Ready()
    {
        if (Phone is null) Phone = GetNode<SubViewport>("%Capture/Phone");
        
    }

    public void TakeScreenShot()
    {
        if (Phone is null) return;
        var img = Phone.GetTexture().GetImage();
        var tex = new ImageTexture();
        tex.SetImage(img);
        Texture = tex;
    }
}
