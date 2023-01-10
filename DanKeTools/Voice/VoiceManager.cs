using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using DanKeTools;
using DanKeTools.IO;
using DanKeTools.Mono;
using Godot;

namespace DanKeTools.Voice
{


    ///<summary>
    ///脚本名称： VoiceManager.cs
    ///修改时间：2022/12/25
    ///脚本功能：声音管理器
    ///备注：
    ///</summary>

    public class VoiceManager : Node
    {
        private AudioStreamPlayer bkMusic = null;
        private float bkVaule = 1;
        private float soundVaule = 1;
        private AudioStreamPlayer soundObj = null;
        private List<AudioStream> soundList = new List<AudioStream>();
        
        /// <summary>
        /// 播放背景音乐
        /// </summary>
        /// <param name="name">背景音乐</param>
        public void PlayBKMusic(string name)
        {
            if (bkMusic == null)
            {
                bkMusic = GetNode<AudioStreamPlayer>("/root/VoicePlayer/BKMusicPlayer");
            }

            var fileManager = GetNode<FileManager>("/root/FileManager");
            bkMusic.Stream = fileManager.Load<AudioStream>("Music/BK/" + name);
            //异步加载背景音乐并且加载完成后播放
            bkMusic.VolumeDb = bkVaule; 
            bkMusic.Playing = true;
            
        }

        /// <summary>
        /// 改变背景声音大小
        /// </summary>
        /// <param name="v">大小</param>
        public void ChangeBKValue(float v)
        {
            bkVaule = v;
            if (bkMusic == null)
            {
                return;
            }

            bkMusic.VolumeDb = bkVaule;
        }

        /// <summary>
        /// 暂停背景音乐
        /// </summary>
        public void PauseBKMusic()
        {
            if (bkMusic == null)
            {
                return;
            }

            bkMusic.StreamPaused = true;
        }

        /// <summary>
        /// 停止背景音乐
        /// </summary>
        public void StopBKMusic()
        {
            if (bkMusic == null)
            {
                return;
            }

            bkMusic.Playing = false;
        }

        
    }

}