using Assets.Scripts.Concretes.Managers;
using Assets.Scripts.Concretes.StateMachines;
using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Concretes.States.AudioState.Children
{
    public class StandbyState : AudioState
    {
        public async override void PerformState()
        {
            int oldToken = StateMachineAudio.Instance.Token;
            await Task.Delay(500);
            while (StateMachineAudio.Instance.GetCurrentState() is StandbyState)
            {
                await Task.Delay(10000);
                if (StateMachineAudio.Instance.GetCurrentState() is StandbyState && oldToken == StateMachineAudio.Instance.Token)
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
                else
                {
                    break;
                }
            }
        }
    }
}
