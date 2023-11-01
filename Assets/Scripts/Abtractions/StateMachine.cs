using UnityEngine;

namespace Assets.Scripts.Abtractions
{
    public abstract class StateMachine : MonoBehaviour
    {
        [SerializeField] protected GameObject CurrentState;
        public void UpdateState(State state)
        {
            state.PerformState();
        }
        public abstract void HandleStart();
        public abstract void HandleFinish();
        public State GetCurrentState()
        {
            return CurrentState.GetComponent<State>();
        }
    }
}
