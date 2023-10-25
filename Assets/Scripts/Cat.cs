using Spine;
using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float Speed;
    Transform _transform;
    GameManager _gameManager;
    SkeletonAnimation _skeleton;
    AudioSource _audioSource;
    private void Awake()
    {
        _transform = transform;
        _skeleton = GetComponent<SkeletonAnimation>();
        _audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        _gameManager = GameManager.Instance;
    }
    public IEnumerator CatMove(Vector3 destination)
    {
        while(transform.position.x < destination.x)
        {
            yield return new WaitForEndOfFrame();
            _transform.position += new Vector3(1, 0, 0) * Speed * Time.deltaTime;
        }
    }
    
    public IEnumerator Ending()
    {
        _skeleton.AnimationName = "Ending";
        _audioSource.Play();
        yield return new WaitForSeconds(10f);
        _skeleton.AnimationName = "Bien mat";
    }
}
