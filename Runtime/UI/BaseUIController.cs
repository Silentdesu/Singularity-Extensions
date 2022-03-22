using SingularityLab.Runtime.Singletons;
using UnityEngine;

namespace SingularityLab.Runtime.UI
{
    public class BaseUIController<T> : BaseInstance<T> where T : MonoBehaviour
    {
        [SerializeField] private Canvas _rootCanvas;

        public Canvas RootCanvas
        {
            get
            {
                if (!_rootCanvas) return GetComponentInParent<Canvas>();

                return _rootCanvas;
            }
        }

        public Transform RootTransform => RootCanvas.transform;

    }

}