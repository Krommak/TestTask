using Game.Data.Heroes;
using TMPro;
using UnityEngine;

namespace Game.UI
{
    public class HeroInfo : MonoBehaviour
    {
        [SerializeField]
        TMP_Text _points;
        [SerializeField]
        TMP_Text _heroName;
        
        public void UpdateInfo(IUIElementData data)
        {
            if(data is Hero heroData)
            {
                _points.text = heroData.Points.ToString();
                _heroName.text = heroData.Faction.ToString();
            }
        }
    }
}