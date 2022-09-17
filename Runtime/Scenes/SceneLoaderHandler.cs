using SingularityLab.Runtime.Tools;
using SingularityLab.Runtime.UI;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SingularityLab.Runtime.Scenes
{
    public struct SceneLoaderHandler
    {
        public int CurrentGameplaySceneIndex;

        private SceneLoadingParams _currentGameplayScene;

        public SceneLoaderHandler(in SceneLoadingParams sceneLoadingParams, in GameObject graphyPrefab = null, 
        bool forceShowGraphy = false, bool forceShowGraphyInEditor = false)
        {
            CurrentGameplaySceneIndex = 0;

            _currentGameplayScene = new SceneLoadingParams()
            {
                SceneName = sceneLoadingParams.SceneName,
                LoadSceneMode = sceneLoadingParams.LoadSceneMode,
            };

            if ((!Application.isEditor && (Debug.isDebugBuild || forceShowGraphy)) 
                || (Application.isEditor && forceShowGraphyInEditor))
            {
                if (!ReferenceEquals(graphyPrefab, null))
                {
                    UnityEngine.Object.Instantiate(graphyPrefab);
                }
            }
        }

        public void LoadSceneByName(string sceneName, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
        {
            var sceneLoader = new SceneLoader(new LoadingProgressBar());
            
            var sceneLoadingParams = new SceneLoadingParams()
            {
                SceneName = sceneName,
                LoadSceneMode = loadSceneMode
            };

            _currentGameplayScene = sceneLoadingParams;
            
            sceneLoader.Load(sceneLoadingParams,
                () =>
                {
                    DebugX.SceneLoaded($"{sceneName} has loaded");
                },
                error => { DebugX.Error($"Could not load: {sceneLoadingParams.SceneName}, {error}");});
        }

        public void LoadCurrentScene()
        {
            var sceneLoader = new SceneLoader(new LoadingProgressBar());

            if (String.IsNullOrEmpty(_currentGameplayScene.SceneName))
            {
                _currentGameplayScene.LoadSceneMode = LoadSceneMode.Single;
                _currentGameplayScene.SceneName = SceneManager.GetActiveScene().name; 
            }
            
            sceneLoader.Load(_currentGameplayScene, OnSceneLoadComplete, OnSceneLoadFailed);
        }

        public string GetCurrentSceneName()
        {
            return _currentGameplayScene.SceneName;
        }

        private void OnSceneLoadComplete()
        {
            DebugX.SceneLoaded($"{_currentGameplayScene} has loaded");
        }

        private void OnSceneLoadFailed(string error)
        {
            DebugX.Error($"Could not load: {_currentGameplayScene}, {error}");
        }
    }
}