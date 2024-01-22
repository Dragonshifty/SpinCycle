using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    SpawnPoints spawnPoints;

    private void Awake() 
    {
        spawnPoints = FindObjectOfType<SpawnPoints>();    
    }

    private void OnEnable() 
    {
        EventOverseer.WallHit += HandleWallHit;
        EventOverseer.SpawnPoint += SetSpawnPoint;    
    }

    private void OnDisable() 
    {
        EventOverseer.WallHit -= HandleWallHit;
        EventOverseer.SpawnPoint -= SetSpawnPoint;
    }

    private void HandleWallHit(Vector3 wallHitPosition)
    {
        spawnPoints.GoToSpawn();
    }

    private void SetSpawnPoint()
    {
        spawnPoints.IncrementSpawnIndex();
    }
}
