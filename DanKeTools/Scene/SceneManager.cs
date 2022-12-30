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
    ///修改时间：2022/12/30
    ///脚本功能：
    ///备注：
    ///</summary>

    public class SceneManager : Node
    {
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
        
        private ResourceInteractiveLoader _loader;
        private double _itemCount;
        private double _nowCount;
        private double _progress;
        private IEnumerator ReallyLoadSceneAsyn(string name, Action func)
        {
            _loader = ResourceLoader.LoadInteractive(name);
            _itemCount = _loader.GetStageCount();
            while (true)
            {
                _nowCount = _loader.GetStage();
                _loader.Poll();
                _progress = _nowCount % _itemCount;
                EventCenter.Instance().EventTrigger("SceneLoading",_progress);
                yield return _progress;
                if (_loader.GetResource() != null)
                {
                    GetTree().ChangeSceneTo((PackedScene)_loader.GetResource());
                    break;
                }
            }
            func();
        }
        
    }

}