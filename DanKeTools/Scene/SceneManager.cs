using System.Collections;
using System.Collections.Generic;
using Godot;
using System;
using System.ComponentModel;
using DanKeTools;
using DanKeTools.Event;
using DanKeTools.Mono;


namespace DanKeTools.Scene
{

    ///<summary>
    ///脚本名称： SceneManager.cs
    ///修改时间：2022/12/23
    ///脚本功能：
    ///备注：
    ///</summary>

    public class SceneManager : Node
    {
        public override void _Ready()
        {
            GD.PrintErr("请确保SceneManager已挂载到AutoLoad作为单例运行！");
        }

        public void LoadScene(string name, Action func)
        {
            GetTree().ChangeScene(name);
            func();
        }
        
        public void LoadSceneAsyn(string name, Action func)
        {
            var monoManager = GetNode<MonoManager>("/root/MonoManager");
            monoManager.StartCoroutine(ReallyLoadSceneAsyn(name, func));
        }
        
        private IEnumerator ReallyLoadSceneAsyn(string name, Action func)
        {
            GetTree().ChangeScene(name);
            func();
            yield return true;
        }
    }

}