using Godot;
using System;
using Test;

public class new_script : Node
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Test.Test.Instance().Hello();
    }


}
