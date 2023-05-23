using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tombstone : MonoBehaviour
{
    Config config;
    int frameIDied;

    void Start()
    {
        config = FindFirstObjectByType<Config>();
        frameIDied = config.currentFrame;
    }

    void FixedUpdate()
    {
        if (config.currentFrame < frameIDied)
        {
            Destroy(gameObject);
        }
    }
}
