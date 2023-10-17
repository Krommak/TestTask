using System;
using TMPro;
using UnityEngine;

namespace Game.Missions
{
    public class MissionButton : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _text;
        private Action _onClick;

        private void InitElement()
        {

        }
    }
}