using Godot;
using System;
using DanKeTools.Voice;

public class Spatial : Godot.Spatial
{
    public override void _Process(float delta)
    {
        if (Input.IsActionPressed("right"))
        {
            GD.Print("try play bk");
            var voiceManager = GetNode<VoiceManager>("/root/VoiceManager");
            voiceManager.PlayBKMusic("test");
        }
        if (Input.IsActionPressed("left"))
        {
            GD.Print("try play ogg");
            var voiceManager = GetNode<VoiceManager>("/root/VoiceManager");
            voiceManager.PlaySound("water",false);
        }

    }
}
