using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    Transform player;
    private int spawnIndex;

    [SerializeField] List<Transform> spawns;
    [SerializeField] Transform spawnOne;

    private void Awake() 
    {
        if (spawns == null)
        {
            spawns = new List<Transform>();
        }
        player = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    public void IncrementSpawnIndex()
    {
        spawnIndex++;
    }
    public void GoToSpawn()
    {
        player.position = spawns[spawnIndex].position;
    }
}
