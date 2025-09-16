using Godot;
using System;

namespace TakePhoto.Scripts
{
    public partial class MainCamera : Camera2D
    {
        [Export] public float CameraSpeed = 10f;

        public override void _Input(InputEvent @event)
        {
            var dir = Input.GetVector("Left", "Right", "Up", "Down");
            Position += dir * CameraSpeed;
        }
    }
}
