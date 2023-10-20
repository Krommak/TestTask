using Game.UI;
using System;

namespace Game.Data.Heroes
{
    [Serializable]
    public class HeroData
    {
        public string Name;
        public FactionType Faction;
        public int Points;
        public bool Unlocked;

        public Hero GetHero()
        {
            return new Hero()
            {
                Name = Name,
                Faction = Faction,
                Points = Points,
                Unlocked = Unlocked
            };
        }
    }

    public class Hero : IUIElementData
    {
        public string Name;
        public FactionType Faction;
        public int Points;
        public bool Unlocked;
    }
}
