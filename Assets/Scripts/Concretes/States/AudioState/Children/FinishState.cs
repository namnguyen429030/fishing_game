using Assets.Scripts.Concretes.Managers;
using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Concretes.States.AudioState.Children
{
    public class FinishState : AudioState
    {
        public override void PerformState()
        {
            AudioManager.Instance.PlaySfx(EnumAudioClip.Victory);
        }
    }
}
