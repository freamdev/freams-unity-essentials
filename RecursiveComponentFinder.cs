using System.Collections.Generic;
using UnityEngine;

namespace ReflectiveAbilitySystem
{
    /// <summary>
    /// Recursively locates a component on every gameobject in its hiearchy.
    /// </summary>
    public class RecursiveComponentFinder<T> where T : Component
    {
        public List<T> GetEveryComponent(GameObject o)
        {
            List<T> foundElements = new List<T>();
            var onThis = o.GetComponent<T>();
            if (onThis != null)
            {
                foundElements.Add(onThis);
            }
            foreach (Transform child in o.transform)
            {
                foundElements.AddRange(GetEveryComponent(child.gameObject));
            }
            foundElements.RemoveAll(f => f == null);
            return foundElements;
        }
    } 
}
