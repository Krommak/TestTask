using Game.Data.Heroes;
using Game.Missions;
using Game.Systems;
using Game.UI;

namespace Game.Process
{
    public class GameProcess : Singleton<GameProcess>
    {
        private MissionRuned _missionRuned;

        public void OpenMission(MissionInfoData mission)
        {
            _missionRuned = new MissionRuned(mission);
        }

        public void SelectHero(Hero hero)
        {
            if(hero != null && _missionRuned != null)
                _missionRuned.AddHero(hero);
        }

        public void CloseMission()
        {
            _missionRuned.ApplyMissionEffects();
            UIManager.Instance.CleareaAndHideElement<EndMissionInfoElement>();
        }
    }

    public class MissionRuned
    {
        private MissionInfoData _mission;

        public MissionRuned(MissionInfoData mission)
        {
            _mission = mission;
        }

        public void AddHero(Hero hero)
        {
            _mission.Hero = hero;
            UIManager.Instance.UpdateElement<MissionInfoElement>(_mission);
        }

        public void ApplyMissionEffects()
        {
            TriggerListenerSystem.Instance.OnTrigger(new MissionMessage()
            {
                DoneMissionID = _mission.SelectID
            });
        }
    }
}
