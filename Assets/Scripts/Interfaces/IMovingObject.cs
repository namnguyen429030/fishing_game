using Assets.Scripts.Abtractions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface IMovingObject
    {
        void Move(MoveableObject _object, Vector3 destination, float speed);
        void Move(Camera _camera, Vector3 destination, float speed);
    }
}

