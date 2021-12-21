using UnityEngine;

namespace Singularity.Scripts.Utils
{
    [DefaultExecutionOrder(-500)]
    public class BaseInstanceDontDestroy<T> : BaseInstance<T> where T : MonoBehaviour
    {
        protected override void Awake()
        {
            base.Awake();
            transform.SetParent(null);
            DontDestroyOnLoad(this);
        }
    }
}
