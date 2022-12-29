using System.Collections;
using System.Collections.Generic;
using Godot;
using DanKeTools;
using DanKeTools.Mono;
using System.ComponentModel;
using System;


namespace DanKeTools.Mono
{
    ///<summary>
    ///脚本名称： MonoManager.cs
    ///修改时间：
    ///脚本功能：
    ///备注：
    ///</summary>
    public class MonoManager : Singleton<MonoManager>
    {
        private MonoController controller;

        public MonoManager()
        {

        }

        /// <summary>
        /// 添加帧更新事件
        /// </summary>
        /// <param name="function"></param>
        public void AddUpdateListener(Action function)
        {
            controller.AddUpdateListener(function);
        }

        /// <summary>
        /// 移除帧更新事件
        /// </summary>
        /// <param name="function"></param>
        public void RemoveUpdateListener(Action function)
        {
            controller.RemoveUpdateListener(function);
        }


    }

}