using Assets.Scripts.Interfaces;
using Spine.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Implementations
{
    public class ChangeAnimation : IChangeAnimation
    {
        public void SwitchAnimation(SkeletonAnimation skeleton, string[] animationList, int place)
        {
            skeleton.AnimationName = animationList[place];
        }
    }
}
