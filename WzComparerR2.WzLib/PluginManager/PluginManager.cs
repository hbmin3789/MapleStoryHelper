using System;
using System.Collections.Generic;
using WzComparerR2.WzLib;
using System.IO;

namespace WzComparerR2.PluginBase
{
    public class PluginManager
    {
        /// <summary>
        /// 当执行FindWz函数时发生，用来寻找对应的Wz_File。
        /// </summary>
        internal static event FindWzEventHandler WzFileFinding;

        /// <summary>
        /// 为CharaSim组件提供全局的搜索Wz_File的方法。
        /// </summary>
        /// <param Name="Type">要搜索wz文件的Wz_Type。</param>
        /// <returns></returns>
        public static Wz_Node FindWz(Wz_Type type)
        {
            return FindWz(type, null);
        }

        public static Wz_Node FindWz(Wz_Type type, Wz_File sourceWzFile)
        {
            FindWzEventArgs e = new FindWzEventArgs(type) { WzFile = sourceWzFile };
            if (WzFileFinding != null)
            {
                WzFileFinding(null, e);
                if (e.WzNode != null)
                {
                    return e.WzNode;
                }
                if (e.WzFile != null)
                {
                    return e.WzFile.Node;
                }
            }
            return null;
        }

        /// <summary>
        /// 通过wz完整路径查找对应的Wz_Node，若没有找到则返回null。
        /// </summary>
        /// <param name="fullPath">要查找节点的完整路径，可用'/'或者'\'作分隔符，如"Mob/8144006.img/die1/6"。</param>
        /// <returns></returns>
        public static Wz_Node FindWz(string fullPath)
        {
            FindWzEventArgs e = new FindWzEventArgs() { FullPath = fullPath };
            if (WzFileFinding != null)
            {
                WzFileFinding(null, e);
                if (e.WzNode != null)
                {
                    return e.WzNode;
                }
                if (e.WzFile != null)
                {
                    return e.WzFile.Node;
                }
            }
            return null;
        }

        internal static string MainExecutorPath
        {
            get
            {
                var asmArray = AppDomain.CurrentDomain.GetAssemblies();
                foreach (var asm in asmArray)
                {
                    string asmName = asm.GetName().Name;
                    if (string.Equals(asmName, "WzComparerR2", StringComparison.CurrentCultureIgnoreCase))
                    {
                        return asm.Location;
                    }
                }
                return "";
            }
        }

        internal static string[] GetPluginFiles()
        {
            List<string> fileList = new List<string>();
            string baseDir = Path.GetDirectoryName(MainExecutorPath);
            string pluginDir = Path.Combine(baseDir, "Plugin");
            if (Directory.Exists(pluginDir))
            {
                foreach (string file in Directory.GetFiles(pluginDir, "WzComparerR2.*.dll", SearchOption.AllDirectories))
                {
                    fileList.Add(file);
                }
            }
            else
            {
                Directory.CreateDirectory(pluginDir);
            }
            return fileList.ToArray();
        }
    }
}
