using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.States.CameraState;

namespace Assets.Scripts.Concretes.StateMachines
{
    public class StateMachineCamera : StateMachine
    {
        public static StateMachineCamera Instance { get; set; }
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }
        public override void HandleStart()
        {
            Destroy(CurrentState.GetComponent<CameraState>());
            CameraState startState = CurrentState.AddComponent<StartState>();
            UpdateState(startState);
        }
        public override void HandleFinish()
        {
            Destroy(CurrentState.GetComponent<CameraState>());
            CameraState finishState = CurrentState.AddComponent<FinishState>();
            UpdateState(finishState);
        }
    }
}
