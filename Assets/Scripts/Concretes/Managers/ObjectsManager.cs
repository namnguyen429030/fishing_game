using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.ClickableObjects;
using Assets.Scripts.Implementations;
using Assets.Scripts.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Concretes.Managers
{
    public class ObjectsManager : Manager
    {
        [SerializeField] List<GameObject> Objects;
        public GameObject Target { get; private set; }
        public ClickableObject target { get; private set; }
        private IAdjustClickableObject adjustClickableObject;
        private int objectCount;
        public static ObjectsManager Instance { get; private set; }
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
            adjustClickableObject = new AdjustClickableObject();
            objectCount = Objects.Count;
        }
        public void SetTarget(GameObject clickableObject)
        {
            Target = clickableObject;
            target = Target.GetComponent<ReadingNameObject>(); 
        }
        public List<GameObject> GetObjects() 
        { 
            return Objects; 
        }
        public int GetObjectCount()
        {
            return objectCount;
        }
        public int MinusCount()
        {
            return --objectCount;
        }
        public override void AdjustObject(bool status)
        {
            foreach (GameObject obj in Objects)
            {
                adjustClickableObject.ChangeCondition(obj.GetComponent<ClickableObject>(), status);
            }
        }
        public void TargetPlayEffect()
        {
            target.PlayEffect();
        }
        public void SetTargetParent()
        {
            adjustClickableObject.MakeParent(target, HookManager.Instance.hook);
        }
        public void DisAbleTarget()
        {
            Target.SetActive(false);
        }
    }
}
