using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Abtractions
{
    public abstract class MoveableObject : MonoBehaviour
    {
        [SerializeField] float Speed;
    }
}
