using System;
using UnityEngine;

namespace Game.Data.Missions
{
    [Serializable]
    public abstract class MissionEffect
    {
        public abstract void Execute();
    }

    public class UnlockHero : MissionEffect
    {
        [SerializeField]
        private FactionType _faction;
        
        public UnlockHero(FactionType faction)
        {
            _faction = faction;
        }
        
        public override void Execute()
        {
            RuntimeData.Instance.UnlockHero(_faction);
        }
    }

    public class AddHeroPoints : MissionEffect
    {
        [SerializeField]
        private FactionType _faction;
        [SerializeField]
        private int _points;

        public AddHeroPoints(FactionType faction, int points)
        {
            _faction = faction;
            _points = points;
        }

        public override void Execute()
        {
            RuntimeData.Instance.ApplyExp(_faction, _points);
        }
    }
}