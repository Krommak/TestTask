using Game.Events.Data;
using UnityEditor;

namespace Game.Events.Inspectors
{
    [CustomEditor(typeof(EventData))]
    public class EventDataInspector : CustomInspector<EventData>
    {
        public override void OnInspectorGUI()
        {
            Data.Name = EditorGUILayout.TextField("Название миссии", Data.Name);
            Data.PreText = EditorGUILayout.TextField("Пре-текст миссии", Data.PreText);
            Data.Description = EditorGUILayout.TextField("Текст происходящего в миссии", Data.Description);
        }
    }
}