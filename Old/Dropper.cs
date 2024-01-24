using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    Rigidbody rigid;
    MeshRenderer meshBody;
    [SerializeField] float waitTime = 3f;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        meshBody = GetComponent<MeshRenderer>();
        rigid.useGravity = false;
        meshBody.enabled = false;
    }

    void Update()
    {
        if (Time.time > waitTime)
        {
            rigid.useGravity = true;
            meshBody.enabled = true;
        }
    }
}
