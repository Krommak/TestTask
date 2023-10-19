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
                _descriptionField.text = missionData.Description;

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
            //UIManager.Instance.UpdateElement<>
        }

        public override void Cleare()
        {
            _startMissionButton.onClick.RemoveAllListeners();
        }
    }
}