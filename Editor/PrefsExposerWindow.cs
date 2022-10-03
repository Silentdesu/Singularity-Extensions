using SingularityLab.Runtime.Tools;
using System;
using UnityEditor;
using UnityEngine;

namespace SingularityLab.Editor
{
    public sealed class PrefsExposerWindow : EditorWindow
    {
        private Vector2 _scrollPosition;

        [MenuItem("Tools/PrefsExposer")]
        private static void ShowWindow()
        {
            var window = GetWindow<PrefsExposerWindow>();
            window.titleContent = new GUIContent("Prefs Exposer");
            if (Application.isPlaying)
                window.Show();
            else
            {
                window.Close();
                EditorUtility.DisplayDialog("Warning!", "Prefs Exposer only works in play mode!", "OK");
            }
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginScrollView(_scrollPosition, GUILayout.Width(position.width), GUILayout.Height(position.height));

            if (PrefsCenter.Prefs.Count == 0)
            {
                EditorGUILayout.LabelField("Prefs are empty!");
            }

            for (int i = 0; i < PrefsCenter.Prefs.Count; i++)
            {
                string prefKey = PrefsCenter.Prefs[i];

                if (PlayerPrefs.GetFloat(prefKey) != default)
                    EditorGUILayout.LabelField(prefKey, PlayerPrefs.GetFloat(prefKey).ToString());
                else if (PlayerPrefs.GetInt(prefKey) != default)
                    EditorGUILayout.LabelField(prefKey, PlayerPrefs.GetInt(prefKey).ToString());
                else if (PlayerPrefs.GetString(prefKey) != default)
                {
                    string key = PlayerPrefs.GetString(prefKey);
                    EditorGUILayout.LabelField(prefKey, String.IsNullOrEmpty(key) ? "#bug" : key);
                }
                
                if (PlayerPrefsX.GetLong(prefKey) != default)
                    EditorGUILayout.LabelField(prefKey, PlayerPrefsX.GetLong(prefKey).ToString());
                else if (PlayerPrefsX.GetVector2(prefKey, Vector2.zero) != default)
                    EditorGUILayout.LabelField(prefKey, PlayerPrefsX.GetVector2(prefKey, Vector2.zero).ToString());
                else if (PlayerPrefsX.GetVector3(prefKey, Vector3.zero) != default)
                    EditorGUILayout.LabelField(prefKey, PlayerPrefsX.GetVector3(prefKey, Vector3.zero).ToString());
            }

            EditorGUILayout.EndScrollView();
        }
    }
}
