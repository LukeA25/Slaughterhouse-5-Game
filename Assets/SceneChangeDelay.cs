using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeDelay : MonoBehaviour
{
    public float delayTime = 5f;
    public string sceneName;

    private void Start()
    {
        StartCoroutine(DelaySceneChange());
    }

    private IEnumerator DelaySceneChange()
    {
        yield return new WaitForSeconds(delayTime);

        SceneManager.LoadScene(sceneName);
    }
}