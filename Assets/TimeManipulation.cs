using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TimeManipulation : MonoBehaviour
{
    public InputActionProperty rewindButton;
    public float rewindSpeed = 2f;

    private bool isRewinding = false;
    private List<TransformData> transformDataList = new List<TransformData>();

    private void Update()
    {
        float rewindButtonDown = rewindButton.action.ReadValue<float>();
        // Check for user input to start or stop rewinding
        if (rewindButtonDown == 1)
        {
            if (!isRewinding)
                StartRewind();
        }

        if (rewindButtonDown == 0)
        {
            StopRewind();
        }

        // While rewinding, move the object backwards in time
        if (isRewinding)
            Rewind();
        else
            Record();
    }

    private void StartRewind()
    {
        isRewinding = true;
        // Disable physics or other interactions during rewinding if necessary
        GetComponent<Rigidbody>().isKinematic = true;
    }

    private void StopRewind()
    {
        isRewinding = false;
        // Enable physics or other interactions after rewinding if necessary
        GetComponent<Rigidbody>().isKinematic = false;
    }

    private void Rewind()
    {
        if (transformDataList.Count > 0)
        {
            // Get the most recent transform data
            TransformData latestTransformData = transformDataList[transformDataList.Count - 1];
            // Move the object towards the previous transform position
            transform.position = Vector3.Lerp(transform.position, latestTransformData.position, rewindSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, latestTransformData.rotation, rewindSpeed * Time.deltaTime);
            transform.localScale = Vector3.Lerp(transform.localScale, latestTransformData.scale, rewindSpeed * Time.deltaTime);
            // Remove the used transform data from the list
            transformDataList.RemoveAt(transformDataList.Count - 1);
        }
    }

    private void Record()
    {
        // Store the current transform data
        TransformData currentTransformData = new TransformData(transform.position, transform.rotation, transform.localScale);
        transformDataList.Add(currentTransformData);
    }

    private struct TransformData
    {
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;

        public TransformData(Vector3 pos, Quaternion rot, Vector3 sca)
        {
            position = pos;
            rotation = rot;
            scale = sca;
        }
    }
}