using Game.Process;
using Game.Systems;
using Game.UI;
using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.Missions
{
    public class MissionButton : MonoBehaviour, IListener, IDisposable
    {
        [SerializeField]
        private TMP_Text _text;
        [SerializeField]
        private SpriteRenderer _image;
        private MissionInfoData _data;
        private MissionState _state;
        
        public void InitButton(MissionInfoData data, string missionNum, MissionState state)
        {
            _state = state;
            _data = data;
            _text.text = missionNum;
            ApplyNewState();
            TriggerListenerSystem.Instance.AddListener(this, typeof(MissionButtonMessage));
        }

        public void OnTrigger(IMessage message)
        {
            if(message is MissionButtonMessage mess)
            {
                _state = mess.State;
                ApplyNewState();
            }
        }

        public void SetState(MissionState state)
        {
            _state = state;
            ApplyNewState();
        }

        private void ApplyNewState()
        {
            switch(_state)
            {
                case MissionState.Blocked:
                    break;
                case MissionState.Done:
                    _image.color = Color.blue;
                    break;
                case MissionState.TimeBlocked:
                    _image.color = Color.gray;
                    break;
                case MissionState.Active:
                    _image.color = Color.green;
                    break;
            }
        }

        private void OnMouseDown()
        {
            if (_state != MissionState.Active) return;

            UIManager.Instance.UpdateElement<MissionInfoElement>(_data);
            GameProcess.Instance.OpenMission(_data);
        }

        public void Dispose()
        {
            TriggerListenerSystem.Instance.RemoveListener(this, typeof(MissionButtonMessage));
        }
    }

    public class MissionButtonMessage : IMessage
    {
        public MissionState State;
    }
}