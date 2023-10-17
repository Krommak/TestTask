using UnityEngine;

namespace Game.Missions
{
    public class ClassicMission : Mission
    {
        [SerializeField]
        private MissionButton missionButton;

        public override void SetState(MissionState state)
        {
            missionButton.gameObject.SetActive(state != MissionState.Blocked);
        }

        protected override void EndInit()
        {
        }
    }
}
