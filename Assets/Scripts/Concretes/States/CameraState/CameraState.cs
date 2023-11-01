using Assets.Scripts.Abtractions;
using Assets.Scripts.Implementations;
using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Concretes.States.CameraState
{
    public abstract class CameraState : State
    {
        protected IMovingObject _movingObject;
        protected ICheckingDistance _checkingDistance;
        protected Vector3 destination;
        protected virtual void Start()
        {
            
        }
        public override void PerformState()
        {
            StartCoroutine(Sequence());
        }
        protected IEnumerator Sequence()
        {
            _movingObject = new MovingObject();
            _checkingDistance = new CheckingDistance();
            while (!_checkingDistance.IsArrived(Camera.main, destination))
            {
                yield return new WaitForEndOfFrame();
                _movingObject.Move(Camera.main, destination, 5);
            }
        }
    }
}
