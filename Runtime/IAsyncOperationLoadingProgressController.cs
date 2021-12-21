using System.Collections;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Singularity.Scripts.Utils
{
    public interface IAsyncOperationLoadingProgressController
    {
        IEnumerator ShowProgress(AsyncOperationHandle operation);

        IEnumerator ShowProgress(AsyncOperation operation);
    }
}