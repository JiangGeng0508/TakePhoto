using Godot;
using System;

namespace TakePhoto.Scripts
{
    public partial class Main : Node2D
    {
        private Node2D _cursor;
        private SubViewport _phone;
        
        public override void _Ready()
        {
            _cursor = GetNode<Node2D>("Cursor");
            _phone = GetNode<SubViewport>("Phone");

            _phone.World2D = GetTree().Root.World2D;
        }

        public override void _PhysicsProcess(double delta)
        {
            _cursor.GlobalPosition = GetGlobalMousePosition();
        }

        public void TakeScreenShot()
        {
            var img = _phone.GetTexture().GetImage();
            var tex = new ImageTexture();
            tex.SetImage(img);
            GetNode<Sprite2D>("Album").Texture = tex;
        }
    }   
}
