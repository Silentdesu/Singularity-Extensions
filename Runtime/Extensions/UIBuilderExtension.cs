namespace SingularityLab.Runtime.Extensions
{
    using UnityEngine;
    using UnityEngine.UIElements;
    
    public static class UIBuilderExtension
    {
        /// <summary>
        /// returns the world space position that corresponds to the center of a VisualElement
        /// </summary>
        /// <param name="visualElement"></param>
        /// <param name="camera"></param>
        /// <param name="zDepth"></param>
        /// <returns></returns>
        public static Vector3 GetWorldPosition(this VisualElement visualElement, Camera camera = null, float zDepth = 10f)
        {
            if (camera == null)
                camera = Camera.main;

            Vector3 worldPos = Vector3.zero;

            if (camera == null || visualElement == null)
                return worldPos;

            return visualElement.worldBound.center.ScreenPosToWorldPos(camera, zDepth);
        }

        /// <summary>
        /// converts a screen position from UI Toolkit to world space
        /// </summary>
        /// <param name="screenPos"></param>
        /// <param name="camera"></param>
        /// <param name="zDepth"></param>
        /// <returns></returns>
        public static Vector3 ScreenPosToWorldPos(this Vector2 screenPos, Camera camera = null, float zDepth = 10f)
        {
            if (camera == null)
                camera = Camera.main;

            if (camera == null)
                return Vector2.zero;

            float xPos = screenPos.x;
            float yPos = screenPos.y;
            Vector3 worldPos = Vector3.zero;

            if (!float.IsNaN(screenPos.x) && !float.IsNaN(screenPos.y))
            {
                // flip y-coordinate; in UI Toolkit, (0,0) is top-left instead of bottom-left.
                yPos = camera.pixelHeight - yPos;

                // convert to world space position using Camera class
                Vector3 screenCoord = new Vector3(xPos, yPos, zDepth);
                worldPos = camera.ScreenToWorldPoint(screenCoord);
            }
            return worldPos;
        }
    }
}
