using Assets.Scripts.Abtractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Concretes.StateMachines
{
    internal class StateMachineUI : StateMachine
    {
        public StateMachineUI Instance {  get; private set; }
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }
        public override void HandleFinish()
        {
            throw new NotImplementedException();
        }

        public override void HandleStart()
        {
            throw new NotImplementedException();
        }
    }
}
