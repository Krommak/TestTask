using Game.UI;
using System;

namespace Game.Data.Heroes
{
    [Serializable]
    public class Hero : IUIElementData
    {
        public Hero(FactionType factionType)
        {
            Faction = factionType;
            Points = 0;
        }

        public FactionType Faction;
        public int Points;
    }
}
