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
        
        public void InputCheck(bool isOpen)
        {
            isStart = isOpen;
        }
        
        public override void _UnhandledInput(InputEvent @event)
        {
            if (isStart)
            {
                if (@event is InputEventKey eventKey)
                {
                    #region 按键监听列表

                    CheckKeyCode(eventKey, KeyList.A);
                    CheckKeyCode(eventKey, KeyList.B);
                    CheckKeyCode(eventKey, KeyList.C);
                    CheckKeyCode(eventKey, KeyList.D);
                    CheckKeyCode(eventKey, KeyList.E);
                    CheckKeyCode(eventKey, KeyList.F);
                    CheckKeyCode(eventKey, KeyList.G);
                    CheckKeyCode(eventKey, KeyList.H);
                    CheckKeyCode(eventKey, KeyList.I);
                    CheckKeyCode(eventKey, KeyList.J);
                    CheckKeyCode(eventKey, KeyList.K);
                    CheckKeyCode(eventKey, KeyList.L);
                    CheckKeyCode(eventKey, KeyList.M);
                    CheckKeyCode(eventKey, KeyList.N);
                    CheckKeyCode(eventKey, KeyList.O);
                    CheckKeyCode(eventKey, KeyList.P);
                    CheckKeyCode(eventKey, KeyList.Q);
                    CheckKeyCode(eventKey, KeyList.R);
                    CheckKeyCode(eventKey, KeyList.S);
                    CheckKeyCode(eventKey, KeyList.T);
                    CheckKeyCode(eventKey, KeyList.U);
                    CheckKeyCode(eventKey, KeyList.V);
                    CheckKeyCode(eventKey, KeyList.W);
                    CheckKeyCode(eventKey, KeyList.X);
                    CheckKeyCode(eventKey, KeyList.Y);
                    CheckKeyCode(eventKey, KeyList.Z);
                    CheckKeyCode(eventKey, KeyList.Key0);
                    CheckKeyCode(eventKey, KeyList.Key1);
                    CheckKeyCode(eventKey, KeyList.Key2);
                    CheckKeyCode(eventKey, KeyList.Key3);
                    CheckKeyCode(eventKey, KeyList.Key4);
                    CheckKeyCode(eventKey, KeyList.Key5);
                    CheckKeyCode(eventKey, KeyList.Key6);
                    CheckKeyCode(eventKey, KeyList.Key7);
                    CheckKeyCode(eventKey, KeyList.Key8);
                    CheckKeyCode(eventKey, KeyList.Key9);
                    CheckKeyCode(eventKey, KeyList.F1);
                    CheckKeyCode(eventKey, KeyList.F2);
                    CheckKeyCode(eventKey, KeyList.F3);
                    CheckKeyCode(eventKey, KeyList.F4);
                    CheckKeyCode(eventKey, KeyList.F5);
                    CheckKeyCode(eventKey, KeyList.F6);
                    CheckKeyCode(eventKey, KeyList.F7);
                    CheckKeyCode(eventKey, KeyList.F8);
                    CheckKeyCode(eventKey, KeyList.F9);
                    CheckKeyCode(eventKey, KeyList.F10);
                    CheckKeyCode(eventKey, KeyList.F11);
                    CheckKeyCode(eventKey, KeyList.F12);
                    CheckKeyCode(eventKey, KeyList.Up);
                    CheckKeyCode(eventKey, KeyList.Down);
                    CheckKeyCode(eventKey, KeyList.Right);
                    CheckKeyCode(eventKey, KeyList.Left);
                    CheckKeyCode(eventKey, KeyList.Escape);
                    CheckKeyCode(eventKey, KeyList.Shift);
                    CheckKeyCode(eventKey, KeyList.Capslock);
                    CheckKeyCode(eventKey, KeyList.Tab);
                    CheckKeyCode(eventKey, KeyList.Enter);
                    CheckKeyCode(eventKey, KeyList.Alt);
                    CheckKeyCode(eventKey, KeyList.Control);
                    CheckKeyCode(eventKey, KeyList.Comma);
                    CheckKeyCode(eventKey, KeyList.Delete);
                    CheckKeyCode(eventKey, KeyList.Backspace);

                    #endregion
                }
            }
        }



        private void CheckKeyCode(InputEventKey eventKey, KeyList key)
        {

            if (GetKeyDown(eventKey, key))
            {
                EventCenter.Instance().EventTrigger("KeyisDown", key);
            }

            if (GetKeyUp(eventKey, key))
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
