using UnityEngine;

namespace Singularity.Scripts.Utils
{
    public class BaseCastedInstance<TBase> : BaseInstance<TBase> where TBase : MonoBehaviour
    {
        public static T CastedInstance<T>() where T : TBase
        {
            return (T) Instance;
        }
    }
}