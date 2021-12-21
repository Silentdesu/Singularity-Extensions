using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Singularity.Scripts.Utils
{
    public static class SingularityExtensions
    {
        
        /// <summary>
        /// Parse from string to enum
        /// </summary>
        /// <param name="value">parsed string</param>
        private static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
        
        private static System.Random rng = new System.Random();
        // private static UnityEngine.Random uRandom = new UnityEngine.Random();
        /// <summary>
        /// Shuffles list elements
        /// </summary>
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static void Shuffle<T>(this T[] targetArray)
        {
            int n = targetArray.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = targetArray[k];
                targetArray[k] = targetArray[n];
                targetArray[n] = value;
            }
        }
        
        public static T GetRandomElement<T>(this IList<T> list)
        {
            return list[rng.Next(list.Count)];
        }

        public static void AddListener(this Action targetAction, Action newAction)
        {
            targetAction += newAction;
        }

        public static void RemoveListener(this Action targetAction, Action newAction)
        {
            targetAction -= newAction;
        }
        
        public static void AddListener<T>(this Action<T> targetAction, Action<T> newAction)
        {
            targetAction += newAction;
        }

        public static void RemoveListener<T>(this Action<T> targetAction, Action<T> newAction)
        {
            targetAction -= newAction;
        }

        public static void SetTexture(this Image image, Texture texture, bool preserveAspect = false)
        {
            Rect newRect = new Rect(0.0f,0.0f,texture.width,texture.height);
            Vector2 pivot = new Vector2(0.5f,0.5f); 
            
            image.sprite = Sprite.Create((Texture2D)texture, newRect, pivot, 100.0f);
            image.preserveAspect = preserveAspect;
        }
        
        public static void DestroyAllChildren(this Transform parent)
        {
            foreach (Transform child in parent)
            {
                UnityEngine.Object.Destroy(child.gameObject);
            }
        }

        //Clear Array
        public static void Clear<T>(this T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = default(T);
            }
        }

        /// <summary>
        /// No allocation GetComponent
        /// </summary>
        private static List<Component> m_ComponentCache = new List<Component>();

        public static T GetComponentNoAlloc<T>(this GameObject @this) where T : Component
        {
            @this.GetComponents(typeof(T), m_ComponentCache);
            var component = m_ComponentCache.Count > 0 ? m_ComponentCache[0] : null;
            m_ComponentCache.Clear();
            return component as T;
        }

        public static Vector2 GetPositionOnScreen(this RectTransform rect,Camera camera = null)
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
            if (Mathf.Abs(distance) <= threshold) return true;
            return false;
        }

        public static Material SetMaterialInstance(this MeshRenderer[] meshRenderers)
        {
            var materialInstance = meshRenderers[0].material;

            foreach (MeshRenderer meshRenderer in meshRenderers)
            {
                meshRenderer.sharedMaterial = materialInstance;
            }

            return materialInstance;
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

        public static string ToBigNumberString(this long number)
        {
            if (number < 1000)
            {
                return number.ToString();
            }
            else if (number > 1000 && number < 10000)
            {
                return String.Format("{0:n}K", number / 1000.0f);
            }
            else if (number < 1000000)
            {
                return string.Format("{0:0.0}K", number / 1000.0f);
            }
            else if (number < 1000000000)
            {
                return string.Format("{0:0.0}M", number / 1000000.0f);
            }
            else
            {
                return string.Format("{0:0.0}B", number / 1000000000.0f);
            }
        }
        
        public static string ToBigNumberString(this double number)
        {
            if (number < 1000)
            {
                return number.ToString();
            }
            else if (number > 1000 && number < 10000)
            {
                return String.Format("{0:n}K", number / 1000.0f);
            }
            else if (number < 1000000)
            {
                return string.Format("{0:0.0}K", number / 1000.0f);
            }
            else if (number < 1000000000)
            {
                return string.Format("{0:0.0}M", number / 1000000.0f);
            }
            else
            {
                return string.Format("{0:0.0}B", number / 1000000000.0f);
            }
        }

        public static string AddSuffixString(this double seconds)
        {
            return string.Format("{0:0.0}s", seconds);
        }
    }
}
