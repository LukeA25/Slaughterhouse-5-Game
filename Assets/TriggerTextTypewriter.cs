using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerTextTypewriter : MonoBehaviour
{
    public TextTypewriter textTypewriter;
    public UnityEvent triggerEvent;
    public UnityEvent onFinishTypingEvent;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            triggerEvent.Invoke();
            textTypewriter.onTriggerEvent.AddListener(OnTextTypewriterTriggered);
            textTypewriter.enabled = true;
        }
    }

    private void OnTextTypewriterTriggered()
    {
        textTypewriter.onTriggerEvent.RemoveListener(OnTextTypewriterTriggered);
        onFinishTypingEvent.Invoke();
    }
}