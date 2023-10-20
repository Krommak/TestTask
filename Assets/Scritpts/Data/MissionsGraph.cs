using Game.Data.Missions;
using Game.Missions;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Init
{
    [CreateAssetMenu(fileName = "MissionsGraph", menuName = "Game/MissionsGraph")]
    public class MissionsGraph : ScriptableObject
    {
        public MissionData[] _missions;
        private Dictionary<string, HashSet<Mission>> _keysForMissions;

        public void GenerateGraph(Transform container)
        {
            _keysForMissions = new Dictionary<string, HashSet<Mission>>();

            foreach (var item in _missions)
            {
                var node = item.GetNode(container);
                foreach (var key in node.Value)
                {
                    SetNewPair(key, node.Key);
                }
            }
        }

        private void SetNewPair(string key, Mission value)
        {
            if(_keysForMissions.ContainsKey(key))
            {
                _keysForMissions[key].Add(value);
            }
            else
            {
                _keysForMissions.Add(key, new HashSet<Mission>() { value });
            }
        }
    }
}