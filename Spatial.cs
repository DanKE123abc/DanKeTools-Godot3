using Godot;
using System;
using DanKeTools.Pool;

public class Spatial : Godot.Spatial
{
    public override void _Process(float delta)
    {
        if (Input.IsActionPressed("right"))
        {
            PackedScene _obj = (PackedScene)GD.Load("res://Cube.tscn");
            Node obj = _obj.Instance();
            //obj = GameObject.Instantiate(Resources.Load<GameObject>(name));
            AddChild(obj);
            Node pool = new Node();
            pool.Name = "Pool";
            AddChild(pool);
        }

        if (Input.IsActionPressed("left"))
        {
            var poolManager = GetNode<PoolManager>("/root/PoolManager");
            poolManager.GetObject("Sphere");
        }
    }
}
