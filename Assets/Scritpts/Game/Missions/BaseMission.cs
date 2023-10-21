using Game.Data.Missions;
using UnityEngine;

namespace Game.Missions
{
    public abstract class Mission : MonoBehaviour
    {
        protected GameObject _thisGO;
        protected MissionData _data;

        public void InitMission(MissionData data)
        {
            _data = data;
            _thisGO = this.gameObject;

            if (_data.PreviousMissionSelects.Count == 0)
            {
                SetState(MissionState.Active);
            }
            else
            {
                SetState(MissionState.Blocked);
            }
        }

        public abstract void SetState(MissionState state);

        public bool CompareSelectID(string otherID)
        {
            foreach (var item in _data.ThisMissionSelects)
            {
                if (item.ContentID == otherID)
                    return true;
            }
            return false;
        }
    }
}