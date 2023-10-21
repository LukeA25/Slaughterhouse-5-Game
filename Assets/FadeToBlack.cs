using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    public float fadeDuration = 2.0f; // The duration in seconds for the fade effect

    private Image fadeImage;
    private CanvasGroup canvasGroup;

    private void Start()
    {
        fadeImage = GetComponent<Image>();
        canvasGroup = GetComponent<CanvasGroup>();

        StartCoroutine(Fade());
    }

    private System.Collections.IEnumerator Fade()
    {
        float elapsedTime = 0.0f;
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            canvasGroup.alpha = alpha;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the alpha reaches 1 to avoid any rounding errors
        canvasGroup.alpha = 1f;

        // Keep the image black after the fade is complete
        fadeImage.color = Color.black;
    }
}