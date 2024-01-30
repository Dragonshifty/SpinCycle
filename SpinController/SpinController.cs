using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinController : MonoBehaviour
{
    float declineRate = 0.6f;
    [SerializeField] float fastDecline = 0.6f;
    [SerializeField] float slowDecline = 0.3f;
    private bool isControlling;
    ISpin ispin = new StopSpin();

    private void FixedUpdate() 
    {
        ispin.SpinType(gameObject, declineRate);
        TakeControl();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("spin"))
        {
            declineRate = fastDecline;
            ispin = new FullSpin();
        }

        if (other.gameObject.tag.Equals("stopspin"))
        {
            ispin = new StopSpin();
        }

        if (other.gameObject.tag.Equals("slowspin"))
        {
            declineRate = slowDecline;
            ispin = new SlowSpin();
        }    
    }

    private void TakeControl()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            ispin = new ControlSpin();
        }
    }
 
}
