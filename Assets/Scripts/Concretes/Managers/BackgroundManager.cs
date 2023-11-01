using Assets.Scripts.Abtractions;
using UnityEngine;

namespace Assets.Scripts.Concretes.Managers
{
    public class BackgroundManager : Manager
    {
        [SerializeField] GameObject Day, Dusk;
        public static BackgroundManager Instance { get; private set; }
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }
        public override void AdjustObject(bool status)
        {
            Day.SetActive(status);
            Dusk.SetActive(!status);
        }
    }
}
