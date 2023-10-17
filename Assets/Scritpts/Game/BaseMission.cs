using Game.Data.Missions;
using System;
using UnityEngine;

namespace Game.Missions
{
    public abstract class Mission : MonoBehaviour
    {
        public MissionState MissionState { get; private set; }
        public Action OnMissionStarted;
        public Action OnMissionEnded;

        public string ContentID
        {
            get
            {
                return _data.ContentID;
            }
            private set
            {

            }
        }

        private GameObject _thisGO;
        private MissionData _data;

        public void InitMission(MissionData data)
        {
            _data = data;
            _thisGO = this.gameObject;

            if(_data.PreviousMissionSelects.Count == 0)
            {
                SetState(MissionState.Active);
            }
            else
            {
                SetState(MissionState.Blocked);
            }

            EndInit();
        }

        public abstract void SetState(MissionState state);

        protected abstract void EndInit();
    }
}