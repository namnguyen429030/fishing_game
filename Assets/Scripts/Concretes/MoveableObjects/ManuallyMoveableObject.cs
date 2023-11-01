using Assets.Scripts.Abtractions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using UnityEngine;

namespace Assets.Scripts.Concretes.MoveableObjects
{
    public class ManuallyMoveableObject : MoveableObject
    {
        public override IEnumerator Move(Vector3 destination)
        {

            while (!_checkingDistance.IsArrived(this, destination))
            {
                yield return new WaitForEndOfFrame();
                _movingObject.Move(this, destination, Speed);
            }
        }
    }
}
