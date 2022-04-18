using System;
using SingularityLab.Runtime.Tools;
using SingularityLab.Runtime.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SingularityLab.Runtime.Scenes
{
    public sealed class SceneLoaderHandler
    {
        public int CurrentGameplaySceneIndex { get; private set; } = 0;

        private SceneLoadingParams _currentGameplayScene = new SceneLoadingParams();

        public SceneLoaderHandler(GameObject graphyPrefab = null, 
        bool forceShowGraphy = false, bool forceShowGraphyInEditor = false)
        {
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

            Application.targetFrameRate = 60;
            
            var sceneLoadingParams = new SceneLoadingParams();

            sceneLoadingParams.LoadSceneMode = loadSceneMode;
            sceneLoadingParams.SceneName = sceneName;
            
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
            Application.targetFrameRate = 60;

            if (String.IsNullOrEmpty(_currentGameplayScene.SceneName))
            {
                _currentGameplayScene.LoadSceneMode = LoadSceneMode.Single;
                _currentGameplayScene.SceneName = SceneManager.GetActiveScene().name; 
            }
            
            sceneLoader.Load(_currentGameplayScene, () =>
            {
                DebugX.SceneLoaded($"{_currentGameplayScene} has loaded");            
            }, error => { DebugX.Error($"Could not load: {_currentGameplayScene}, {error}");});
        }

        public string GetCurrentSceneName()
        {
            return _currentGameplayScene.SceneName;
        }

    }
}