using System.Collections.Generic;
using UnityEngine;

namespace SingularityLab.Runtime.Extensions
{
    public static partial class GameObjectExtension
    {
        /// <summary>
        /// No allocation GetComponent.
        /// </summary>
        private static List<Component> m_ComponentCache = new List<Component>();

        public static T GetComponentNoAlloc<T>(this GameObject @this) where T : Component
        {
            @this.GetComponents(typeof(T), m_ComponentCache);
            var component = m_ComponentCache.Count > 0 ? m_ComponentCache[0] : null;
            m_ComponentCache.Clear();
            return component as T;
        }

        public static T GetComponentInChildNoAlloc<T>(this GameObject @this) where T : Component
        {
            @this.GetComponents(typeof(T), m_ComponentCache);
            var component = m_ComponentCache.Count > 0 ? m_ComponentCache[0] : null;
            m_ComponentCache.Clear();

            return component as T;
        }

        /// <summary>
        /// Assign Layer to all child gameObjects.
        /// </summary>
        public static void SetLayerRecursively(this GameObject obj, int newLayer)
        {
            if (obj == null)
            {
                return;
            }

            obj.layer = newLayer;

            foreach (Transform child in obj.transform)
            {
                if (child == null)
                {
                    continue;
                }

                SetLayerRecursively(child.gameObject, newLayer);
            }
        }

        public static List<Transform> GetAllChilds(this Transform parent)
        {
            List<Transform> tempList = new List<Transform>();

            foreach (Transform child in parent)
                tempList.Add(child);

            return tempList;
        }

        public static List<T> GetChildsByType<T>(this Transform parent)
        {
            List<T> tempList = new List<T>();

            foreach (Transform child in parent)
                if (child.TryGetComponent(out T component))
                    tempList.Add(component);

            return tempList;
        }

        public static void DestroyAllChildren(this Transform parent)
        {
            foreach (Transform child in parent)
            {
                Object.Destroy(child.gameObject);
            }
        }
    }
}