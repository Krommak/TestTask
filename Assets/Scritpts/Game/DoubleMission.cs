using UnityEngine;

namespace Game.Missions
{
    public class DoubleMission : Mission
    {
        [SerializeField]
        private MissionButton[] missionButtons;

        public override void SetState(MissionState state)
        {
            foreach(var item in missionButtons)
            {
                item.gameObject.SetActive(state != MissionState.Blocked);
            }
        }

        protected override void EndInit()
        {
        }
    }
}
