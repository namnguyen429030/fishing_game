using Assets.Scripts.Concretes.Managers;
using Assets.Scripts.Concretes.StateMachines;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.States.GameState
{
    public class StartState : GameState
    {
        protected override IEnumerator Sequence()
        {
            StateMachineBackground.Instance.HandleStart();
            yield return StartCoroutine(CatManager.Instance.MoveObject(new Vector3(0, -1.95f, 0)));
            StateMachineCamera.Instance.HandleStart();
            yield return new WaitForSeconds(3f);
            HookManager.Instance.AdjustObject(true);
            StateMachineAudio.Instance.HandleStart();
            yield return new WaitForSeconds(1.3f);
            StateMachineGame.Instance.HandleStandBy();
        }
    }
}
