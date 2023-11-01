using Assets.Scripts.Concretes.Managers;
using Assets.Scripts.Concretes.StateMachines;
using Assets.Scripts.Enums;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.States.GameState.Children
{
    public class HookingState : GameState
    {
        protected override IEnumerator Sequence()
        {
            GameObject target = ObjectsManager.Instance.Target;
            float y = HookManager.Instance.GetHook().transform.position.y;
            float targetX = target.transform.position.x + 2.03f;
            float targetY = target.transform.position.y - 2f;
            Vector3 horizontal = new Vector3(targetX, y, 0);
            Vector3 vertical = new Vector3(targetX, targetY, 0);
            Vector3 mid = new Vector3(targetX, targetY + 3, 0);
            yield return StartCoroutine(HookManager.Instance.MoveObject(horizontal));
            yield return StartCoroutine(HookManager.Instance.MoveObject(vertical));
            HookManager.Instance.ChangeAnimation(EnumHookAnimation.Moc_gap_do_Open);
            ObjectsManager.Instance.SetTargetParent();
            yield return new WaitForSeconds(0.3f);
            HookManager.Instance.ChangeAnimation(EnumHookAnimation.Moc_gap_do_Close);
            ObjectsManager.Instance.TargetPlayEffect();
            yield return StartCoroutine(HookManager.Instance.MoveObject(mid));
            StateMachineGame.Instance.HandleReading();
        }
    }
}
