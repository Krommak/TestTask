using Game.UI;
using TMPro;
using UnityEngine;

namespace Game.Missions
{
    public class MissionButton : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _text;
        MissionInfoData _data;
        public void InitButton(MissionInfoData data, string missionNum)
        {
            _data = data;
            _text.text = missionNum;
        }

        private void OnMouseDown()
        {
            UIManager.Instance.UpdateElement<MissionInfoElement>(_data);
        }
    }
}