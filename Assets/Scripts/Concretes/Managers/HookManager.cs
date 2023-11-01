using Assets.Scripts.Abtractions;
using Assets.Scripts.Enums;
using Assets.Scripts.Implementations;
using Assets.Scripts.Interfaces;
using Spine.Unity;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.Managers
{
    public class HookManager : Manager
    {
        [SerializeField] GameObject Hook;
        public static HookManager Instance { get; private set; }
        MeshRenderer _renderer;
        SkeletonAnimation _skeletonAnimation;
        public MoveableObject hook { get; private set; }
        IChangeAnimation changeAnimation;
        readonly string[] animations = { "Moc gap do wating", "Moc gap do Open", "Moc gap do Close" };
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
            _renderer = Hook.GetComponent<MeshRenderer>();
            hook = Hook.GetComponent<MoveableObject>();
            _skeletonAnimation = Hook.GetComponent<SkeletonAnimation>();
            changeAnimation = new ChangeAnimation();
        }
        public GameObject GetHook() { return Hook; }
        public IEnumerator MoveObject(Vector3 destination)
        {
            yield return StartCoroutine(hook.Move(destination));
        }
        public void Place(Vector3 destination)
        {
            Hook.transform.position = destination;
        }
        public override void AdjustObject(bool status)
        {
            _renderer.enabled = status;
        }
        public void ChangeAnimation(EnumHookAnimation enumaration)
        {
            changeAnimation.SwitchAnimation(_skeletonAnimation, animations, (int)enumaration);
        }
    }
}
