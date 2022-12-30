using System.Collections;
using System.Collections.Generic;
using System;
using DanKeTools;

namespace DanKeTools
{


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

    ///使用单例模式的协程管理器，用于驱动所有协程MoveNext
    public class CoroutineManager : Singleton<CoroutineManager>
    {

        ///链表存储所有协程对象
        private LinkedList<Coroutine> coroutineList = new LinkedList<Coroutine>();

        private LinkedList<Coroutine> coroutinesToStop = new LinkedList<Coroutine>();

        ///开启一个协程
        public Coroutine Start(IEnumerator ie)
        {
            var c = new Coroutine(ie);
            coroutineList.AddLast(c);
            return c;
        }

        ///关闭一个协程
        public void Stop(IEnumerator ie)
        {

        }

        public void Stop(Coroutine coroutine)
        {
            coroutinesToStop.AddLast(coroutine);
        }

        ///主线程驱动所有协程对象
        public void UpdateCoroutine()
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
                    Console.WriteLine("[CoroutineManager] remove cor");
                }

                node = node.Next;
            }
        }
    }

}