using Game.Data.Missions;
using Game.UI;
using System.Collections.Generic;
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
            var effects = new List<MissionEffect>();
            foreach (var item in _data.UnlockedCharacters)
            {
                effects.Add(new UnlockHero(item));
            }
            foreach (var item in _data.ThisMissionSelects[0].HeroPoints)
            {
                effects.Add(new AddHeroPoints(item.HeroFaction, item.HeroPoints));
            }
            var data = new MissionInfoData()
            {
                SelectID = _data.ThisMissionSelects[0].ContentID,
                Name = _data.Name,
                PreText = _data.ThisMissionSelects[0].PreText,
                Description = _data.ThisMissionSelects[0].Description,
                EnemyFactions = _data.ThisMissionSelects[0].EnemyFactions,
                PlayerFactions = _data.ThisMissionSelects[0].PlayerFactions,
                Effects = effects
            };

            missionButton.InitButton(data, _data.MissionNum.ToString(), state);
        }
    }
}
