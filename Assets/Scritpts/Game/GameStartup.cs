using Game.Data.Heroes;
using Game.Init;
using Game.Process;
using Game.Systems;
using Game.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class GameStartup : MonoBehaviour
    {
        [SerializeField]
        private MissionsGraphData _graph;
        [SerializeField]
        private BeginningSettings _beginningSettings;
        [SerializeField]
        private Transform _missionContainer;

        private MissionsGraph _missionsGraph;
        private RuntimeData _runtimeData;
        private GameProcess _gameProcess;
        private TriggerListenerSystem _triggerListener;

        private void Awake()
        {
            _runtimeData = new RuntimeData();
            _gameProcess = new GameProcess();
            _triggerListener = new TriggerListenerSystem();
        }

        private void Start()
        {
            _missionsGraph = _graph.GetGraph(_missionContainer);
            _runtimeData.InitHeroes(_beginningSettings.Heroes);
        }

        private void OnDestroy()
        {
            _runtimeData.Dispose();
            _gameProcess.Dispose();
            _triggerListener.Dispose();
        }
    }

    public class RuntimeData : Singleton<RuntimeData>
    {
        private Dictionary<FactionType, Hero> _heroesByType { get; set; }

        public RuntimeData()
        {
            _heroesByType = new Dictionary<FactionType, Hero>();
        }

        public void InitHeroes(HeroData[] heroes)
        {
            foreach (var item in heroes)
            {
                _heroesByType.Add(item.Faction, item.GetHero());
            }
            UIManager.Instance.UpdateElement<HeroPanel>();
        }

        public List<Hero> GetOpenedHeroes()
        {
            var result = new List<Hero>();
            _heroesByType.Values.ToList().ForEach(x =>
            {
                if(x.Unlocked)
                    result.Add(x);
            });
            return result;
        }

        public void ApplyExp(FactionType type, int points)
        {
            if(type == FactionType.None)
            {
                type = GameProcess.Instance.GetActiveHeroType();
            }

            _heroesByType.Values.ToList().ForEach(x =>
            {
                if (x.Faction == type)
                {
                    if (points > 0 && x.Unlocked)
                        x.Points += points;
                    else
                        x.Points += points;
                }
            });

            UIManager.Instance.UpdateElement<HeroPanel>();
        }

        public void UnlockHero(FactionType type)
        {
            _heroesByType.Values.ToList().ForEach(x =>
            {
                if (x.Faction == type)
                    x.Unlocked = true;
            });
            UIManager.Instance.UpdateElement<HeroPanel>();
        }
    }
}