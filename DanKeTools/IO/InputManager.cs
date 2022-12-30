using System.Collections;
using System.Collections.Generic;
using Godot;
using System;
using System.Diagnostics;
using DanKeTools;
using DanKeTools.Event;
using DanKeTools.Mono;

namespace DanKeTools.IO
{

    ///<summary>
    ///脚本名称： InputManager.cs
    ///修改时间：2022/12/30
    ///脚本功能：
    ///备注：
    ///</summary>

    public class InputManager : Node
    {
        private bool isStart = false;
        
        public override void _UnhandledInput(InputEvent @event)
        {
            if (@event is InputEventKey eventKey)
            {
                CheckKeyCode(eventKey , KeyList.A);
            }
        }

        
        
        private void CheckKeyCode(InputEventKey eventKey, KeyList key)
        {
            if (GetKeyDown(eventKey,key))
            {
                DownTrigger(key);
            }

            if (GetKeyUp(eventKey, key))
            {
                UpTrigger(key);
            }
        }
        private void DownTrigger(KeyList key)
        {
            if (isStart)
            {
                EventCenter.Instance().EventTrigger("KeyisDown", key);
            }
        }
        private void UpTrigger(KeyList key)
        {
            if (isStart)
            {
                EventCenter.Instance().EventTrigger("KeyisUp", key);
            }
        }
        private bool GetKeyDown(InputEventKey eventKey ,KeyList key)
        {
            if (eventKey.Pressed && eventKey.Scancode == (ulong)key)
            {
                return true;
            }
            return false;
        }
        private bool GetKeyUp(InputEventKey eventKey ,KeyList key)
        {
            if (eventKey.Pressed == false && eventKey.Scancode == (ulong)key)
            {
                return true;
            }
            return false;
        }

    }

}
