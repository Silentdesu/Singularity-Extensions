using SingularityLab.Runtime.Tools;
using Sirenix.OdinInspector;
using UnityEngine;

namespace SingularityLab.Runtime.Singletons
{
    [DefaultExecutionOrder(-100)]
    public abstract class BaseInstance<T> : SerializedMonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = (T) FindObjectOfType(typeof(T));
                    
                    if (_instance == null)
                    {
                        DebugX.Warning($"{typeof(T).FullName} Instance NOT READY!");
                    }
                }

                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if (_instance != null)
            {
                DebugX.Warning($"{typeof(T).FullName} - Duplicate Instance destroyed!");
                Destroy(this.gameObject);
                return;
            }
            
            _instance = this as T;
            
            DebugX.Success($"{typeof(T).FullName} Instance Ready!");
        }
    }
}
