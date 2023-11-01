using UnityEngine;

namespace Assets.Scripts.Abtractions
{
    public abstract class BackgroundMovingRepeatedly : MonoBehaviour
    {
        [SerializeField] protected float Speed;
        protected Material material;
        protected float offset;
    }
}
