using UnityEditor;
using UnityEngine;

namespace Game.Events.Inspectors
{
    public abstract class CustomInspector<T> : Editor where T : ScriptableObject
    {
        protected T Data;

        private void OnEnable()
        {
            Data = (T)target;
        }
    }
}
