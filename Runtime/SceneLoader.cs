using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace SingularityLab.Runtime
{
    public class SceneLoader
    {
        private readonly IAsyncOperationLoadingProgressController _progressController;

        public SceneLoader(IAsyncOperationLoadingProgressController progressController)
        {
            _progressController = progressController;
        }

        public void Load(SceneLoadingParams loadingParams, Action onComplete, Action<string> onError)
        {
            DebugX.Track("Downloading dependencies");
            
            AsyncOperationHandle handle = Addressables.DownloadDependenciesAsync(loadingParams.SceneName);

            if (LoadingProgressController.Instance != null)
            {
                MainThreadRunner.Instance.StartCoroutine(_progressController.ShowProgress(handle));
            }

            handle.Completed += h =>
            {
                if (!h.IsValid())
                {
                    DebugX.Error($"Not valid dependencies when loading: {loadingParams.SceneName}");
                    return;
                }

                DebugX.Success("Downloaded dependencies");
                var loadOperation = Addressables.LoadSceneAsync(loadingParams.SceneName, loadingParams.LoadSceneMode);

                loadOperation.Completed += (handle) => { OnComplete(handle, onComplete, onError); };

                if (LoadingProgressController.Instance != null)
                {
                    MainThreadRunner.Instance.StartCoroutine(_progressController.ShowProgress(loadOperation));
                }
            };
        }

        private void OnComplete(AsyncOperationHandle<SceneInstance> handle, Action onComplete, Action<string> onError)
        {
            if (!handle.IsValid() || !handle.IsDone)
            {
                Debug.LogError(handle.OperationException);
                onError.Invoke(handle.OperationException.ToString());
                return;
            }

            var scene = handle.Result;

            scene.ActivateAsync().completed += operation => { onComplete.Invoke(); };
        }
    }
}