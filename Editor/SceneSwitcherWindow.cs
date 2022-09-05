using SingularityLab.Runtime.Scenes;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SingularityLab.Editor
{
    public class SceneSwitcherWindow : EditorWindow
    {
        public string DevFolderName;
        private List<string> _scenesPaths;
        private Vector2 _scrollPos;

        private const string _projectScenes = "_Project/_Scenes";

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

        /// <summary>
        ///     Path should be hardcoded as '_Main/_Scenes'
        ///     or you can your own path.
        /// </summary>
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
            _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos, GUILayout.Width(Screen.width), GUILayout.Height(Screen.height / 2));
            {
                foreach (string scenesPath in _scenesPaths)
                {
                    if (!scenesPath.Contains(_projectScenes, System.StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    var scene = GetSceneName(scenesPath);
                    AddButton(new SceneButtonParams(scene, scenesPath));
                }
            }
            EditorGUILayout.EndScrollView();
            EditorGUILayout.EndVertical();
        }

        private void AddButton(in SceneButtonParams sceneButtonParams)
        {
            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button(sceneButtonParams.Name.ToString()) && EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                EditorSceneManager.OpenScene(sceneButtonParams.Path.ToString());
            }

            if (GUILayout.Button("L", GUILayout.Width(20)))
            {
                var obj = AssetDatabase.LoadAssetAtPath(sceneButtonParams.Path.ToString(), typeof(SceneAsset));
                EditorGUIUtility.PingObject(obj);
            }

            EditorGUILayout.EndHorizontal();
        }

        private string GetSceneName(in string scenePath)
        {
            var splitedScene = scenePath.Split('/');

            return splitedScene[splitedScene.Length - 1].Split('.')[0];
        }
    }
}