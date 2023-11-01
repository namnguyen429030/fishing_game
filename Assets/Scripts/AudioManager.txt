using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip Guiding_Male, Guiding_Female, Victory;
    [SerializeField] GameObject MainGame, Undersea, Hook, Cat;
    [SerializeField] List<GameObject> Objects;
    AudioSource _mainGamesource, _undersea, _audioSource;
    AudioSource[] _sources;

    public static AudioManager Instance { get; private set; }
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        _audioSource =GetComponent<AudioSource>();
        _mainGamesource = MainGame.GetComponent<AudioSource>();
        _undersea = Undersea.GetComponent<AudioSource>();
    }
    private void Start()
    {
        _sources = FindObjectsOfType<AudioSource>();
    }
    public void PauseSound()
    {
        foreach(AudioSource audio in  _sources)
        {
            audio.Pause();
        }
    }
    public void ResumeSound()
    {
        foreach (AudioSource audio in _sources)
        {
            audio.UnPause();
        }
    }
    public void AdjustMainMusic(float number)
    {
         _mainGamesource.volume += number;
    }
    public void StartUnderSeaSFX()
    {
        _undersea.Play();
    }
    public void StopUnderSeaSFX()
    {
        _undersea.Stop();
    }
    public void AdjustMainVolume(float number)
    {
        AudioListener.volume = number;
    }
    public void PlayVictory()
    {
        _audioSource.PlayOneShot(Victory);
    }
    public void PlayGuiding()
    {
        int choice = Random.Range(0,1);
        switch(choice)
        {
            case 0:
                _audioSource.PlayOneShot(Guiding_Male);
                break;
            case 1:
                _audioSource.PlayOneShot(Guiding_Female);
                break;
        }
    }
}

