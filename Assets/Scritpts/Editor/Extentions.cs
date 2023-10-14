using Game.Data.Events;
using UnityEditor;
using UnityEngine;

namespace Game.Inspectors
{
    public static class InspectorExtentions
    {
        public static void ShowList(this SerializedProperty values, string label)
        {
            EditorGUILayout.Separator();
            EditorGUILayout.PropertyField(values, new GUIContent(label), true);
        }

        public static void SetNewContentID<T>(this T obj) where T : Object, IContentObject
        {
            obj.ContentID = AssetDatabase.GetAssetPath(obj);
        }
    }
}