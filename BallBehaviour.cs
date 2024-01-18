using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    Transform objectTransform;
    Vector3 startingPosition;
    Rigidbody objectRigidbody;
    bool isCounting;
    [SerializeField] float countAmount = 3f;
    private float countStart = 0f;

    private void Start() 
    {
        objectTransform = GetComponent<Transform>();    
        objectRigidbody = GetComponent<Rigidbody>();
        startingPosition = objectTransform.position;
    }

    private void Update() 
    {
         if (countStart > 0f) StartCountToReset();
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag.Equals("Destructable"))
        {
            GameObject wall = other.gameObject;
            Destroy(gameObject);
            Destroy(wall);
            return;
        }

        if (other.gameObject.tag.Equals("Player"))
        {
            countStart = Time.time;
        }    
    }

    private void StartCountToReset()
    {
            // countStart += Time.deltaTime;
            float elapsedTime = Time.time - countStart;

            if (elapsedTime >= countAmount)
            {
                objectRigidbody.velocity = Vector3.zero;
                objectRigidbody.angularVelocity = Vector3.zero;
                objectTransform.position = startingPosition;
                countStart = 0f;
                Debug.Log("Resetting position!");
            }
    }
}
