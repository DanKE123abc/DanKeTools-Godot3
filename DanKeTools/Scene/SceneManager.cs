using System.Collections;
using System.Collections.Generic;
using Godot;
using System;
using System.ComponentModel;
using DanKeTools;
using DanKeTools.Event;


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
            
            CoroutineManager.Instance().Start(ReallyLoadSceneAsyn(name,func));
            CoroutineManager.Instance().UpdateCoroutine();
        }
        
        private IEnumerator ReallyLoadSceneAsyn(string name, Action func)
        {
            GetTree().ChangeScene(name);
            GD.PrintErr("xiec");
            yield return true;
            func();
        }
    }

}