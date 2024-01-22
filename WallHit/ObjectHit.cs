using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    [SerializeField] bool hitTwice;
    private void OnCollisionEnter(Collision other) 
    {
        
        if (other.gameObject.tag.Equals("Player"))
        {
            if (!hitTwice) GetComponent<MeshRenderer>().material.color = Color.red;
            gameObject.tag = "Hit";
            EventOverseer.InvokeWallHit(transform.position);
        }

        if (hitTwice)
        {
            GetComponent<MeshRenderer>().material.color = Color.grey;
        }
    }
}
