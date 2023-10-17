using Game.Data.Missions;
using UnityEditor;
using UnityEngine;

namespace Game.Inspectors
{
    [CustomEditor(typeof(MissionData))]
    public class MissionDataInspector : CustomInspector<MissionData>
    {
        private SerializedProperty _thisMissionsSelect;
        private SerializedProperty _prevMissions;
        private SerializedProperty _unlockedCharacters;

        protected override void OnEnable()
        {
            base.OnEnable();

            _thisMissionsSelect = serializedObject.FindProperty("ThisMissionSelects");
            _prevMissions = serializedObject.FindProperty("PreviousMissionSelects");
            _unlockedCharacters = serializedObject.FindProperty("UnlockedCharacters");

            if (string.IsNullOrEmpty(Data.ContentID))
                Data.SetNewContentID();
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField(Data.Name, GUIStyles.TitleText);

            EditorGUILayout.Separator();
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("ContentID: ");
            GUILayout.FlexibleSpace();
            EditorGUILayout.LabelField(Data.ContentID);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Обновить ID", GUIStyles.MiddleButton)) Data.SetNewContentID();
            GUILayout.FlexibleSpace();
            if (GUILayout.Button("Скопировать ID", GUIStyles.MiddleButton)) GUIUtility.systemCopyBuffer = Data.ContentID;
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Separator();
            Data.Name = EditorGUILayout.TextField("Название миссии", Data.Name);

            EditorGUILayout.Separator();

            Data.PositionOnScreen = EditorGUILayout.Vector2Field("Позиция на экране", Data.PositionOnScreen);
            EditorGUILayout.Separator();

            serializedObject.Update(); 
            
            EditorGUILayout.Separator();
            _thisMissionsSelect.ShowList("Варианты выбора для этой миссии");
            EditorGUILayout.Separator();
            _prevMissions.ShowList("Список предыдущих миссий");
            EditorGUILayout.Separator();
            _unlockedCharacters.ShowList("Разблокируемые персонажи");
            serializedObject.ApplyModifiedProperties();

            EditorGUILayout.Separator();

            if (GUILayout.Button("Сохранить"))
            {
                EditorUtility.SetDirty(target);
                AssetDatabase.SaveAssets();
            }
        }
    }
}