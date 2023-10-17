using UnityEngine;

namespace Game.Data.Heroes
{
    [CreateAssetMenu(fileName = "HeroData", menuName = "Game/Data/Hero")]
    public class HeroData : ScriptableObject, IContentObject
    {
        public FactionType FactionType;

        public string ContentID { get; set; }
    }
}
