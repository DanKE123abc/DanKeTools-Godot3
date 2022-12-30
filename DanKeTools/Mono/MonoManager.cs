using System.Collections;
using System.Collections.Generic;
using Godot;
using System;
using DanKeTools;
using DanKeTools.Mono;
using System.ComponentModel;



namespace DanKeTools.Mono
{
    #region WaitForSeconds 封装
    public class Time
    {
        public const float deltaTime = 0.02f;
        public const int deltaMilTime = 20;
    }
    public interface IWait
    {
        bool Tick();
    }

    
    public class WaitForSeconds : IWait
    {
        public float waitTime = 0;

        public WaitForSeconds(float time)
        {
            waitTime = time;
        }

        bool IWait.Tick()
        {
            waitTime -= Time.deltaTime;
            return waitTime <= 0;
        }
    }

    
    public class WaitForFrame : IWait
    {
        public int waitFrame = 0;

        public WaitForFrame(int frame)
        {
            waitFrame = frame;
        }
        bool IWait.Tick()
        {
            waitFrame--;
            return waitFrame <= 0;
        }
    }
    #endregion
    #region 协程 封装

    public sealed class Coroutine
    {
        private IEnumerator _routine;
        public Coroutine(IEnumerator routine)
        {
            _routine = routine;
        }
        public bool MoveNext()
        {
            if (_routine == null)
                return false;
            return _routine.MoveNext();
        }
        public void Stop()
        {
            _routine = null;
        }
    }

    #endregion
    ///<summary>
    ///脚本名称： MonoManager.cs
    ///修改时间：2022/12/30
    ///脚本功能：
    ///备注：
    ///</summary>
    public class MonoManager : Node
    {
        
        public override void _Ready()
        {
            GD.Print("请确保MonoManager已挂载到AutoLoad作为单例运行！");
        }
        

        /// <summary>
        /// 添加帧更新事件
        /// </summary>
        /// <param name="function"></param>
        public void AddUpdateListener(Action function)
        {
            var controller = GetNode<MonoController>("/root/MonoController");
            controller.AddUpdateListener(function);
        }

        /// <summary>
        /// 移除帧更新事件
        /// </summary>
        /// <param name="function"></param>
        public void RemoveUpdateListener(Action function)
        {
            var controller = GetNode<MonoController>("/root/MonoController");
            controller.RemoveUpdateListener(function);
        }
        

        #region 封装 协程接口

        ///链表存储所有协程对象
        private LinkedList<Coroutine> coroutineList = new LinkedList<Coroutine>();
        private LinkedList<Coroutine> coroutinesToStop = new LinkedList<Coroutine>();
        
        /// <summary>
        /// 开启协程
        /// </summary>
        public Coroutine StartCoroutine(IEnumerator ie)
        {
            var c = new Coroutine(ie);
            coroutineList.AddLast(c);
            return c;
        }
        
        /// <summary>
        /// 停止协程
        /// </summary>
        public void StopCoroutine(Coroutine coroutine)
        {
            coroutinesToStop.AddLast(coroutine);
        }
        
        /// <summary>
        /// 停止所有协程
        /// </summary>
        public void StopAllCoroutines() //停止所有协程
        {
            coroutinesToStop = coroutineList;
        }
    
        //驱动
        public override void _PhysicsProcess(float delta)
        {
            var node = coroutineList.First;
            while (node != null)
            {
                var cor = node.Value;
                bool ret = false;
                if (cor != null)
                {
                    bool toStop = coroutinesToStop.Contains(cor);
                    if (!toStop)
                    {
                        //一旦协程对象返回false，即意味着该协程要退出
                        ret = cor.MoveNext();
                    }
                }
                if (!ret)
                {
                    coroutineList.Remove(node);
                }
                node = node.Next;
            }
        }

        #endregion
        
        
    }

}