using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using TakePhoto.Scripts;

public partial class Cursor : Node2D
{
    private List<VampArea> _detectVamps = [];//debug
    private Label _nameList;

    public override void _Ready()
    {
        _nameList = GetNode<Label>("NameList");
    }

    public void OnAreaEntered(Area2D area)
    {
        if (area is VampArea vamp)
        {
            _detectVamps.Add(vamp);
            RefreshNameList();
        }
    }

    public void OnAreaExited(Area2D area)
    {
        if (area is VampArea vamp && _detectVamps.Contains(vamp))
        {
            _detectVamps.Remove(vamp);
            RefreshNameList();
        }
    }

    public void RefreshNameList()
    {
        _nameList.Text = "";
        foreach (var vampArea in _detectVamps)
        {
            _nameList.Text += $"{vampArea.Name}\n";
        }
    }
}
