using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    int score = 0;
    // [SerializeField] float growthRate = 1.0f;
    // float elapsedTime = 0.0f;
    // float increasedValue = 0f;
    
    
    private void OnCollisionEnter(Collision other) 
    {   
        if (!other.gameObject.tag.Equals("Hit"))    
        {
            score++;
;
        }
    }

    private void Start()
    {

    }

    private void Tester()
    {
        Debug.Log("Testing");
    }

}
