using Godot;
using System;

namespace TakePhoto.Scripts
{
    public partial class VampArea : Area2D
    {
        public void OnAreaEntered(Area2D area)
        {
            if(area.Name != "CursorArea") return;
            GD.Print(" VampArea be caught");
        }
    }
}
