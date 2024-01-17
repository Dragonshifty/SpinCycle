using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSave : MonoBehaviour
{
    private bool hasSaved = false;
    private void OnTriggerEnter(Collider other) 
    {
        Debug.Log("Enter");
        if (other.gameObject.tag.Equals("Player"))
        {
        if (!hasSaved)
        {
            EventOverseer.InvokeSpawnPoint();
            hasSaved = true;
        }
        }
    }
}
