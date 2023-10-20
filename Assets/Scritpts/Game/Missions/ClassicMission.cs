using Game.Systems;
using Game.UI;
using UnityEngine;

namespace Game.Missions
{
    public class ClassicMission : Mission
    {
        [SerializeField]
        private MissionButton missionButton;

        public override void SetState(MissionState state)
        {
            missionButton.gameObject.SetActive(state != MissionState.Blocked);
            missionButton.SetState(state);
            var data = new MissionInfoData()
            {
                SelectID = _data.ThisMissionSelects[0].ContentID,
                Name = _data.Name,
                PreText = _data.ThisMissionSelects[0].PreText,
                Description = _data.ThisMissionSelects[0].Description,
                EnemyFactions = _data.ThisMissionSelects[0].EnemyFactions,
                PlayerFactions = _data.ThisMissionSelects[0].PlayerFactions
            };

            missionButton.InitButton(data, _data.MissionNum.ToString(), state);
        }

        protected override void EndInit()
        {
        }
    }
}
