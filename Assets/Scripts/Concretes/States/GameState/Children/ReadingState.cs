using Assets.Scripts.Concretes.StateMachines;
using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Concretes.States.GameState
{
    public class ReadingState : GameState
    {
        protected override IEnumerator Sequence()
        {
            StateMachineAudio.Instance.HandleReading();
            yield return new WaitForSeconds(2);
            StateMachineGame.Instance.HandleRepeating();
            yield return null;
        }
    }
}
