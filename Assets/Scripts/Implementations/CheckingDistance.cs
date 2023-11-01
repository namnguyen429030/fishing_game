using Assets.Scripts.Abtractions;
using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Implementations
{
    public class CheckingDistance : ICheckingDistance
    {
        public bool IsArrived(MoveableObject _object, Vector3 destination)
        {
            return Vector3.Distance(_object.transform.position, destination) < 0.01f;
        }

        public bool IsArrived(Camera _camera, Vector3 destination)
        {
            return Vector3.Distance(_camera.transform.position, destination) < 0.01f;
        }
    }
}
