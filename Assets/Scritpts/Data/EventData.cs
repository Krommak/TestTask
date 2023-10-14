using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Game.Data.Events
{
    [CreateAssetMenu(fileName = "EventData", menuName = "Game/Data/EventData")]
    public class EventData : ScriptableObject, IContentObject
    {
        public string ContentID { get; set; }

        public string Name;
        public string PreText;
        public string Description;

        public FactionType[] PlayerFactions;
        public FactionType[] EnemyFactions;
        public List<EventData> PreviousMissions;
    }

    public enum FactionType
    {
        None,
        Hawks,
        Ravens,
        Eagles,
    }

    public interface IContentObject
    {
        public string ContentID { get; set; }
    }
}