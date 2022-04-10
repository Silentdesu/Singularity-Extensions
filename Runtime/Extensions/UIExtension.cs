using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SingularityLab.Runtime.Extensions
{
    public static partial class UIExtension
    {
        public static bool IsPointerOverUIObject(in float x, in float y)
        {
            var eventDataCurrentPosition = new PointerEventData(EventSystem.current)
            {
                position = new Vector2(x, y)
            };

            var results = new List<RaycastResult>();

            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

            return results.Count > 0;
        }

        public static void DisableGroup(this CanvasGroup canvasGroup)
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }

        public static void EnableGroup(this CanvasGroup canvasGroup)
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
    }
}