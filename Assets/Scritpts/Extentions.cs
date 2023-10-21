using Game.Data;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Game.Extentions
{
    public static class Extentions
    {
        public static void ShowList(this SerializedProperty values, string label)
        {
            EditorGUILayout.Separator();
            EditorGUILayout.PropertyField(values, new GUIContent(label), true);
        }

        public static void SetNewContentID<T>(this T obj) where T : ContentObject
        {
            obj.ContentID = AssetDatabase.GetAssetPath(obj);
        }

        public static void RemoveBySwap<T>(this List<T> list, int index)
        {
            list[index] = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
        }
    }
}