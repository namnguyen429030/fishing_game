using Assets.Scripts.Concretes.Managers;
using Assets.Scripts.Concretes.StateMachines;
using Assets.Scripts.Enums;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.States.GameState
{
    public class StandbyState : GameState
    {
        private readonly Vector3 defaultPosition = new Vector3(0.6f, -7.92f, 0);
        private readonly Vector3 defaultStandByPosition = new Vector3(0.6f, -16f, 0);

        protected override IEnumerator Sequence()
        {
            HookManager.Instance.Place(defaultPosition);
            HookManager.Instance.ChangeAnimation(EnumHookAnimation.Moc_gap_do_wating);
            yield return StartCoroutine(HookManager.Instance.MoveObject(defaultStandByPosition));
            StateMachineAudio.Instance.HandleStandBy();
            ObjectsManager.Instance.AdjustObject(true);
        }
    }
}
