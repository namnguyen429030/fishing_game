using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    [SerializeField] GameObject PauseButton, ResumeButton, BackToHomeButton, ReplayButton, PauseScreen, VolumeSlider;
    Button _pauseButton, _resumeButton, _backToHomeButton, _replayButton;
    Slider _volumeSlider;
    public static GUIManager Instace { get; private set; }
    private void Awake()
    {
        if(Instace != null && Instace != this)
        {
            Destroy(this);
        }
        else
        {
            Instace = this;
        }
        _pauseButton = PauseButton.GetComponent<Button>();
        _resumeButton = ResumeButton.GetComponent<Button>();
        _backToHomeButton = BackToHomeButton.GetComponent<Button>();
        _replayButton = ReplayButton.GetComponent<Button>();
        _volumeSlider = VolumeSlider.GetComponent<Slider>();
    }
    private void Start()
    {
        _pauseButton.onClick.AddListener(()=>Pause());
        _resumeButton.onClick.AddListener(()=>Resume());
        _backToHomeButton.onClick.AddListener(() =>BackToHome());
        _replayButton.onClick.AddListener(()=>Replay());
    }
    public void Resume()
    {
        Time.timeScale = 1;
        AudioManager.Instance.ResumeSound();
        PauseButton.SetActive(true);
        PauseScreen.SetActive(false);
    }
    public void Replay()
    {
        GameManager.Instance.UpdateGameState(GameState.Replay);
    }
    public void Pause()
    {
        Time.timeScale = 0;
        AudioManager.Instance.PauseSound();
        PauseButton.SetActive(false);
        PauseScreen.SetActive(true);
    }
    public void BackToHome()
    {
        SceneManager.LoadScene("Home");
    }
    public void AdjustVolume()
    {
        AudioManager.Instance.AdjustMainVolume(_volumeSlider.value);
    }
}
