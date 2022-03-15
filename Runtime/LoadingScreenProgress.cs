using System.Collections;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace SingularityLab.Runtime
{
    public class LoadingScreenProgress : IAsyncOperationLoadingProgressController
    {
        public IEnumerator ShowProgress(AsyncOperationHandle operationHandle)
        {
            while (!operationHandle.GetDownloadStatus().IsDone || operationHandle.Status == AsyncOperationStatus.Failed)
            {
                var downloadStatus = operationHandle.GetDownloadStatus();
                LoadingScreenController.SetText(
                    $"Loaded: {(operationHandle.PercentComplete * 100).ToString("0")}%");
                yield return null;
            }

            Debug.Log("Download completed");
        }

        public IEnumerator ShowProgress(AsyncOperation operation)
        {
            while (!operation.isDone)
            {
                LoadingScreenController.SetText(
                    $"Loaded: {(operation.progress * 100).ToString("0")}%");
                yield return null;
            }

            Debug.Log("Download completed");
        }
    }
}