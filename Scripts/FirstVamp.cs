using Godot;
using System;

namespace TakePhoto.Scripts
{
    public partial class FirstVamp : VampArea
    {
        private AnimationPlayer _anim;

        public override void _Ready()
        {
            base._Ready();
            
            _anim = GetNode<AnimationPlayer>("VampAnim");
            _anim.Stop();
        }

        public override void OnTameFinished()
        {
            GD.Print("1st Vamp be Tamed");
        }

        public override void OnTameStarted()
        {
            _anim.Play("1vpAnim");
        }

        public override void OnTameBroken()
        {
            _anim.Stop();
        }

        public override void _PhysicsProcess(double delta)
        {
            base._PhysicsProcess(delta);
            if (IsTaming)
            {

            }
        }
    }
}
