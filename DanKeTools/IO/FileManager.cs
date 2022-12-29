using System.Collections;
using System.Collections.Generic;
using System.IO;
using Godot;
using System;
using DanKeTools;


namespace DanKeTools.IO
{
    
    ///<summary>
    ///脚本名称： FileManager.cs
    ///修改时间：2022/12/29
    ///脚本功能：
    ///备注：
    ///</summary>

    public class FileManager : Singleton<FileManager>
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
        
        
        
        
    }
    
}