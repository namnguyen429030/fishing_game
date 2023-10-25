using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    [SerializeField] float Speed;
    Material material;
    float offset;
    private void Start()
    {
        material = GetComponent<Renderer>().material;
    }
    void Update()
    {
        offset += (Time.deltaTime * Speed) / 10f;
        material.SetTextureOffset("_MainTex", new Vector3(offset, 0, 0));
    }
}
