using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    Transform objectTransform;
    Vector3 startingPosition;
    Rigidbody objectRigidbody;
    private bool hitOnce;
    private bool isColliding;
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
        if (isColliding) return;
        isColliding = true;
        if (other.gameObject.tag.Equals("Destructable"))
        {
            DestroyStuffs(other);
        }

        if (other.gameObject.tag.Equals("HitTwice"))
        {  
            if (hitOnce)
            {
                Debug.Log("Second hit");
                DestroyStuffs(other);
            } else
            {
                Debug.Log("First hit");
                hitOnce = true;
                ReSpawnBall();
            }
        }

        if (other.gameObject.tag.Equals("Player"))
        {
            countStart = Time.time;
        } 

        StartCoroutine(ResetIsColliding());   
    }

    private IEnumerator ResetIsColliding()
    {
        yield return new WaitForEndOfFrame();
        isColliding = false;
    }

    private void StartCountToReset()
    {
            float elapsedTime = Time.time - countStart;

            if (elapsedTime >= countAmount)
            {
                ReSpawnBall();
                countStart = 0f;
                Debug.Log("Resetting position!");
            }
    }

    private void ReSpawnBall()
    {
        objectTransform.position = startingPosition;
        objectRigidbody.velocity = Vector3.zero;
        objectRigidbody.angularVelocity = Vector3.zero;
        
    }

    private void DestroyStuffs(Collision other)
    {
        GameObject wall = other.gameObject;
        if (wall.gameObject.tag.Equals("HitTwice") ||  wall.gameObject.tag.Equals("Destructable"))
        {
            Debug.Log("Destroy");
            Destroy(gameObject);
            Destroy(wall);
        }  
    }

}
