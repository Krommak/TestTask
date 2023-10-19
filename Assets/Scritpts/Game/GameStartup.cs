using Game.Data.Heroes;
using Game.Init;
using Game.Process;
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

        private RuntimeData _runtimeData;
        private GameProcess _gameProcess;

        private void Awake()
        {
            _runtimeData = new RuntimeData();
            _gameProcess = new GameProcess();
        }

        private void Start()
        {
            _graph.GenerateGraph();
            _runtimeData.UnlockHero(_beginningSettings.StartedHero.Faction);
        }
    }

    public class RuntimeData
    {
        public static RuntimeData Instance { get; private set; }
        private Dictionary<FactionType, Hero> _heroesByType { get; set; }

        public RuntimeData()
        {
            Instance = this;
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