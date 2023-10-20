using Game.Data.Missions;
using Game.UI;
using System.Collections.Generic;
using UnityEngine;

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

                var effects = new List<MissionEffect>();
                foreach (var item in _data.UnlockedCharacters)
                {
                    effects.Add(new UnlockHero(item));
                }
                foreach (var item in _data.ThisMissionSelects[i].HeroPoints)
                {
                    effects.Add(new AddHeroPoints(item.HeroFaction, item.HeroPoints));
                }
                var data = new MissionInfoData()
                {
                    SelectID = _data.ThisMissionSelects[i].ContentID,
                    Name = _data.Name,
                    PreText = _data.ThisMissionSelects[i].PreText,
                    Description = _data.ThisMissionSelects[i].Description,
                    EnemyFactions = _data.ThisMissionSelects[i].EnemyFactions,
                    PlayerFactions = _data.ThisMissionSelects[i].PlayerFactions,
                    Effects = effects
                };

                missionButtons[i].InitButton(data, $"{_data.MissionNum}.{i+1}", state);
            }
        }
    }
}
