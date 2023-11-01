using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Hook, Cat, Dusk, Day;
    [SerializeField] List<GameObject> Objects = new List<GameObject>();
    List<Object> _objects = new List<Object>();
    Cat _cat;
    Hook _hook;
    CameraManager _cameraManager;
    MeshRenderer _hookRenderer;
    AudioManager _audioManager;
    public static GameManager Instance { get; private set; }
    public GameState State { get; private set; }
    public Object Target { get; set; }
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
        _audioManager = AudioManager.Instance;
        _cat = Cat.GetComponent<Cat>();
        _cameraManager = CameraManager.Instance;
        _hook = Hook.GetComponent<Hook>();
        _hookRenderer = Hook.GetComponent<MeshRenderer>();
        _objects = Objects.Select(o => o.GetComponent<Object>()).ToList();
        UpdateGameState(GameState.Start);
    }
    public void UpdateGameState(GameState state)
    {
        State = state;
        switch (state)
        {
            case GameState.Start:
                StartCoroutine(HandleGameStart());
                break;
            case GameState.StandBy:
                StartCoroutine(HandleStandBy());
                break;
            case GameState.Hooking:
                StartCoroutine(HandleHooking());
                break;
            case GameState.Reading:
                StartCoroutine(HandleReading());
                break;
            case GameState.Repeat:
                StartCoroutine (HandleRepeat());
                break;
            case GameState.Replay:
                HandleReplay();
                break;
            case GameState.Finish:
                StartCoroutine(HandleFinish());
                break;
            default: 
                throw new NotImplementedException();
        }
    }

    private void HandleReplay()
    {
        StopAllCoroutines();
        SceneManager.LoadScene("Fishing game", LoadSceneMode.Single);
    }
    private IEnumerator HandleFinish()
    {
        AudioManager.Instance.PlayVictory();
        Dusk.SetActive(true);
        Day.SetActive(false);
        _hookRenderer.enabled = false;
        yield return new WaitForSeconds(2f);
        CameraManager.Instance.UpdateCameraState(CameraState.EndGame);
        yield return new WaitUntil(() => CameraManager.Instance.Reached);
        _audioManager.StopUnderSeaSFX();
        yield return StartCoroutine(_cat.Ending());
        yield return StartCoroutine(_cat.CatMove(new Vector3(14, -1.95f, 0)));
        SceneManager.LoadScene("Home", LoadSceneMode.Single);
    }
    private IEnumerator HandleRepeat()
    {
        if (_objects.Count > 0)
        {
            yield return StartCoroutine(_hook.Retreat());
            UpdateGameState(GameState.StandBy);
        }
        else
        {
            UpdateGameState(GameState.Finish);
        }
    }
    private IEnumerator HandleReading()
    {
        yield return new WaitForSeconds(0.5f);
        Target.PlayName();
        yield return new WaitForSeconds(3.5f);
        Target.gameObject.SetActive(false);
    }
    private IEnumerator HandleHooking()
    {
        ChangeObjectsClickable(false);
        yield return StartCoroutine(_hook.MoveHook(Target.transform.position));
        Target.gameObject.transform.parent = _hook.transform;
        _objects.Remove(Target);
        Target.PlaySound();
        yield return StartCoroutine(_hook.GrabHook());
    }

    private IEnumerator HandleStandBy()
    {
        Target = null;
        ChangeObjectsClickable(true);
        while (State == GameState.StandBy)
        {
            yield return new WaitForSeconds(10f);
            if (State == GameState.StandBy)
            {
                _audioManager.PlayGuiding();
            }
            else
            {
                break;
            }
        }
        Debug.Log("End");
    }

    private IEnumerator HandleGameStart()
    {
        _audioManager.AdjustMainMusic(-0.75f);
        yield return new WaitForSeconds(2f);
        yield return StartCoroutine(_cat.CatMove(new Vector3(0, -1.95f, 0)));
        yield return new WaitForSeconds(0.75f);
        CameraManager.Instance.UpdateCameraState(CameraState.BeginGame);
        _audioManager.StartUnderSeaSFX();
        yield return new WaitForSeconds(1.5f);
       _hookRenderer.enabled = true;
        yield return StartCoroutine(_hook.DropHook());
        _audioManager.PlayGuiding();
        yield return new WaitForSeconds(4f);
        UpdateGameState(GameState.StandBy);
    }
    private void ChangeObjectsClickable(bool cond)
    {
        foreach (var obj in _objects)
        {
            obj.Clickable = cond;
        }
    }
}

public enum GameState
{
    Start,
    StandBy,
    Hooking,
    Reading,
    Repeat,
    Replay,
    Finish
}
