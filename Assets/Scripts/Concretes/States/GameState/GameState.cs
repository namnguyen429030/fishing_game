using Assets.Scripts.Abtractions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Concretes.States.GameState
{
    public abstract class GameState : State
    {
        public override void PerformState()
        {
            StartCoroutine(Sequence());
        }
        protected abstract IEnumerator Sequence();
    }
}
