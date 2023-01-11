using System;
using System.Collections;
using System.Collections.Generic;
using Godot;
using DanKeTools;
using DanKeTools.IO;
using DanKeTools.Mono;

namespace DanKeTools.Voice
{


    ///<summary>
    ///脚本名称： VoiceManager.cs
    ///修改时间：2023/1/11
    ///脚本功能：声音管理器
    ///备注：
    ///</summary>

    public class VoiceManager : Node
    {
        private AudioStreamPlayer bkMusic = null;
        private float bkVaule = 1;
        private float soundVaule = 1;
        private Node soundObj = null;
        private List<AudioStreamPlayer> soundList = new List<AudioStreamPlayer>();

        public override void _Process(float delta)
        {
            for (int i = soundList.Count - 1; i >= 0; i--)
            {
                if (!soundList[i].Playing)
                {
                    soundObj.RemoveChild(soundList[i]);
                    soundList.RemoveAt(i);
                }
            }
        }
        

        /// <summary>
        /// 播放背景音乐
        /// </summary>
        /// <param name="name">背景音乐</param>
        public void PlayBKMusic(string name)
        {
            if (bkMusic == null)
            {
                bkMusic = new AudioStreamPlayer();
                bkMusic.Name = "BKMusic";
                AddChild(bkMusic);
            }

            var fileManager = GetNode<FileManager>("/root/FileManager");
            //异步加载背景音乐并且加载完成后播放
            fileManager.LoadAsync<AudioStream>("Music/BK/" + name, (clip) =>
            {
                bkMusic.Stream = clip;
                //调整大小 
                bkMusic.VolumeDb = bkVaule;
                bkMusic.Play();
            });
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

            bkMusic.Stop();
        }

        /// <summary>
        /// 播放音效
        /// </summary>
        /// <param name="name"></param>
        /// <param name="isLoop"></param>
        /// <param name="callback"></param>
        public void PlaySound(string name, bool isLoop, Action<AudioStreamPlayer> callback = null)
        {
            if (soundObj == null)
            {
                soundObj = new Node();
                soundObj.Name = "Sounds";
                AddChild(soundObj);
            }

            AudioStreamPlayer source = new AudioStreamPlayer();
            source.Name = name;
            soundObj.AddChild(source);
            
            var fileManager = GetNode<FileManager>("/root/FileManager");
            fileManager.LoadAsync<AudioStreamOGGVorbis>("Music/Sounds/" + name, (clip) =>
            {
                clip.Loop = isLoop;
                source.Stream = clip;
                //调整大小 
                source.VolumeDb = soundVaule;
                source.Play();
                //音效资源异步加载结束后，将这个音效组件加入集合中
                soundList.Add(source);
                if (callback != null)
                {
                    callback(source);
                }
            });
        }

        /// <summary>
        /// 改变音效声音大小
        /// </summary>
        /// <param name="value"></param>
        public void ChangeSoundValue(float value)
        {
            soundVaule = value;
            for (int i = 0; i < soundList.Count; ++i)
            {
                soundList[i].VolumeDb = value;
            }
        }

        /// <summary>
        /// 停止音效
        /// </summary>
        /// <param name="source"></param>
        public void StopSound(AudioStreamPlayer source)
        {
            if (soundList.Contains(source))
            {
                soundList.Remove(source);
                source.Stop();
            }
        }
    }

}