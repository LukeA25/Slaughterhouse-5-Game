using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnterScript : MonoBehaviour
{
    public UnityEvent triggerEvent;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider that triggered the event is the player or any desired object
        if (other.CompareTag("Player"))
        {
            triggerEvent.Invoke();
        }
    }
}