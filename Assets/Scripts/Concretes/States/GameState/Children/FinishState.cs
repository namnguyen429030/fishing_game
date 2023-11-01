using Assets.Scripts.Concretes.Managers;
using Assets.Scripts.Concretes.StateMachines;
using Assets.Scripts.Enums;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.States.GameState
{
    public class FinishState : GameState
    {
        protected override IEnumerator Sequence()
        {
            HookManager.Instance.AdjustObject(false);
            StateMachineBackground.Instance.HandleFinish();
            yield return new WaitForSeconds(1.5f);
            StateMachineCamera.Instance.HandleFinish();
            yield return new WaitForSeconds(3);
            CatManager.Instance.ChangeAnimation(EnumCatAnimation.Ending);
            yield return new WaitForSeconds(10);
            CatManager.Instance.ChangeAnimation(EnumCatAnimation.Bien_mat);
            yield return StartCoroutine(CatManager.Instance.MoveObject(new Vector3(14, -1.95f, 0)));
            Debug.Log("End");
        }
    }
}
