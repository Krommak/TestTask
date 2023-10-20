using Game.Data.Missions;
using UnityEditor;
using UnityEngine;

namespace Game.Inspectors
{
    [CustomEditor(typeof(MissionSelect))]
    public class MissionSelectInspector : CustomInspector<MissionSelect>
    {
        private SerializedProperty _playerFactions;
        private SerializedProperty _enemyFactions;
        private SerializedProperty _heroPoints;

        protected override void OnEnable()
        {
            base.OnEnable();

            _playerFactions = serializedObject.FindProperty("PlayerFactions");
            _enemyFactions = serializedObject.FindProperty("EnemyFactions");
            _heroPoints = serializedObject.FindProperty("HeroPoints");

            if (string.IsNullOrEmpty(Data.ContentID))
                Data.SetNewContentID();
        }

        public override void OnInspectorGUI()
        {
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
            EditorGUILayout.LabelField("Пре-текст миссии");
            Data.PreText = EditorGUILayout.TextArea(Data.PreText, EditorStyles.textArea);

            EditorGUILayout.Separator();
            EditorGUILayout.LabelField("Текст происходящего в миссии");
            Data.Description = EditorGUILayout.TextArea(Data.Description, EditorStyles.textArea);

            serializedObject.Update();
            EditorGUILayout.Separator();
            _playerFactions.ShowList("Сторона игрока");
            EditorGUILayout.Separator();
            _enemyFactions.ShowList("Сторона противника");
            EditorGUILayout.Separator();
            _heroPoints.ShowList("Очки героев");
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