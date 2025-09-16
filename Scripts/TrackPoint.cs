using Godot;
using System;

namespace TakePhoto.Scripts
{
    public partial class TrackPoint : VisibleOnScreenNotifier2D
    {
        public override void _Ready()
        {
            ScreenEntered += OnScreenEnter;
        }

        public void OnScreenEnter()
        {
            GD.Print("Screen Enter");
        }
    }
}
