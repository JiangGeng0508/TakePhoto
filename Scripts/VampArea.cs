using Godot;
using System;

namespace TakePhoto.Scripts
{
    public partial class VampArea : Area2D
    {
        [Export(PropertyHint.Enum)] public TameStopMode TameStopMode = TameStopMode.Clear;
        [Export] public float TameSpeed = 10f;
        [Export] public float LoseSpeed = 20f;
		private ProgressBar _progressBar;
        private float _tameProgress = 0f;
        private bool _isTaming = false;
        public override void _Ready()
        {
            _progressBar = GetNode<ProgressBar>("TameProgress");
        }

        public void OnAreaEntered(Area2D area)
        {
            if(area.Name != "CursorArea") return;
            //被拍摄时的反应
            _isTaming = true;
            
            GD.Print(" VampArea be caught");
        }

        public void OnAreaExited(Area2D area)
        {
            if(area.Name != "CursorArea") return;
            //镜头离开
            _isTaming = false;
            if (TameStopMode == TameStopMode.Clear) _tameProgress = 0f;
        }

        public override void _PhysicsProcess(double delta)
        {
            if(_tameProgress >= 100f) OnTameFinished();
            if (_isTaming && _tameProgress <= 100f) 
                _tameProgress += TameSpeed * (float)delta;
            else if (TameStopMode == TameStopMode.Lose && _tameProgress >= 0f) 
                _tameProgress -= LoseSpeed * (float)delta;
            _progressBar.Value = _tameProgress;
        }

        public virtual void OnTameFinished() { }
        
    }

    public enum TameStopMode
    {
        Clear,
        Freeze,
        Lose,
    }
}
