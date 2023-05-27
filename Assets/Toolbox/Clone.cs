using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    Config config;

    private void Start()
    {
        config = FindFirstObjectByType<Config>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Character>() == null)
        {
            // Ignore if not the main character
            return;
        }

        if (config.timeStep > 0)
        {
            // Ignore if going forward in time
            return;
        }

        GetComponent<Collider>().isTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Character>() == null)
        {
            // Ignore if not the main character
            return;
        }

        GetComponent<Collider>().isTrigger = false;
    }
}
