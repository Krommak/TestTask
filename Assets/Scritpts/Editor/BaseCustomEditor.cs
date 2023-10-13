using UnityEditor;
using UnityEngine;

namespace Game.Inspectors
{
    public abstract class CustomInspector<T> : Editor where T : ScriptableObject
    {
        protected T Data;
        protected GUIStyle Style;

        protected virtual void OnEnable()
        {
            Data = (T)target;
            Style = new GUIStyle();
            Style.normal.textColor = Color.white;
            Style.fontSize = 20;
            Style.alignment = TextAnchor.MiddleCenter;
        }
    }
}
