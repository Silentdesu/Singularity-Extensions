using System.Collections;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace SingularityLab.Runtime.UI
{
    public interface IAsyncOperationLoadingProgressController
    {
        IEnumerator ShowProgress(AsyncOperationHandle operation);

        IEnumerator ShowProgress(AsyncOperation operation);
    }
}