using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.States.AudioState;
using Assets.Scripts.Concretes.States.AudioState.Children;

namespace Assets.Scripts.Concretes.StateMachines
{
    public class StateMachineAudio : StateMachine
    {
        public static StateMachineAudio Instance { get; set; }
        public int Token { get; private set; } = 0;
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
            Destroy(CurrentState.GetComponent<AudioState>());
            AudioState startState = CurrentState.AddComponent<StartState>();
            UpdateState(startState);
        }
        public void HandleStandBy()
        {
            Destroy(CurrentState.GetComponent<AudioState>());
            AudioState standbyState = CurrentState.AddComponent<StandbyState>();
            UpdateState(standbyState);
            Token++;
        }
        public void HandleReading()
        {
            Destroy(CurrentState.GetComponent<AudioState>());
            AudioState readingState = CurrentState.AddComponent<ReadingState>();
            UpdateState(readingState);
        }
        public override void HandleFinish()
        {
            Destroy(CurrentState.GetComponent<AudioState>());
            AudioState finishState = CurrentState.AddComponent<FinishState>();
            UpdateState(finishState);
        }
    }
}
