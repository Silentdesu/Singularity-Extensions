using SingularityLab.Scripts.Utils;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Singularity.Scripts.Utils
{
    [DefaultExecutionOrder(-100)]
    public class BaseInstance<T> : SerializedMonoBehaviour where T : MonoBehaviour
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
