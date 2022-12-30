using Godot;
using System;
using System.Collections;

namespace DanKeTools
{
    ///<summary>
    ///脚本名称： GodotBase.cs
    ///修改时间：
    ///脚本功能：Godot基础代码
    ///备注：
    ///</summary
    public class MonoBehaviour : Node
    {
        public virtual void Start()
        {

        }

        public virtual void Awake()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void FixedUpdate()
        {

        }



        public override void _Ready()
        {
            Awake();
            Start();
        }

        public override void _Process(float delta)
        {
            Update();
        }

        public override void _PhysicsProcess(float delta)
        {
            FixedUpdate();
        }
    }

    
}
