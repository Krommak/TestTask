using Game.Data.Missions;
using Game.Missions;
using Game.Systems;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Init
{
    [CreateAssetMenu(fileName = "MissionsGraph", menuName = "Game/MissionsGraph")]
    public class MissionsGraphData : ScriptableObject
    {
        public MissionData[] _missions;

        public MissionsGraph GetGraph(Transform container)
        {
            return new MissionsGraph(_missions, container);
        }
    }

    public class MissionsGraph : IListener, IDisposable
    {
        private Dictionary<string, HashSet<Mission>> _keysForMissions;

        public MissionsGraph(MissionData[] _missions, Transform container)
        {
            GenerateGraph(_missions, container);
            TriggerListenerSystem.Instance.AddListener(this, typeof(MissionMessage));
        }

        public void GenerateGraph(MissionData[] _missions, Transform container)
        {
            _keysForMissions = new Dictionary<string, HashSet<Mission>>();

            foreach (var item in _missions)
            {
                var node = item.GetNode(container);
                foreach (var key in node.Value)
                {
                    SetPair(key, node.Key);
                }
            }
        }

        private void SetPair(string key, Mission value)
        {
            if (_keysForMissions.ContainsKey(key))
            {
                _keysForMissions[key].Add(value);
            }
            else
            {
                _keysForMissions.Add(key, new HashSet<Mission>() { value });
            }
        }

        public void OnTrigger(IMessage message)
        {
            if (message is MissionMessage mess 
                && _keysForMissions.ContainsKey(mess.DoneMissionID))
            {
                foreach(var item in _keysForMissions[mess.DoneMissionID])
                {
                    if (item.CompareSelectID(mess.DoneMissionID))
                    {
                        item.SetState(MissionState.Done);
                    }
                    else
                    {
                        item.SetState(MissionState.Active);
                    }
                }
            }
        }

        public void Dispose()
        {
            TriggerListenerSystem.Instance.RemoveListener(this, typeof(MissionMessage));
        }
    }
}