using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.States.BackgroundState;
using Assets.Scripts.Concretes.States.BackgroundState.Children;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Concretes.StateMachines
{
    public class StateMachineBackground : StateMachine
    {
        public static StateMachineBackground Instance { get; private set; }
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
        public override void HandleFinish()
        {
            Destroy(CurrentState.GetComponent<StateMachineBackground>());
            BackgroundState finishState = CurrentState.AddComponent<FinishState>();
            UpdateState(finishState);
        }

        public override void HandleStart()
        {
            Destroy(CurrentState.GetComponent<StateMachineBackground>());
            BackgroundState startState = CurrentState.AddComponent<StartState>();
            UpdateState(startState);
        }
    }
}
