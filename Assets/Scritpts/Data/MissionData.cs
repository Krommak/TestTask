using Game.Missions;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Data.Missions
{
    [CreateAssetMenu(fileName = "MissionData", menuName = "Game/Data/MissionData")]
    public class MissionData : ContentObject
    {
        public int MissionNum;
        public Vector2 PositionOnScreen;
        public string Name;
        public List<MissionSelect> ThisMissionSelects;
        public List<MissionSelect> PreviousMissionSelects;
        public FactionType[] UnlockedCharacters;

        public KeyValuePair<Mission, HashSet<string>> GetNode(Transform container)
        {
            var path = ThisMissionSelects.Count > 1
                ? "Prefabs/DoubleMissionPrefab"
                : "Prefabs/ClassicMissionPrefab";

            var prefab = Resources.Load<Mission>(path);
            var mission = GameObject.Instantiate(prefab, PositionOnScreen, Quaternion.identity).GetComponent<Mission>();
            mission.transform.parent = container;
            mission.gameObject.name = Name;

            mission.InitMission(this);

            var node = new KeyValuePair<Mission, HashSet<string>>(mission, new HashSet<string>());
            
            foreach (var item in ThisMissionSelects)
            {
                node.Value.Add(item.ContentID);
            }

            return node;
        }
    }
}