using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] float Speed;
    Transform _transform;
    int direction = 1;
    private void Awake()
    {
        _transform = transform;
    }
    private void Update()
    {
        _transform.position += new Vector3(direction, 0, 0) * Time.deltaTime * Speed;
        if (transform.position.x >= 9 || transform.position.x <= -10)
        {
            direction *= -1;
            _transform.Rotate(new Vector3(0, 180, 0));
        }
    }
}
