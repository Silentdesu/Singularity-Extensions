using UnityEngine;

namespace SingularityLab.Runtime.Extensions
{
    public static partial class DebugExtension
    {
        public static void DrawDebugCube(in Vector3 origin, in Vector3 center, in Vector3 extends, in Color color)
        {
            var v3FrontTopLeft = new Vector3(center.x - extends.x, center.y + extends.y, center.z - extends.z); // Front top left corner
            var v3FrontTopRight = new Vector3(center.x + extends.x, center.y + extends.y, center.z - extends.z); // Front top right corner
            var v3FrontBottomLeft = new Vector3(center.x - extends.x, center.y - extends.y, center.z - extends.z); // Front bottom left corner
            var v3FrontBottomRight = new Vector3(center.x + extends.x, center.y - extends.y, center.z - extends.z); // Front bottom right corner
            var v3BackTopLeft = new Vector3(center.x - extends.x, center.y + extends.y, center.z + extends.z); // Back top left corner
            var v3BackTopRight = new Vector3(center.x + extends.x, center.y + extends.y, center.z + extends.z); // Back top right corner
            var v3BackBottomLeft = new Vector3(center.x - extends.x, center.y - extends.y, center.z + extends.z); // Back bottom left corner
            var v3BackBottomRight = new Vector3(center.x + extends.x, center.y - extends.y, center.z + extends.z); // Back bottom right corner

            v3FrontTopLeft += origin;
            v3FrontTopRight += origin;
            v3FrontBottomLeft += origin;
            v3FrontBottomRight += origin;
            v3BackTopLeft += origin;
            v3BackTopRight += origin;
            v3BackBottomLeft += origin;
            v3BackBottomRight += origin;

            Debug.DrawLine(v3FrontTopLeft, v3FrontTopRight, color);
            Debug.DrawLine(v3FrontTopRight, v3FrontBottomRight, color);
            Debug.DrawLine(v3FrontBottomRight, v3FrontBottomLeft, color);
            Debug.DrawLine(v3FrontBottomLeft, v3FrontTopLeft, color);

            Debug.DrawLine(v3BackTopLeft, v3BackTopRight, color);
            Debug.DrawLine(v3BackTopRight, v3BackBottomRight, color);
            Debug.DrawLine(v3BackBottomRight, v3BackBottomLeft, color);
            Debug.DrawLine(v3BackBottomLeft, v3BackTopLeft, color);

            Debug.DrawLine(v3FrontTopLeft, v3BackTopLeft, color);
            Debug.DrawLine(v3FrontTopRight, v3BackTopRight, color);
            Debug.DrawLine(v3FrontBottomRight, v3BackBottomRight, color);
            Debug.DrawLine(v3FrontBottomLeft, v3BackBottomLeft, color);
        }
    }
}