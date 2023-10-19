using Game.Data.Heroes;
using Game.UI;

namespace Game.Process
{
    public class GameProcess
    {
        public static GameProcess Instance;
        private MissionRuned _missionRuned;

        public GameProcess()
        {
            Instance = this;
        }

        public void OpenMission(MissionInfoData mission)
        {
            _missionRuned = new MissionRuned(mission);
        }

        public void SelectHero(Hero hero)
        {
            if(hero != null)
                _missionRuned.AddHero(hero);
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
    }
}
