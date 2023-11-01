using UnityEngine;

namespace Assets.Scripts.Concretes.MoveableObjects
{
    public class BackgroundMovingRepeatedly : Abtractions.BackgroundMovingRepeatedly
    {
        private void Start()
        {
            material = GetComponent<Renderer>().material;
        }
        void Update()
        {
            offset += (Time.deltaTime * Speed) / 10f;
            material.SetTextureOffset("_MainTex", new Vector3(offset, 0, 0));
        }
    }
}
