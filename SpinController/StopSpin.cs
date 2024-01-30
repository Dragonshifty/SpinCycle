using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSpin : ISpin
{
    public void SpinType(GameObject player, float declineRate)
    {
        player.transform.Rotate(0, 0, 0);
    }
}
