using Game.Data.Heroes;

namespace Game.UI
{
    public class MissionInfoData : IUIElementData
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public FactionType[] PlayerFactions { get; set; }
        public FactionType[] EnemyFactions { get; set; }
        public Hero Hero { get; set; }
    }
}