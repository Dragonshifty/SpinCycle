using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    Transform objectTransform;
    Vector3 startingPosition;
    Rigidbody objectRigidbody;
    private bool hitOnce;
    private bool delayRunning;
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
            DestroyStuffs(other);
            return;
        }

        if (other.gameObject.tag.Equals("HitTwice"))
        {
            if (!delayRunning) StartCoroutine(DelayHit(other));
            
            
            // if (!hitOnce)
            // {
            //     Debug.Log("First hit");
            //     hitOnce = true;
            //     ReSpawnBall();
            //     return;
            // }
            
        }

        if (other.gameObject.tag.Equals("Player"))
        {
            countStart = Time.time;
        }    
    }


    private IEnumerator DelayHit(Collision other)
    {
        delayRunning = true;
        yield return new WaitForSeconds(0.2f);
        delayRunning = false;

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

    private void StartCountToReset()
    {
            // countStart += Time.deltaTime;
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
            StartCoroutine(DestroyWallDelayed(wall));
            // Destroy(wall);
        }
        
    }

    private IEnumerator DestroyWallDelayed(GameObject wall)
    {
        yield return new WaitForFixedUpdate(); 
        Destroy(wall);
    }
}
