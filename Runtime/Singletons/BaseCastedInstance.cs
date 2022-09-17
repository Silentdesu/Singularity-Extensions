using UnityEngine;

namespace SingularityLab.Runtime.Singletons
{
    public abstract class BaseCastedInstance<TBase> : BaseInstance<TBase> where TBase : MonoBehaviour
    {
        public static T CastedInstance<T>() where T : TBase
        {
            return (T) Instance;
        }
    }
}