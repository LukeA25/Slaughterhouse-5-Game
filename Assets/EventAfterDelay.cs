using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventAfterDelay : MonoBehaviour
{
    public float delayTime = 1f;
    public UnityEvent delayEvent;

    private void Start()
    {
        StartCoroutine(DelayEvent());
    }

    private IEnumerator DelayEvent()
    {
        yield return new WaitForSeconds(delayTime);

        delayEvent.Invoke();
    }
}