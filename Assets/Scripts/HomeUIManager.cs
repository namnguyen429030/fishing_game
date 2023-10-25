using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeUIManager : MonoBehaviour
{
    [SerializeField] GameObject PlayButton, QuitButton;
    Button _playButton, _quitButton;
    private void Awake()
    {
        _playButton = PlayButton.GetComponent<Button>();
        _quitButton = QuitButton.GetComponent<Button>();
    }
    private void Start()
    {
        _playButton.onClick.AddListener(() => Play());
        _quitButton.onClick.AddListener(() => Quit());
    }
    public void Play()
    {
        SceneManager.LoadScene("Fishing Game", LoadSceneMode.Single);

    }
    public void Quit()
    {
        Application.Quit();
    }
}
