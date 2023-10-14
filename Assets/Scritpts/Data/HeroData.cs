using Game.Data.Events;
using UnityEngine;

namespace Game.Data.Heroes
{
    [CreateAssetMenu(fileName = "HeroData", menuName = "Game/Data/Hero")]
    public class HeroData : ScriptableObject, IContentObject
    {
        public FactionType factionType;

        public string ContentID { get; set; }
    }
}
