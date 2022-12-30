using Godot;
using System;
using System.Collections;

namespace UnityEngine
{
    ///<summary>
    ///脚本名称： GodotBase.cs
    ///修改时间：
    ///脚本功能：Godot基础代码
    ///备注：
    ///</summary>
    public class MonoBehaviour : Node
    {
        public bool enabled;

        public void TryCall(string method)
        {
            if (HasMethod(method))
            {
                Call(method);
            }
        }

        public void TryCallDeferred(string method)
        {
            if (HasMethod(method))
            {
                Call(method);
            }
        }

        public override void _Ready()
        {
            enabled = true;
            TryCall("Awake");
            TryCall("OnEnable");
            TryCall("Start");
            TryCall("OnRenderObject");
        }

        public override void _Process(float delta)
        {
            TryCall("Update");
            TryCall("LateUpdate");
        }

        public override void _PhysicsProcess(float delta)
        {
            TryCall("FixedUpdate");
        }
    }

    
}
