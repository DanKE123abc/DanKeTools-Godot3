using Godot;
using System;
using DanKeTools.Pool;

public class Cube : Spatial
{
    public override void _Ready()
    {
        Node pool = GetNode<Node>("../Pool");
        this.GetParent().RemoveChild(this);
        pool.AddChild(this);
    }

}
