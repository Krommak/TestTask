using UnityEngine;

namespace Game.Data.Missions
{
    [CreateAssetMenu(fileName = "MissionSelect", menuName = "Game/Data/MissionSelect")]
    public class MissionSelect : ScriptableObject, IContentObject
    {
        public string ContentID { get; set; }
     
        public string PreText;
        public string Description;

        public FactionType[] PlayerFactions;
        public FactionType[] EnemyFactions;

        public EffectForHero[] HeroPoints;
    }
}