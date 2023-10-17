using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Data.Missions
{
    [CreateAssetMenu(fileName = "MissionData", menuName = "Game/Data/MissionData")]
    public class MissionData : ScriptableObject, IContentObject
    {
        public string ContentID { get; set; }
        public Vector2 PositionOnScreen;
        public string Name;
        public List<MissionSelect> ThisMissionSelects;
        public List<MissionSelect> PreviousMissionSelects;
        public FactionType[] UnlockedCharacters;
    }

    [Serializable]
    public class EffectForHero
    {
        public FactionType HeroFaction;
        public int HeroPoints;
    }
}