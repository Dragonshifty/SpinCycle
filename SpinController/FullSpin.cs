using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullSpin : ISpin
{
    float spinSpeed = 1000f;
    public void SpinType(GameObject player, float declineRate)
    {
        if (spinSpeed > 2)
        {
            player.transform.Rotate(0, spinSpeed * Time.deltaTime, 0);
            spinSpeed = Mathf.Lerp(spinSpeed, 0, declineRate * Time.deltaTime);
        } else
        {
            player.transform.Rotate(0, 0, 0);
        }    
    }
}
