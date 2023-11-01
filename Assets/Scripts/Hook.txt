using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField] float Speed;
    Transform _transform;
    GameObject _hook;
    SkeletonAnimation _skeleton;
    GameManager _gameManager;
    AudioSource _audioSource;
    Vector3 oldPosition;
    enum HookCondition
    {
        Moc_gap_do_Close,
        Moc_gap_do_Open,
        Moc_gap_do_wating
    }
    private void Awake()
    {
        _transform = transform;
        _skeleton = GetComponent<SkeletonAnimation>();
        _hook = gameObject;
        _audioSource = GetComponent<AudioSource>();
        oldPosition = new Vector3(_transform.position.x, _transform.position.y, _transform.position.z);
    }
    private void Start()
    {
        _gameManager = GameManager.Instance;
    }
    public IEnumerator DropHook()
    {
        _audioSource.Play();
        Vector3 direction = new Vector3(0, -1, 0);
        while (transform.position.y > -16) 
        {
            yield return new WaitForEndOfFrame();
            _transform.position += direction * Time.deltaTime * Speed;
        }
        _audioSource.Stop();
    }
    public IEnumerator GrabHook()
    {
        bool atCenter = false;
        _audioSource.Play();
        Vector3 direction = new Vector3(0, 1, 0);
        while (transform.position.y < -9.38) 
        {
            yield return new WaitForEndOfFrame();
            _transform.position += direction * Time.deltaTime * Speed;
            if(transform.position.y >= -16 && !atCenter)
            {
                atCenter = true;
                _audioSource.Stop();
                _gameManager.UpdateGameState(GameState.Reading);
                yield return new WaitForSeconds(1.75f);
                _audioSource.Play();
            }
        }
        _gameManager.UpdateGameState(GameState.Repeat);
        _audioSource.Stop();
    }

    public IEnumerator MoveHook(Vector3 destinaton)
    {
        _audioSource.Play();
        bool arrived = false;
        Vector3 direct = new Vector3(1, 0, 0);
        while (!arrived)
        {
            yield return new WaitForEndOfFrame();
            if (destinaton.x < oldPosition.x)
            {
                if (_transform.position.x <= (destinaton.x + 2.03))
                {
                    arrived = true;
                }
                if (!arrived)
                {
                    _transform.position -= direct * Speed * Time.deltaTime;
                }
            }
            else if (destinaton.x > oldPosition.x)
            {
                if (_transform.position.x >= (destinaton.x + 2.03))
                {
                    arrived = true;
                }
                if (!arrived)
                {
                    _transform.position += direct * Speed * Time.deltaTime;
                }
            }
        }
        direct = new Vector3(0, 1, 0);
        while (_transform.position.y > (destinaton.y - 2f))
        {
            yield return new WaitForEndOfFrame();
            _transform.position -= direct * Speed * Time.deltaTime;
        }
        _skeleton.AnimationName = extractEnum(HookCondition.Moc_gap_do_Open);
        yield return new WaitForSeconds(0.2f);
        _skeleton.AnimationName = extractEnum(HookCondition.Moc_gap_do_Close);
        _audioSource.Stop();
        yield return new WaitForEndOfFrame();
    }
    public IEnumerator Retreat()
    {
        _skeleton.AnimationName = extractEnum(HookCondition.Moc_gap_do_wating);
        _transform.position = oldPosition;
        yield return StartCoroutine(DropHook());
    }
    private string extractEnum(HookCondition cond)
    {

        return cond.ToString().Replace("_", " ");
    }
}
