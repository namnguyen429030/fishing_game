using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Concretes.States.AudioState.Children
{
    public class ReadingState : AudioState
    {
        public override void PerformState()
        {
            AudioManager.Instance.PlaySfx(ObjectsManager.Instance.Target);
        }
    }
}
