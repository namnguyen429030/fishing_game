using Spine.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interfaces
{
    public interface IChangeAnimation
    {
        void SwitchAnimation(SkeletonAnimation skeleton, string[] animationList, int place);
    }
}
