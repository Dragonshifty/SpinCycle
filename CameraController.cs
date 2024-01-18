using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
   Vector3 rotationVector = new Vector3(0, 0, 0);

    private void Update() 
    {
        if (Input.GetKey(KeyCode.Q))
        {
            rotationVector.y = -1f;
        } else if (Input.GetKey(KeyCode.E))
        {
            rotationVector.y = +1f;
        } else
        {
            rotationVector.y = 0f;
        }

        float rotationSpeed = 100f;

        transform.eulerAngles += rotationVector * rotationSpeed * Time.deltaTime;
    }

   
}
