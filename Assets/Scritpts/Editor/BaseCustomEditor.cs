using UnityEditor;
using UnityEngine;

namespace Game.Inspectors
{
    public abstract class CustomInspector<T> : Editor where T : ScriptableObject
    {
        protected T Data;

        protected virtual void OnEnable()
        {
            Data = (T)target;
        }
    }
}
