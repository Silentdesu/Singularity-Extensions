using System.Collections;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Singularity.Scripts.Utils
{
    public class LoadingProgressBar : IAsyncOperationLoadingProgressController
    {
        public IEnumerator ShowProgress(AsyncOperationHandle operation)
        {
            while (!operation.GetDownloadStatus().IsDone || operation.Status == AsyncOperationStatus.Failed)
            {
                var downloadStatus = operation.GetDownloadStatus();
                LoadingProgressController.Instance.SetProgress(Mathf.Min(operation.PercentComplete, 0.9f));
                Debug.Log(Mathf.Min(operation.PercentComplete, 0.9f));
                yield return null;
            }
            Debug.Log("Download completed");
        }
        
        
        public IEnumerator ShowProgress(AsyncOperation operation)
        {
            while (!operation.isDone)
            {
                LoadingProgressController.Instance.SetProgress(Mathf.Min(operation.progress, 0.9f));
                Debug.Log(Mathf.Min(operation.progress, 0.9f));

                yield return null;
            }

            Debug.Log("Download completed");
        }
    }
}