using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Mover : MonoBehaviour
{
    Rigidbody playerRigid;
    [SerializeField] float rotateMaster = 450f;
    [SerializeField] float slowSpin = 45f;
    [SerializeField] float rotateSpeed = 450f;
    [SerializeField] float declineRate = 0.1f;
    Gamepad gamepad;
    Vector2 moveInput;
    [SerializeField] bool doSpin = false;
    // [SerializeField] public float rotateSpeed = 145f;
    // float rotateMaster;
    // float rotateOff = 0f;
    [SerializeField] float moveSpeed = 1000f;
    void Start()
    {
        playerRigid = GetComponent<Rigidbody>();
        
        if (gamepad!= null) gamepad = Gamepad.current;
    }

    private void Update() {
        // if (gamepad.buttonSouth.isPressed)
        // {
        //     SceneManager.LoadScene(0);
        // }
    }

    private void FixedUpdate() 
    { 
        Run();    
        Spin();
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

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag.Equals("spin"))
        {
            rotateSpeed = rotateMaster;
            doSpin = true;
        }    

        if(other.gameObject.tag.Equals("stopspin"))
        {
            doSpin = false;
            rotateSpeed = rotateMaster;
        }  

        if(other.gameObject.tag.Equals("slowspin"))
        {
            rotateSpeed = slowSpin;
            doSpin = true;
        }  
    }

    void Spin()
    {
        if (doSpin)
        {
            // transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
            
            transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
            rotateSpeed = Mathf.Lerp(rotateSpeed, 0, declineRate * Time.deltaTime);
        }
        
        if (rotateSpeed < 2)
        {
            doSpin = false;
            rotateSpeed = rotateMaster;
        }
    }
}
