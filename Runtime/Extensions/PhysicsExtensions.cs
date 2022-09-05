using UnityEngine;

namespace SingularityLab.Runtime.Extensions
{
    public static class PhysicsExtensions
    {
        public static bool IsRayHit(in Ray ray, out RaycastHit hitInfo, in float distance, in LayerMask layer)
        {
            return Physics.Raycast(ray, out hitInfo, distance, layer);
        }
        
        public static bool IsRayHit(in Ray ray, in float distance, in LayerMask layer)
        {
            return Physics.Raycast(ray, distance, layer);
        }

        public static bool IsRaycastHit(in Vector3 startPos, in Vector3 direction, out RaycastHit hitInfo, in float distance, in LayerMask layer)
        {
            return Physics.Raycast(startPos, direction, out hitInfo, distance, layer);
        }
        
        public static bool IsRaycastHit(in Vector3 startPos, in Vector3 direction, in float distance, in LayerMask layer)
        {
            return Physics.Raycast(startPos, direction, distance, layer);
        }
    }
}
