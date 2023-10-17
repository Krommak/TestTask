using Game.Init;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameStartup : MonoBehaviour
    {
        [SerializeField]
        private MissionsGraph _graph;

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