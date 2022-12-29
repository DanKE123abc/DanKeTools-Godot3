using System.Collections;
using System.Collections.Generic;
using Godot;
using System;
using System.ComponentModel;
using DanKeTools;
using DanKeTools.Event;
using Object = Godot.Object;


namespace DanKeTools.Scene
{
    
    ///<summary>
    ///脚本名称： SceneManager.cs
    ///修改时间：2022/12/23
    ///脚本功能：
    ///备注：
    ///</summary>

    public class SceneManager : Singleton<SceneManager>
    {
        static GDScript MyGDScript = (GDScript) GD.Load("res://DanKeTools/Scene/GodotSceneManager.gd");
        Object myGDScriptNode = (Godot.Object) MyGDScript.New(); // This is a Godot.Object
        
        public void LoadScene(string name, Action func)
        {
            myGDScriptNode.Call("LoadScene", name);
            func();
        }

        
        
    }

}