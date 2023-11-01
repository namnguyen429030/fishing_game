using Assets.Scripts.Abtractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Interfaces
{
    public interface IAdjustClickableObject
    {
        void ChangeCondition(ClickableObject clickableObject, bool status);
        void MakeParent(ClickableObject clickableObject, MoveableObject moveableObject);
    }
}
