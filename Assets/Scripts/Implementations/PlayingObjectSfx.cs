using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Implementations
{
    public class PlayingObjectSfx : IPlayingObjectSfx
    {
        public void PlaySfx(AudioSource target)
        {
            target.Play();
        }

        public void PlaySfx(AudioSource source, AudioClip clip)
        {
            source.PlayOneShot(clip);
        }
    }
}
