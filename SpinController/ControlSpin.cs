using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSpin : ISpin
{
    float manualRotateSpeed;
    bool spinLeft;

    public void SpinType(GameObject player, float declineRate)
    {
        if (Input.GetKey(KeyCode.C))
        {
            manualRotateSpeed += 1000 * Time.deltaTime;
            player.transform.Rotate(0, manualRotateSpeed * Time.deltaTime, 0);
            spinLeft = true;
            declineRate = 1f;
        }

        if (Input.GetKey(KeyCode.Z))
        {
            manualRotateSpeed += 1000 * Time.deltaTime;
            player.transform.Rotate(0, -manualRotateSpeed * Time.deltaTime, 0);
            spinLeft = false;
            declineRate = 1f;
        }


        manualRotateSpeed = Mathf.Lerp(manualRotateSpeed, 0, declineRate * Time.deltaTime);

        if (spinLeft)
        {
            player.transform.Rotate(0, manualRotateSpeed * Time.deltaTime, 0);
        }
        else
        {
            player.transform.Rotate(0, -manualRotateSpeed * Time.deltaTime, 0);
        }
    }


}
