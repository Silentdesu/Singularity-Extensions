using UnityEngine;

namespace SingularityLab.Runtime.Tools
{
    public class MainThreadRunner : MonoBehaviour
    {
        private static MainThreadRunner _instance;

        public static MainThreadRunner Instance
        {
            get
            {
                if (_instance == null)
                {
                    var obj = new GameObject("MainThreadRunner");
                    _instance = obj.AddComponent<MainThreadRunner>();
                    return _instance;
                }

                return _instance;
            }
        }
    }
}