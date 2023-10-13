using Game.Events.Data;
using UnityEditor;

namespace Game.Inspectors
{
    [CustomEditor(typeof(EventData))]
    public class EventDataInspector : CustomInspector<EventData>
    {
        private SerializedProperty _playerFactions;
        private SerializedProperty _enemyFactions;

        protected override void OnEnable()
        {
            base.OnEnable();

            _playerFactions = serializedObject.FindProperty("PlayerFactions");
            _enemyFactions = serializedObject.FindProperty("EnemyFactions");
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField(Data.Name, Style);

            EditorGUILayout.Separator();
            Data.Name = EditorGUILayout.TextField("Название миссии", Data.Name);
            
            EditorGUILayout.Separator();
            EditorGUILayout.LabelField("Пре-текст миссии");
            Data.PreText = EditorGUILayout.TextArea(Data.PreText, EditorStyles.textArea);
            
            EditorGUILayout.Separator();
            EditorGUILayout.LabelField("Текст происходящего в миссии");
            Data.Description = EditorGUILayout.TextArea(Data.Description, EditorStyles.textArea);

            serializedObject.Update();

            _playerFactions.ShowEnumValues();
            _enemyFactions.ShowEnumValues();

            serializedObject.ApplyModifiedProperties();
        }
    }
}