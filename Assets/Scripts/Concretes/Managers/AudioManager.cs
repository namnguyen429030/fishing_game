using Assets.Scripts.Abtractions;
using Assets.Scripts.Implementations;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Enums;
using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts.Concretes.Managers
{
    public class AudioManager : Manager
    {
        [SerializeField] List<AudioClip> BackgroundClips;
        [SerializeField] List<AudioClip> ObjectClips;
        [SerializeField] GameObject Undersea;
        IPlayingObjectSfx playingObjectSfx;
        AudioClip[] audioClips;
        public AudioSource HostSource { get; private set; }
        public AudioSource UnderseaAudioSource { get; private set; }
        public AudioSource HookAudioSource{ get; private set; }
        public AudioSource CatAudioSource{ get; private set; }
        public static AudioManager Instance { get; private set; }
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
        private void Start()
        {
            HostSource = GetComponent<AudioSource>();
            UnderseaAudioSource = Undersea.GetComponent<AudioSource>();
            HookAudioSource = HookManager.Instance.GetHook().GetComponent<AudioSource>();
            CatAudioSource = CatManager.Instance.GetCat().GetComponent<AudioSource>();
            playingObjectSfx = new PlayingObjectSfx();
            audioClips = BackgroundClips.ToArray();
            PlaySfx(HostSource);
        }
        public override void AdjustObject(bool status)
        {
            throw new System.NotImplementedException();
        }
        public void PlaySfx(AudioSource audioSource)
        {
            playingObjectSfx.PlaySfx(audioSource);
        }
        public void PlaySfx(AudioClip audioClip)
        {
            playingObjectSfx.PlaySfx(HostSource, audioClip);
        }
        public void PlaySfx(EnumAudioClip clipEnum)
        {
            playingObjectSfx.PlaySfx(HostSource, audioClips[(int)clipEnum]);
        }
        public void PlaySfx(GameObject target)
        {
            foreach (AudioClip clip in ObjectClips) 
            {
                if(clip.name == target.name)
                {
                    PlaySfx(clip); break;
                }
            }
        }
    }
}
