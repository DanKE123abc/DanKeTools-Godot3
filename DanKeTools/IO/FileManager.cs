using System.Collections;
using System.Collections.Generic;
using System.IO;
using Godot;
using System;
using DanKeTools;
using DanKeTools.Mono;


namespace DanKeTools.IO
{

    ///<summary>
    ///脚本名称： FileManager.cs
    ///修改时间：2023/1/11
    ///脚本功能：文件管理器
    ///备注：
    ///</summary>

    public class FileManager : Node
    {
        /// <summary>
        /// 写入文本文件
        /// </summary>
        /// <param name="pathName">文件</param>
        /// <param name="info">内容</param>
        public static void Write(string pathName, string info)
        {
            StreamWriter sw;
            FileInfo fi = new FileInfo(pathName);
            sw = fi.CreateText();
            sw.WriteLine(info);
            sw.Close();
            sw.Dispose();
        }

        /// <summary>
        /// 读取文本文件
        /// </summary>
        /// <param name="pathName">文件</param>
        /// <returns></returns>
        public static string Read(string pathName)
        {
            StreamReader sr;
            FileInfo fi = new FileInfo(pathName);
            sr = fi.OpenText();
            string info = sr.ReadToEnd();
            sr.Close();
            sr.Dispose();
            return info;
        }
        
        /// <summary>
        /// 同步加载资源
        /// </summary>
        /// <param name="name"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Load<T>(string name) where T : Resource
        {
            T res = (T)GD.Load("res://"+name);
            return res;
        }
        
        /// <summary>
        /// 异步加载资源
        /// </summary>
        /// <param name="name"></param>
        /// <param name="callback"></param>
        /// <typeparam name="T"></typeparam>
        public void LoadAsync<T>(string name, Action<T> callback) where T : Resource
        {
            //开启异步加载的协程
            var monoManager = GetNode<MonoManager>("/root/MonoManager");
            monoManager.StartCoroutine(ReallyLoadAsync<T>(name, callback));
        }
        private IEnumerator ReallyLoadAsync<T>(string name, Action<T> callback) where T : Resource
        {
            T res = (T)GD.Load("res://"+name);
            yield return res;
            callback(res);
        }  
        
        /// <summary>
        /// 加载Texture
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Texture LoadTexture(string path)
        {
            var res = (Texture)GD.Load("res://"+path);
            return res;
        }

        /// <summary>
        /// 加载Script
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Script LoadScript(string path)
        {
            var res = (Script)GD.Load("res://"+path);
            return res;
        }
        
        /// <summary>
        /// 加载Mesh
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Mesh LoadMesh(string path)
        {
            var res = (Mesh)GD.Load("res://"+path);
            return res;
        }
        
        /// <summary>
        /// 加载Animation
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Animation LoadAnimation(string path)
        {
            var res = (Animation)GD.Load("res://"+path);
            return res;
        }
        
        /// <summary>
        /// 加载AudioStream
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static AudioStream LoadAudioStream(string path)
        {
            var res = (AudioStream)GD.Load("res://"+path);
            return res;
        }
        
        /// <summary>
        /// 加载Font
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Font LoadFont(string path)
        {
            var res = (Font)GD.Load("res://"+path);
            return res;
        }
        
        /// <summary>
        /// 加载Translation
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static Translation LoadTranslation(string path)
        {
            var res = (Translation)GD.Load("res://"+path);
            return res;
        }
    }

}