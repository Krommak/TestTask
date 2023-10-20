using Game.Data.Missions;
using Game.Systems;
using UnityEngine;

namespace Game.Missions
{
    public abstract class Mission : MonoBehaviour, IListener
    {
        protected GameObject _thisGO;
        protected MissionData _data;

        private void OnEnable()
        {
            TriggerListenerSystem.Instance.AddListener(this, typeof(MissionMessage));
        }

        private void OnDisable()
        {
            TriggerListenerSystem.Instance?.RemoveListener(this, typeof(MissionMessage));
        }

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

        public void OnTrigger(IMessage message)
        {
            if (message is MissionMessage mess)
            {
                _data.PreviousMissionSelects.ForEach(x =>
                {
                    if(x.ContentID == mess.DoneMissionID)
                    {
                        SetState(MissionState.Active);
                        return;
                    }
                });
                _data.ThisMissionSelects.ForEach(x =>
                {
                    if (x.ContentID == mess.DoneMissionID)
                    {
                        SetState(MissionState.Done);
                        return;
                    }
                });
            }
        }
    }

    public class MissionMessage : IMessage
    {
        public string DoneMissionID;
    }
}