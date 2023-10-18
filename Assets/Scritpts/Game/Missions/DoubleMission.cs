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
                    Name = _data.Name,
                    Description = _data.ThisMissionSelects[i].PreText + '\n' + _data.ThisMissionSelects[i].Description,
                    EnemyFactions = _data.ThisMissionSelects[i].EnemyFactions,
                    PlayerFactions = _data.ThisMissionSelects[i].PlayerFactions
                };

                missionButtons[i].InitButton(data, $"{_data.MissionNum}.{i+1}");
            }
        }

        protected override void EndInit()
        {
        }
    }
}
