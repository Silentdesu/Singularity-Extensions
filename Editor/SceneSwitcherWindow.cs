using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Singularity.Scripts.Utils.Editor
{
    public class SceneSwitcherWindow : EditorWindow
    {
         private List<string> _scenesPaths;

        [MenuItem("Tools/Scene Switcher")]
        private static void ShowWindow()
        {
            var window = GetWindow<SceneSwitcherWindow>();
            window.titleContent = new GUIContent("SceneSwitcher");
            window.Show();
        }

        private void OnEnable()
        {
            string[] scenesGUIDs = AssetDatabase.FindAssets("t:Scene");
            _scenesPaths = scenesGUIDs.Select(AssetDatabase.GUIDToAssetPath).ToList();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Reload"))
            {
                OnEnable();
            }
                    
            GUILayout.Label("Reference Scenes");

            // ~~~~EXAMPLE OF HOW TO MAKE A STATIC BUTTON~~~~
            // AddButton(new SceneButtonParams("Button_Name", _scenesPaths.FirstOrDefault(a => a.Contains("Path_Name"))));
            
            // ~~~~TRY YOUR SELF~~~~
            
            GUILayout.Space(15);
            GUILayout.Label("All scenes");
            EditorGUILayout.BeginVertical();
            {
                foreach (string scenesPath in _scenesPaths)
                {
                    if (!scenesPath.Contains("_IdleSiege/_Scenes"))
                    {
                        continue;
                    }

                    var scene = GetSceneName(scenesPath);
                    AddButton(new SceneButtonParams(scene, scenesPath));
                }
            }
            EditorGUILayout.EndVertical();
        }

        private void AddButton(SceneButtonParams sceneButtonParams)
        {
            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button(sceneButtonParams.Name))
            {
                EditorSceneManager.OpenScene(sceneButtonParams.Path);
            }

            if (GUILayout.Button("L", GUILayout.Width(20)))
            {
                var obj = AssetDatabase.LoadAssetAtPath(sceneButtonParams.Path, typeof(SceneAsset));
                EditorGUIUtility.PingObject(obj);
            }

            EditorGUILayout.EndHorizontal();
        }

        private string GetSceneName(string scenePath)
        {
            var splitedScene = scenePath.Split('/');
            
            return splitedScene[splitedScene.Length - 1].Split('.')[0];
        }
    }
}
