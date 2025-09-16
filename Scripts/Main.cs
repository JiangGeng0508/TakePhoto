using Godot;
using System;

namespace TakePhoto.Scripts
{
    public partial class Main : Node2D
    {
        private SubViewport _phoneFace;
        private Camera2D _phoneCamera;
        private Node2D _cursor;
        private Sprite2D _canvas;

        public override void _Ready()
        {
            _phoneFace = GetNode<SubViewport>("%PhoneFace");
            _phoneCamera = GetNode<Camera2D>("%PhoneCamera");
            _cursor = GetNode<Node2D>("%Cursor");
            _canvas = GetNode<Sprite2D>("TestCanvas");
            
        }

        public override void _Process(double delta)
        {
            _cursor.GlobalPosition = GetGlobalMousePosition();
            var dir = Input.GetVector("Left", "Right", "Up", "Down");
            _canvas.Position += dir * 1f;
        }

        public void TakeScreenShot()
        {  
            var img = GetViewport().GetTexture().GetImage();
            var tex = new ImageTexture();
            tex.SetImage(img);
            _canvas.Texture = tex;
        }
    }   
}
