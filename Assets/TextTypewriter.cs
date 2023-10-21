using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class TextTypewriter : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float typingSpeed = 0.1f;
    public float pauseDuration = 1.0f;
    public UnityEvent onTriggerEvent;

    private string targetText = "Billy has become...\nunstuck in time";
    private string currentText = "";
    private bool isTyping = false;

    private void Start()
    {
        textMeshPro.text = "";
    }

    private void Update()
    {
        if (isTyping)
            return;

        if (currentText != targetText)
        {
            isTyping = true;
            StartCoroutine(TypeText());
        }
    }

    private System.Collections.IEnumerator TypeText()
    {
        for (int i = 0; i <= targetText.Length; i++)
        {
            currentText = targetText.Substring(0, i);
            textMeshPro.text = currentText;

            if (i == targetText.Length)
                yield return new WaitForSeconds(pauseDuration);
            else
                yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
        onTriggerEvent.Invoke();
    }
}