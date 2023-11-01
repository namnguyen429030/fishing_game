using Assets.Scripts.Abtractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface ICheckingDistance
    {
        bool IsArrived(MoveableObject _object, Vector3 destination);
        bool IsArrived(Camera _camera, Vector3 destination);
    }
}
