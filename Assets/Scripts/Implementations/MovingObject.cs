using Assets.Scripts.Abtractions;
using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Implementations
{
    public class MovingObject : IMovingObject
    {
        public void Move(MoveableObject _object, Vector3 destination, float speed)
        {
            Vector3 current = _object.transform.position;
            _object.transform.position = Vector3.MoveTowards(current, destination, speed * Time.deltaTime);
        }

        public void Move(Camera _camera, Vector3 destination, float speed)
        {
            Vector3 current = _camera.transform.position;
            _camera.transform.position = Vector3.MoveTowards(current, destination, speed * Time.deltaTime);
        }
    }
}
