using Game.Data.Heroes;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    public class HeroPanel : UIElement, IDontDeactivateOnOtherPanelOpened
    {
        [SerializeField]
        private HeroInfo _heroInfoPrefab;
        [SerializeField]
        private int _maxHeroInfoWidth = 125;

        private Dictionary<FactionType, HeroInfo> _heroesInfoByType;

        private void AddHero(Hero hero)
        {
            var info = Instantiate<HeroInfo>(_heroInfoPrefab, transform);
            var rect = transform as RectTransform;
            var width = rect.rect.width/5;
            info.GetComponent<RectTransform>()
                .SetSizeWithCurrentAnchors(
                    RectTransform.Axis.Horizontal,
                    width > _maxHeroInfoWidth ? _maxHeroInfoWidth : width);
            info.UpdateInfo(hero);
            _heroesInfoByType.Add(hero.Faction, info);
        }

        public void UpdateHeroes()
        {
            var heroes = RuntimeData.Instance.GetOpenedHeroes();

            if(_heroesInfoByType == null)
                _heroesInfoByType = new Dictionary<FactionType, HeroInfo>();

            foreach (var hero in heroes)
            {
                if (_heroesInfoByType.ContainsKey(hero.Faction))
                {
                    _heroesInfoByType[hero.Faction].UpdateInfo(hero);
                }
                else
                {
                    AddHero(hero);
                }
            }
        }

        public override void UpdateElement(IUIElementData data = null)
        {
            UpdateHeroes();
        }

        public override void Cleare()
        {
        }
    }
}