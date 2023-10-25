using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    [SerializeField] AudioClip ObjectName;
    GameManager _gameManager;
    AudioSource _audioSource;
    public bool Clickable { get; set; } = false;
    Transform _transform;
    private void Awake()
    {
        _transform = transform;
        _audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        _gameManager = GameManager.Instance;
    }
    public void Click()
    {
        if (Clickable)
        {
            _gameManager.Target = this;
            _gameManager.UpdateGameState(GameState.Hooking);
        }
    }
    public void PlaySound()
    {
        _audioSource.Play();
    }
    public void PlayName()
    {
        _audioSource.PlayOneShot(ObjectName);
    }
}
