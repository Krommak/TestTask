using Game.Data.Heroes;
using Game.UI;
using System.Collections.Generic;

namespace Game.Messages
{
    public interface IMessage
    {
    }

    public class MissionButtonMessage : IMessage
    {
        public MissionState State;
        public bool ForConcreteButtons;
        public List<string> Selects;
    }

    public class MissionStartMessage : IMessage
    {
        public MissionInfoData MissionInfo;
    }

    public class MissionDoneMessage : IMessage
    {
        public string DoneMissionID;
    }

    public class GetHeroTypeMessage : IMessage
    {
        public FactionType Type;
    }

    public class SelectHeroMessage : IMessage
    {
        public Hero Hero;
    }

    public class MissionEndMessage : IMessage
    {
        public Hero Hero;
    }
}
