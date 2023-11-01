using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Concretes.States.CameraState
{
    public class StartState : CameraState
    {
        protected override void Start()
        {
            base.Start();
            destination = new Vector3(0, -15f, -10);
        }
    }
}
