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
    public class FinishState : CameraState
    {
        protected override void Start()
        {
            base.Start();
            destination = new Vector3(0, 0, -10);
        }
    }
}
