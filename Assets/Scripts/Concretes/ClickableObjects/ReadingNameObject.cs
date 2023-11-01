using Assets.Scripts.Abtractions;
using Assets.Scripts.Concretes.Managers;
using Assets.Scripts.Concretes.StateMachines;
using UnityEngine;

namespace Assets.Scripts.Concretes.ClickableObjects
{
    public class ReadingNameObject : ClickableObject
    {
        [SerializeField] AudioSource _audioSource;
        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }
        public override void Click()
        {
            if (IsClickAble)
            {
                ObjectsManager.Instance.SetTarget(gameObject);
                StateMachineGame.Instance.HandleHooking();
                ObjectsManager.Instance.MinusCount();
                ObjectsManager.Instance.AdjustObject(false);
            }
        }
        public override void PlayEffect()
        {
            AudioManager.Instance.PlaySfx(_audioSource);
        }
    }
}
