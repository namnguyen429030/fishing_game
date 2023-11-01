using Assets.Scripts.Abtractions;
using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Implementations
{
    public class AdjustClickableObject : IAdjustClickableObject
    {
        public void ChangeCondition(ClickableObject clickableObject, bool status)
        {
            clickableObject.IsClickAble = status;
        }

        public void MakeParent(ClickableObject clickableObject, MoveableObject moveableObject)
        {
            clickableObject.transform.parent = moveableObject.transform;
        }
    }
}
