using Game.Messages;
using Game.Missions;
using Game.Systems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class MissionInfoElement : UIElement
    {
        [SerializeField]
        private TMP_Text _titleField;
        [SerializeField]
        private TMP_Text _descriptionField;
        [SerializeField]
        private Button _startMissionButton;

        private MissionInfoData _data;

        public override void UpdateElement(IUIElementData data)
        {
            if (data is MissionInfoData missionData)
            {
                _data = missionData;

                _titleField.text = missionData.Name;
                _descriptionField.text = missionData.PreText;

                if (missionData.Hero != null)
                {
                    _startMissionButton.onClick.AddListener(() => StartMission());
                    _startMissionButton.interactable = true;
                }
                else
                    _startMissionButton.interactable = false;
            }
        }

        private void StartMission()
        {
            var message = new MissionButtonMessage()
            {
                State = MissionState.TimeBlocked,
                ForConcreteButtons = true,
                Selects = _data.BlockedMissions
            };
            TriggerListenerSystem.OnTrigger(message);
            UIManager.Instance.UpdateElement<EndMissionInfoElement>(_data);
        }

        public override void Cleare()
        {
            _startMissionButton.onClick.RemoveAllListeners();
        }
    }
}