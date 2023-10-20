using Game.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Missions
{
    public class DoubleMission : Mission
    {
        [SerializeField]
        private MissionButton[] missionButtons;

        public override void SetState(MissionState state)
        {
            for (var i = 0; i < missionButtons.Length; i++)
            {
                missionButtons[i].gameObject.SetActive(state != MissionState.Blocked);

                var data = new MissionInfoData()
                {
                    SelectID = _data.ThisMissionSelects[i].ContentID,
                    Name = _data.Name,
                    PreText = _data.ThisMissionSelects[i].PreText,
                    Description = _data.ThisMissionSelects[i].Description,
                    EnemyFactions = _data.ThisMissionSelects[i].EnemyFactions,
                    PlayerFactions = _data.ThisMissionSelects[i].PlayerFactions
                };

                missionButtons[i].InitButton(data, $"{_data.MissionNum}.{i+1}", state);
            }
        }

        protected override void EndInit()
        {
        }
    }
}
