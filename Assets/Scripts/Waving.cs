using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waving : MonoBehaviour
{
    [SerializeField] float Max, Min, Speed;
    Transform _transform;
    float direction = 1;
    private void Awake()
    {
        _transform = transform;
    }
    // Update is called once per frame
    void Update()
    {
        if((direction == 1 && transform.position.y >= Max) || (direction == -1 && transform.position.y <= Min))
        {
            direction *= -1;
        }
        _transform.position += new Vector3(0,  direction, 0) * Time.deltaTime * Speed;
    }
}
