using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    Config config;
    int framePickup = -1;
    Vector3 originalPosition;
    Quaternion originalRotation;

    void Awake()
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
                var newKey = Instantiate(gameObject, originalPosition, originalRotation);
                newKey.GetComponent<Collider>().enabled = true;

                framePickup = -1;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Touch(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Touch(collision.gameObject);
    }

    private void Touch(GameObject other)
    {
        if (config.timeStep < 0)
        {
            // No pickup while traveling backwards
            return;
        }

        transform.SetParent(other.transform);
        GetComponent<Collider>().enabled = false;
        framePickup = config.currentFrame;
    }
}
