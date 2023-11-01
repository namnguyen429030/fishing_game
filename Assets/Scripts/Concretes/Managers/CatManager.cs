using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.MoveableObjects;
using Assets.Scripts.Enums;
using Assets.Scripts.Implementations;
using Assets.Scripts.Interfaces;
using Spine.Unity;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Concretes.Managers
{
    public class CatManager : Manager
    {
        [SerializeField] GameObject Cat;
        public static CatManager Instance { get; private set; }
        readonly string[] animations = {"Starting", "Ending", "Bien mat" };
        public MoveableObject cat { get; private set; }
        SkeletonAnimation _skeletonAnimation;
        IChangeAnimation changeAnimation;
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
            cat = Cat.GetComponent<ManuallyMoveableObject>();
        }
        private void Start()
        {
            cat = Cat.GetComponent<ManuallyMoveableObject>();
            _skeletonAnimation = Cat.GetComponent<SkeletonAnimation>();
            changeAnimation = new ChangeAnimation();
        }
        public GameObject GetCat() { return Cat; }
        public IEnumerator MoveObject(Vector3 destination)
        {
            yield return StartCoroutine(cat.Move(destination));
        }
        public override void AdjustObject(bool status)
        {
            throw new System.NotImplementedException();
        }
        public void ChangeAnimation(EnumCatAnimation enumaration)
        {
            changeAnimation.SwitchAnimation(_skeletonAnimation, animations, (int)enumaration);
        }
    }
}
