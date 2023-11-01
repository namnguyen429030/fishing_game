using Assets.Scripts.Implementations;
using Assets.Scripts.Interfaces;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Abtractions
{
    public abstract class MoveableObject : MonoBehaviour
    {
        [SerializeField] protected float Speed;
        protected Transform _transform;
        protected IMovingObject _movingObject;
        protected ICheckingDistance _checkingDistance;
        private void Awake()
        {
            _transform = transform;
            _movingObject = new MovingObject();
            _checkingDistance = new CheckingDistance();
        }
        protected virtual void Update()
        {
             
        }
        public abstract IEnumerator Move(Vector3 destination);
    }
}
