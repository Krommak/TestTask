using Game.Init;
using Game.UI;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameStartup : MonoBehaviour
    {
        [SerializeField]
        private MissionsGraph _graph;
        [SerializeField]
        private UIManager _uiManager; 

        private void Start()
        {
            _graph.GenerateGraph();
        }
    }

    public class RuntimeData
    {
        public HashSet<string> Keys;
        public HashSet<string> DoneMissions;
    }
}