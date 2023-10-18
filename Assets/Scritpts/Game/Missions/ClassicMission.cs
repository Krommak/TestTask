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

            var data = new MissionInfoData()
            {
                Name = _data.Name,
                Description = _data.ThisMissionSelects[0].PreText + '\n' + _data.ThisMissionSelects[0].Description,
                EnemyFactions = _data.ThisMissionSelects[0].EnemyFactions,
                PlayerFactions = _data.ThisMissionSelects[0].PlayerFactions
            };

            missionButton.InitButton(data, _data.MissionNum.ToString());
        }

        protected override void EndInit()
        {
        }
    }
}
