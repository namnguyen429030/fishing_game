using Assets.Scripts.Concretes.Managers;
using Assets.Scripts.Concretes.StateMachines;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.States.GameState
{
    public class RepeatingState : GameState
    {
        protected override IEnumerator Sequence()
        {
            float x = HookManager.Instance.GetHook().transform.position.x;
            yield return StartCoroutine(HookManager.Instance.MoveObject(new Vector3(x, -7.92f, 0)));
            ObjectsManager.Instance.DisAbleTarget();
            if (ObjectsManager.Instance.GetObjectCount() > 0)
            {
                StateMachineGame.Instance.HandleStandBy();
                StateMachineAudio.Instance.HandleStandBy();
            }
            else
            {
                StateMachineAudio.Instance.HandleFinish();
                StateMachineGame.Instance.HandleFinish();
            }
        }
    }
}
