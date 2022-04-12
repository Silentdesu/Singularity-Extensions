using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SingularityLab.Runtime.Extensions
{
    public static partial class GameObjectExtension
    {
        /// <summary>
        /// No allocation GetComponent.
        /// </summary>
        private static List<Component> _componentsCached = new List<Component>();

        public static T GetComponentNoAlloc<T>(this Transform @this, in bool clearCache = false) where T : Component
        {
            if (!clearCache)
            {
                foreach (var cachedComponent in _componentsCached)
                    if (cachedComponent is T)
                        return cachedComponent as T;
            }

            @this.GetComponents(typeof(T), _componentsCached);
            var component = _componentsCached.Count > 0 ? _componentsCached[0] : null;
            
            if (clearCache)
                _componentsCached.Clear();
            
            return component as T;
        }

        /// <summary>
        /// Assign Layer to all child gameObjects.
        /// </summary>
        public static void SetLayerRecursively(this GameObject obj, in int newLayer)
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

        public static List<Transform> GetAllChilds(this Transform @this)
        {
            List<Transform> tempList = new List<Transform>();

            foreach (Transform child in @this)
                tempList.Add(child);

            return tempList;
        }

        private static List<Component> _childsCached = new List<Component>();

        /// <summary>
        /// Return cached gameobject with a specific type.
        /// </summary>
        /// <typeparam name="T">Type of component that's should be in gameobject</typeparam>
        /// <param name="this"></param>
        /// <param name="clearCache">if it's true then it will clear cache to refill with a new List</param>
        /// <returns></returns>
        public static List<T> GetChildsByTypeNoAlloc<T>(this GameObject @this, out List<T> outputList, in bool clearCache = false) where T : Component
        {
            outputList = new List<T>();

            if (clearCache)
                _childsCached.Clear();

            if (_childsCached.Count != 0)
            {
                for (var i = 0; i < _childsCached.Count; i++)
                {
                    if (!_childsCached[i].TryGetComponent(out T component))
                    {
                        _childsCached.Remove(_childsCached[i]);
                        continue;
                    }

                    outputList.Add(component);

                    if (i == _childsCached.Count - 1)
                        return outputList;
                }
            }

            foreach (Transform child in @this.transform)
            {
                if (child.TryGetComponent(out T component))
                {
                    _childsCached.Add(child);
                    outputList.Add(component);
                }
            }

            return outputList;
        }

        public static void DestroyAllChildren(this Transform @this)
        {
            foreach (Transform child in @this)
            {
                Object.Destroy(child.gameObject);
            }
        }
    }
}