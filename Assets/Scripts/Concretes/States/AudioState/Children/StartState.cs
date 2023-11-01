using Assets.Scripts.Concretes.Managers;
using Assets.Scripts.Enums;
using System;

namespace Assets.Scripts.Concretes.States.AudioState.Children
{
    public class StartState : AudioState
    {
        public override void PerformState()
        {
            int choice = new Random().Next(2);
            if (choice == 0)
            {
                AudioManager.Instance.PlaySfx(EnumAudioClip.FemaleGuiding);
            }
            else
            {
                AudioManager.Instance.PlaySfx(EnumAudioClip.MaleGuiding);
            }
        }
    }
}
