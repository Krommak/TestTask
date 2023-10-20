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
        private MissionsGraph _graph;
        [SerializeField]
        private BeginningSettings _beginningSettings;
        [SerializeField]
        private Transform _missionContainer;

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
            _graph.GenerateGraph(_missionContainer);
            _runtimeData.UnlockHero(_beginningSettings.StartedHero.Faction);
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

        public List<Hero> GetOpenedHeroes()
        {
            return _heroesByType.Values.ToList();
        }

        public void UnlockHero(FactionType type)
        {
            _heroesByType.Add(type, new Hero(type));
            UIManager.Instance.UpdateElement<HeroPanel>();
        }
    }
}