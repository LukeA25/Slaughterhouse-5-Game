using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class PlayWalkingSound : MonoBehaviour
{
    public UnityEvent playSound;
    public UnityEvent stopSound;
    public InputActionProperty moveInput;
    bool isMoving = false;

    void Update()
    {
        if (moveInput.action.ReadValue<Vector2>().magnitude > 0.0f)
        {
            if (!isMoving)
            {
                isMoving = true;
                playSound.Invoke();
            }
        } else
        {
            isMoving = false;
            stopSound.Invoke();
        }
    }
}
