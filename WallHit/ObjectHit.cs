using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    SpawnPoints spawnPoints;
    private void Start() 
    {
        // EventOverseer.Instance.WallHit += Tester;  
        spawnPoints = FindObjectOfType<SpawnPoints>();  
    }
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag.Equals("Player"))
        {
        GetComponent<MeshRenderer>().material.color = Color.red;
        gameObject.tag = "Hit";
        // spawnPoints.GoToSpawn(EventOverseer.Instance.SpawnIndex);
        EventOverseer.InvokeWallHit(transform.position);
        }
    }


    private void Tester()
    {
        Debug.Log("Testing from Object Hit");
    }
}
