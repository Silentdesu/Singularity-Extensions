using UnityEngine;

namespace SingularityLab.Runtime.Extensions
{
    public static partial class VectorExtension
    {
        public static Vector2 GetPositionOnScreen(this RectTransform rect, Camera camera = null)
        {
            return RectTransformUtility.WorldToScreenPoint(camera, rect.position);
        }

        public static Vector3 GetRandomPointInBounds(this Bounds bounds)
        {
            return new Vector3(
                UnityEngine.Random.Range(bounds.min.x, bounds.max.x),
                UnityEngine.Random.Range(bounds.min.y, bounds.max.y),
                UnityEngine.Random.Range(bounds.min.z, bounds.max.z)
            );
        }

        public static bool IsEqual(this Vector3 originPos, Vector3 pos, float threshold = 0.1f)
        {
            var distance = Vector3.Distance(originPos, pos);
            
            return Mathf.Abs(distance) <= threshold;
        }
    }
}