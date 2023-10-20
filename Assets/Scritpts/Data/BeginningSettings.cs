using Game.Data.Heroes;
using UnityEngine;

namespace Game.Init
{
    [CreateAssetMenu(fileName = "BeginningSettings", menuName = "Game/BeginningSettings")]
    public class BeginningSettings : ScriptableObject
    {
        public HeroData[] Heroes;
    }
}