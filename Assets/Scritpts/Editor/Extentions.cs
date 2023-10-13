using UnityEditor;
using UnityEngine;

namespace Game.Inspectors
{
    public static class Extentions
    {
        public static void ShowEnumValues(this SerializedProperty values)
        {
            GUILayout.BeginVertical("Box");
            EditorGUILayout.LabelField(values.name);
            for (int i = 0; i < values.arraySize; i++)
            {
                SerializedProperty enumElementProperty = values.GetArrayElementAtIndex(i);

                enumElementProperty.enumValueIndex = EditorGUILayout.Popup("Element " + i, enumElementProperty.enumValueIndex, enumElementProperty.enumDisplayNames);
            }

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("+"))
                values.InsertArrayElementAtIndex(values.arraySize);
            if (GUILayout.Button("-"))
                values.DeleteArrayElementAtIndex(values.arraySize - 1);
            GUILayout.EndHorizontal();

            GUILayout.EndVertical();
        }
    }
}