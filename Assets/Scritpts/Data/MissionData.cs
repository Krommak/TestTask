using Game.Missions;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Data.Missions
{
    [CreateAssetMenu(fileName = "MissionData", menuName = "Game/Data/MissionData")]
    public class MissionData : ScriptableObject, IContentObject
    {
        public string ContentID { get; set; }
        public Vector2 PositionOnScreen;
        public string Name;
        public List<MissionSelect> ThisMissionSelects;
        public List<MissionSelect> PreviousMissionSelects;
        public FactionType[] UnlockedCharacters;

        public KeyValuePair<Mission, HashSet<string>> GetNode()
        {
            var path = ThisMissionSelects.Count > 1
                ? "Prefabs/DoubleMissionPrefab"
                : "Prefabs/ClassicMissionPrefab";

            var mission = Resources.Load<Mission>(path);
            var go = GameObject.Instantiate(mission, PositionOnScreen, Quaternion.identity);
            go.name = Name;

            mission.InitMission(this);

            var node = new KeyValuePair<Mission, HashSet<string>>(mission, new HashSet<string>());
            
            foreach (var item in ThisMissionSelects)
            {
                node.Value.Add(item.ContentID);
            }

            return node;
        }
    }

    [Serializable]
    public class EffectForHero
    {
        public FactionType HeroFaction;
        public int HeroPoints;
    }
}