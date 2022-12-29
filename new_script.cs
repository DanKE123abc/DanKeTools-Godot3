using Godot;
using System;
using DanKeTools.Event;
using DanKeTools.Net;

public class new_script : Node
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print(Requests.Get("http://httpbin.org/get",""));
		EventCenter.Instance().AddEventListener("Hello",SayHello);
	}

	public void SayHello()
	{
		GD.Print("HHHHHElLO");
	}

}
