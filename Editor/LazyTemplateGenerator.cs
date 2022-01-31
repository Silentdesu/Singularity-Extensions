#if UNITY_EDITOR

using System.IO;
using UnityEditor;
using UnityEngine;

namespace Singularity.Scripts.Utils.Editor
{
    sealed class LazyTemplateGenerator : ScriptableObject
    {
        [MenuItem("Assets/Create/LazyTemplate", false, -200)]
        private static void CreateLazyTemplate () 
        {
            var assetPath = GetAssetPath();
            
            CreateEmptyFolder($"{assetPath}/_Scenes");
            CreateEmptyFolder($"{assetPath}/Prefabs");
            CreateEmptyFolder($"{assetPath}/Materials");
            CreateEmptyFolder($"{assetPath}/Scripts");
            
            AssetDatabase.Refresh();
        }

        private static string GetAssetPath() 
        {
            var path = AssetDatabase.GetAssetPath(Selection.activeObject);
            
            if (!string.IsNullOrEmpty(path) && AssetDatabase.Contains(Selection.activeObject)) 
            {
                if (!AssetDatabase.IsValidFolder(path)) 
                {
                    path = Path.GetDirectoryName(path);
                }
            } 
            else 
            {
                path = "Assets";
            }
            
            return path;
        }

        private static void CreateEmptyFolder(string folderPath) 
        {
            if (!Directory.Exists(folderPath)) 
            {
                try 
                {
                    Directory.CreateDirectory(folderPath);
                } 
                catch 
                {
                    // 
                }
            }
        }
    }
}

#endif
