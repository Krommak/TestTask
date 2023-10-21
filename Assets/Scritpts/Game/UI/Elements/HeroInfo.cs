using Game.Data.Heroes;
using Game.Messages;
using Game.Systems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    [RequireComponent(typeof(Button))]
    public class HeroInfo : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _points;
        [SerializeField]
        private TMP_Text _heroName;
        private Hero _hero;

        private void OnEnable()
        {
            GetComponent<Button>().onClick.AddListener(() =>
            {
                TriggerListenerSystem.OnTrigger(new SelectHeroMessage() { Hero = _hero });
            });
        }

        public void UpdateInfo(IUIElementData data)
        {
            if(data is Hero heroData)
            {
                _hero = heroData;
                _points.text = heroData.Points.ToString();
                _heroName.text = heroData.Name.ToString();
            }
        }

        private void OnDisable()
        {
            GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }
}