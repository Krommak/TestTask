using Game.Process;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class EndMissionInfoElement : UIElement
    {
        [SerializeField]
        private TMP_Text _titleField;
        [SerializeField]
        private TMP_Text _playerFactionsField;
        [SerializeField]
        private TMP_Text _enemyFactionsField;
        [SerializeField]
        private TMP_Text _descriptionField;
        [SerializeField]
        private Button _endMissionButton;

        private MissionInfoData _data;

        public override void UpdateElement(IUIElementData data)
        {
            if (data is MissionInfoData missionData)
            {
                _data = missionData;

                _titleField.text = missionData.Name;
                _descriptionField.text = missionData.Description;

                _playerFactionsField.text = GetFactions(_data.PlayerFactions);
                _enemyFactionsField.text = GetFactions(_data.EnemyFactions);
                
                _endMissionButton.onClick.AddListener(() => CloseMission());
            }
        }

        private string GetFactions(FactionType[] types)
        {
            if (types.Length == 1 && types[0] == FactionType.None)
            {
                return "Нет гнезда";
            }
            var result = "";
            foreach (var item in types)
            {
                result += $"{item}, ";
            }
            return result;
        }

        private void CloseMission()
        {
            GameProcess.Instance.CloseMission();
        }

        public override void Cleare()
        {
            _endMissionButton.onClick.RemoveAllListeners();
        }
    }
}