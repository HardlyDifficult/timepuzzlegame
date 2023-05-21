using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    Config config;
    int framePickup = -1;
    Vector3 originalPosition;
    Quaternion originalRotation;

    void Start()
    {
        config = FindFirstObjectByType<Config>();
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    void FixedUpdate()
    {
        if (framePickup >= 0)
        {
            if (config.currentFrame == framePickup)
            {
                // Clone back to the original position
                Instantiate(gameObject, originalPosition, originalRotation);

                framePickup = -1;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.SetParent(other.transform);
        GetComponent<Collider>().enabled = false;
        framePickup = config.currentFrame;
    }
}
