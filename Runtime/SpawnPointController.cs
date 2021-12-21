using Sirenix.OdinInspector;
using UnityEngine;

namespace Singularity.Scripts.Utils
{
    [ExecuteAlways]
    public class SpawnPointController : MonoBehaviour
    {
        [BoxGroup("Settings"), SerializeField] private Color _color = Color.red;
        [BoxGroup("Settings"), SerializeField] private float _radius = .5f;
        
        public Transform CachedTransform { get; private set; }

        private void Awake()
        {
            CachedTransform = transform;
        }
        

        private void OnDrawGizmos()
        {
            Gizmos.color = _color;
            Gizmos.DrawWireSphere(CachedTransform.position, _radius);
        }
    }
}