using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    const int StandardScreenWidth = 2340;
    private Camera _camera;
    public static CameraManager Instance { get; private set; }
    public bool Reached { get; private set; }
    public CameraState State { get; private set; }
    private void Awake()
    {
        _camera = Camera.main;
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        if (Screen.width < StandardScreenWidth)
        {
            _camera.orthographicSize *= 1.2f;
        }
        State = CameraState.Waiting;
    }
    public void UpdateCameraState(CameraState state)
    {
        switch (state)
        {
            case CameraState.Waiting:
                break;
            case CameraState.BeginGame:
                HandleBeginGame();
                break;
            case CameraState.EndGame:
                HandleEndGame();
                break;
            default:
                throw new NotImplementedException();
        }
        State = state;
    }

    private void HandleEndGame()
    {
        StartCoroutine(MoveCam(0f));
    }

    private void HandleBeginGame()
    {
        StartCoroutine(MoveCam(-15f));
    }

    private IEnumerator MoveCam(float y) 
    {
        Reached = false;
        if (_camera.transform.position.y > y)
        {
            while (Camera.main.transform.position.y > y)
            {
                yield return new WaitForEndOfFrame();
                _camera.transform.position += new Vector3(0, -1, 0) * 5 * Time.deltaTime;
            }
        }
        else
        {
            while (Camera.main.transform.position.y < y)
            {
                yield return new WaitForEndOfFrame();
                _camera.transform.position += new Vector3(0, 1, 0) * 5 * Time.deltaTime;
            }
        }
        Reached = true;
        UpdateCameraState(CameraState.Waiting);
    }
}
public enum CameraState
{
    Waiting, 
    BeginGame,
    EndGame
}
