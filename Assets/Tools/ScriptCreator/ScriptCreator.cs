/*
 * File Name:               ScriptCreator.cs
 *
 * Description:             脚本创建辅助工具
 * Author:                  lisiyu <576603306@qq.com>
 * Create Date:             2016/04/26
 */

using System.IO;
using System.Text;
using UnityEngine;

namespace UnityEditor.ScriptCreator
{
    /// <summary>
    /// 通用接口序列化模板 
    /// </summary>
    public class ScriptCreator : ProjectWindowCallback.EndNameEditAction
    {
        private const string DefaultName = "NewScript.cs";                      // 默认文件名

        private static Texture2D DefaultTexture
        {
            get
            {
                var tmp = EditorGUIUtility.IconContent("cs Script Icon");
                return tmp.image as Texture2D;
            }
        }                              // 默认图标

        private readonly Encoding EncodingType = new UTF8Encoding(true);       // 默认编码

        /// <summary>
        /// 外部调用 
        /// </summary>
        /// <param name="tmplateName">   </param>
        /// <param name="defaultName">   </param>
        /// <param name="defaultTexture"></param>
        public static void create(string tmplateName, string defaultName = "", Texture2D defaultTexture = null)
        {
            if (string.IsNullOrEmpty(defaultName))
                defaultName = DefaultName;
            if (defaultTexture == null)
                defaultTexture = DefaultTexture;

            var txt = Resources.Load<TextAsset>(tmplateName);
            if (txt == null)
            {
                Debug.LogError("找不到对应的模板文件：" + tmplateName);
                return;
            }

            createFile(AssetDatabase.GetAssetPath(txt), defaultName, defaultTexture);
        }

        /// <summary>
        /// 内部调用 
        /// </summary>
        /// <param name="templatePath"></param>
        /// <param name="fileName">    </param>
        /// <param name="tx2d">        </param>
        private static void createFile(string templatePath, string defaultName = "", Texture2D defaultTexture = null)
        {
            ProjectWindowUtil.StartNameEditingIfProjectWindowExists(
                0,
                ScriptableObject.CreateInstance<ScriptCreator>(),
                defaultName,
                defaultTexture,
                templatePath
                );
        }

        /// <summary>
        /// 响应新建文本事件 
        /// </summary>
        /// <param name="instanceId">  </param>
        /// <param name="pathName">    </param>
        /// <param name="resourceFile"></param>
        public override void Action(int instanceId, string pathName, string resourceFile)
        {
            if (!File.Exists(resourceFile))
            {
                Debug.LogError(string.Format("找不到模板文件！\nTemplatePath:{0}\nTargetPath:{1}", resourceFile, pathName));
                return;
            }

            var content = File.ReadAllText(resourceFile);
            var infos = ScriptHandler.getReplaceInfos(pathName);
            foreach (var tmp in infos)
            {
                content = content.Replace(tmp.Key, tmp.Value);
            }
            File.WriteAllText(pathName, content, EncodingType);

            AssetDatabase.Refresh();
        }
    }
}