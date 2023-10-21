using Game.Data.Heroes;
using Game.Messages;
using Game.Systems;
using Game.UI;
using System;

namespace Game.Process
{
    public class GameProcess : IListener, IDisposable
    {
        private MissionRuned _missionRuned;
        private FactionType _activeHero;

        public GameProcess()
        {
            TriggerListenerSystem.AddListener(this, typeof(MissionStartMessage));
            TriggerListenerSystem.AddListener(this, typeof(GetHeroTypeMessage));
            TriggerListenerSystem.AddListener(this, typeof(SelectHeroMessage));
            TriggerListenerSystem.AddListener(this, typeof(MissionEndMessage));
        }

        private void OpenMission(MissionInfoData mission)
        {
            _missionRuned = new MissionRuned(mission);
        }

        private void CloseMission()
        {
            _missionRuned.ApplyMissionEffects();
            UIManager.Instance.CleareaAndHideElement<EndMissionInfoElement>();
        }

        public void OnTrigger(IMessage message = null)
        {
            if(message is MissionStartMessage mess)
            {
                OpenMission(mess.MissionInfo);
            }
            else if(message is GetHeroTypeMessage getHeroTypeMessage)
            {
                getHeroTypeMessage.Type = _activeHero;
            }
            else if(message is SelectHeroMessage selectHero)
            {
                _activeHero = selectHero.Hero.Faction;
                _missionRuned?.AddHero(selectHero.Hero);
            }
            else if(message is MissionEndMessage endMessage)
            {
                CloseMission();
            }
        }

        public void Dispose()
        {
            TriggerListenerSystem.RemoveListener(this);
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
            _mission.Effects.ForEach(x => x.Execute());

            TriggerListenerSystem.OnTrigger(new MissionDoneMessage()
            {
                DoneMissionID = _mission.SelectID
            });
        }
    }
}
