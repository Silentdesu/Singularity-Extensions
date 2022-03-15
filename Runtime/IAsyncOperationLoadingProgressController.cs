using System.Collections;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace SingularityLab.Runtime
{
    public interface IAsyncOperationLoadingProgressController
    {
        IEnumerator ShowProgress(AsyncOperationHandle operation);

        IEnumerator ShowProgress(AsyncOperation operation);
    }
}