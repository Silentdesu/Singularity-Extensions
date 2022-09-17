using UnityEngine;

namespace SingularityLab.Runtime.Singletons
{
    [DefaultExecutionOrder(-500)]
    public abstract class BaseInstanceDontDestroy<T> : BaseInstance<T> where T : MonoBehaviour
    {
        protected override void Awake()
        {
            base.Awake();
            transform.SetParent(null);
            DontDestroyOnLoad(this);
        }
    }
}
