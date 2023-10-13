using UnityEngine;

namespace Game.Events.Data
{
    [CreateAssetMenu(fileName = "EventData", menuName = "Game/Data/EventData")]
    public class EventData : ScriptableObject
    {
        public string Name;
        public string PreText;
        public string Description;
        public FactionType[] PlayerFactions;
        public FactionType[] EnemyFactions;
    }

    public enum FactionType
    {
        None,
        Hawks,
        Ravens,
        Eagles,
    }
}