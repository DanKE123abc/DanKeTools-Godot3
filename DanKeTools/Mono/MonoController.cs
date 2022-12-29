using Godot;
using System;



namespace DanKeTools.Mono
{
    ///<summary>
    ///脚本名称： MonoController.cs
    ///修改时间：2022/12/29
    ///脚本功能：
    ///备注：
    ///</summary>
    public class MonoController : Node
    {
        private event Action updateEvent;
        
        public override void _Ready()
        {
		    GD.Print("请确保MonoController已添加到AutoLoad");
        }
        
        public override void _Process(float delta)
        {
            if (updateEvent != null)
            {
                updateEvent();
            }
        }

        /// <summary>
        /// 给外部提供的 添加帧更新事件的函数
        /// </summary>
        /// <param name="function"></param>
        public void AddUpdateListener(Action function)
        {
            updateEvent += function;
        }

        /// <summary>
        /// 提供给外部用于移除帧更新事件函数
        /// </summary>
        /// <param name="function"></param>
        public void RemoveUpdateListener(Action function)
        {
            updateEvent -= function;
        }

    }

}