/*
 * File Name:               FileHandler.cs
 *
 * Description:             脚本创建辅助工具
 * Author:                  lisiyu <576603306@qq.com>
 * Create Date:             2016/04/26
 */

using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace UnityEditor.ScriptCreator
{
    /// <summary>
    /// 可扩展编写的编辑器脚本 
    /// </summary>
    public class ScriptHandler
    {
        [MenuItem("Assets/CreateScript/Tester", false, 10)]
        private static void createCommonScript()
        {
            ScriptCreator.create("#1 Tester");
        }

        //Author 创建脚本的用户名称
        private static string AutorName = "yuhaoyu <158521902@qq.com>";
        private static string PathAutorNameFile = Application.dataPath + "/../AuthorName.ini";

        public static Dictionary<string, string> getReplaceInfos(string pathName)
        {
            if (File.Exists(PathAutorNameFile))
            {
                AutorName = File.ReadAllText(PathAutorNameFile);
            }
            else
            {
                var sw = File.CreateText(PathAutorNameFile);
                sw.WriteLine(AutorName);
                sw.Close();

                EditorUtility.DisplayDialog("提示", string.Format("请到路径 {0} 下填写自己的用户名称! ", PathAutorNameFile), "确定");
            }

            var ret = new Dictionary<string, string>();
            ret.Add("#FILENAME#", Path.GetFileName(pathName));
            ret.Add("#AUTHORNAME#", AutorName);
            ret.Add("#DATE#", System.DateTime.Today.ToString("yyyy/MM/dd"));
            ret.Add("#CLASSNAME#", Path.GetFileNameWithoutExtension(pathName));

            return ret;
        }
    }
}