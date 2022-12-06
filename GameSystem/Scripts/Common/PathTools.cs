using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace MorozovSoftware.GameSystem
{
    public static class PathTools
    {
        public static string DataPath()
        {
            return CorrectSlash(Application.persistentDataPath, Style.System);
        }

#if UNITY_EDITOR
        public static string GetResourcePath(Object prefab)
        {
            return GetRelativePath(AssetDatabase.GetAssetPath(prefab), "Resources", Style.Unity);
        }
#endif

        public static string CorrectSlash(string path, Style style)
        {
            return string.Join(DirectorySeparatorChar(style), path.Split(new char[] { '/', '\\' }));
        }

        public static char DirectorySeparatorChar(Style style)
        {
            return style == Style.System ? Path.DirectorySeparatorChar : '/';
        }

        public static string GetRelativePath(string fullPath, string relativeFolder, Style style)
        {
            var full = CorrectSlash(fullPath, Style.System);
            var dir = Path.GetDirectoryName(full);


            var relativeDir = new StringBuilder();
            foreach (var str in dir.Split(Path.DirectorySeparatorChar))
            {
                relativeDir.Append(str).Append(Path.DirectorySeparatorChar);
                if (str == relativeFolder)
                {
                    relativeDir.Clear();
                }
            }

            return CorrectSlash(Path.Combine(relativeDir.ToString(), Path.GetFileNameWithoutExtension(full)), style);
        }

        public enum Style
        {
            System,
            Unity
        }
    }
}
