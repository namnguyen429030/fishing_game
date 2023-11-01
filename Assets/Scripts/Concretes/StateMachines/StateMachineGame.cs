using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Managers;
using Assets.Scripts.Concretes.MoveableObjects;
using Assets.Scripts.Concretes.States.GameState;
using Assets.Scripts.Concretes.States.GameState.Children;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Concretes.StateMachines
{
    public class StateMachineGame : StateMachine
    {
        public static StateMachineGame Instance { get; private set; }
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
        private void Start()
        { 
            HandleStart();
        }
        public override void HandleStart()
        {
            Destroy(CurrentState.GetComponent<GameState>());
            GameState startState = CurrentState.AddComponent<StartState>();
            UpdateState(startState);
        }
        public void HandleStandBy()
        {
            Destroy(CurrentState.GetComponent<GameState>());
            GameState standbyState = CurrentState.AddComponent<StandbyState>();
            UpdateState(standbyState);
        }
        public void HandleHooking()
        {
            Destroy(CurrentState.GetComponent<GameState>());
            GameState hookingState = CurrentState.AddComponent<HookingState>();
            UpdateState(hookingState);
        }
        public void HandleReading()
        {   
            Destroy(CurrentState.GetComponent<GameState>());
            GameState readingState = CurrentState.AddComponent<ReadingState>();
            UpdateState(readingState);
        }
        public void HandleRepeating()
        {
            Destroy(CurrentState.GetComponent<GameState>());
            GameState repeatingState = CurrentState.AddComponent<RepeatingState>();
            UpdateState(repeatingState);
        }
        public override void HandleFinish()
        {
            Destroy(CurrentState.GetComponent<GameState>());
            GameState finishState = CurrentState.AddComponent<FinishState>();
            UpdateState(finishState);
        }
    }
}
