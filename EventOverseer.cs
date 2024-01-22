using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class EventOverseer 
{
    public static event Action<Vector3> WallHit;
    public static event Action SpawnPoint;
    public static event Action CombinationUnlocked;


    public static void InvokeWallHit(Vector3 position)
    {
        WallHit.Invoke(position);
    }

    public static void InvokeSpawnPoint()
    {
        SpawnPoint?.Invoke();
    }

    public static void InvokeCombinationUnlocked()
    {
        CombinationUnlocked?.Invoke();
    }
    
}
