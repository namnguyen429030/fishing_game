using Assets.Scripts.Abtractions;
using Assets.Scripts.Implementations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Concretes.MoveableObjects
{
    public class AutomatedlyMoveableObject : MoveableObject
    {
        [SerializeField] Vector3 direction;
        [SerializeField] float MinX, MaxX;

        public override IEnumerator Move(Vector3 destination)
        {
            throw new NotImplementedException();
        }

        protected override void Update()
        {
            _transform.position += direction * Time.deltaTime * Speed;
            if (transform.position.x >= MaxX || transform.position.x <= MinX)
            {
                direction *= -1;
                _transform.Rotate(new Vector3(0, 180, 0));
            }
        }
    }
}
