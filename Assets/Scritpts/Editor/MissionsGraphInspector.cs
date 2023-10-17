using Game.Init;
using UnityEditor;
using UnityEngine;

namespace Game.Inspectors
{
    [CustomEditor(typeof(MissionsGraph))]
    public class MissionsGraphInspector : CustomInspector<MissionsGraph>
    {
        private SerializedProperty _missions;

        protected override void OnEnable()
        {
            base.OnEnable();

            _missions = serializedObject.FindProperty("_missions");
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.Separator();
            _missions.ShowList("Ассеты миссий");
            EditorGUILayout.Separator();

            serializedObject.ApplyModifiedProperties();

            if (GUILayout.Button("Сохранить"))
            {
                EditorUtility.SetDirty(target);
                AssetDatabase.SaveAssets();
            }
        }
    }
}