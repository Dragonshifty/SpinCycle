using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Mover : MonoBehaviour
{
    Rigidbody playerRigid;  
    Gamepad gamepad;
    Vector2 moveInput;

    [SerializeField] float moveSpeed = 1000f;
    void Start()
    {
        playerRigid = GetComponent<Rigidbody>();
        
        if (gamepad!= null) gamepad = Gamepad.current;
    }



    private void FixedUpdate() 
    { 
        Run();    
    }


    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Run()
    {
        // Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y);
        // playerRigid.velocity = movement * moveSpeed * Time.fixedDeltaTime;

    
    Vector3 cameraForward = Camera.main.transform.forward;
    Vector3 cameraRight = Camera.main.transform.right;

    cameraForward.y = 0f;
    cameraRight.y = 0f;

    cameraForward.Normalize();
    cameraRight.Normalize();

    Vector3 movement = (cameraForward * moveInput.y + cameraRight * moveInput.x).normalized;

    playerRigid.velocity = movement * moveSpeed * Time.fixedDeltaTime;
    }

}
