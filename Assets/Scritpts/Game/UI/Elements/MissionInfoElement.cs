using Game.Data.Missions;
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
                _startMissionButton.onClick.AddListener(() => StartMission());
            }
        }

        private void StartMission()
        {
            //UIManager.Instance.UpdateElement<>
        }

        public override void Cleare()
        {
        }
    }

    public class MissionInfoData : IUIElementData
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public FactionType[] PlayerFactions { get; set; }
        public FactionType[] EnemyFactions { get; set; }

    }
}