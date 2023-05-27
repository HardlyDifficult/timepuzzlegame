using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    TNT tnt;
    int frameCutAt = -1;

    Config config;

    void Start()
    {
        config = FindFirstObjectByType<Config>();
        tnt = GetComponentInParent<TNT>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (frameCutAt >= 0)
        {
            return;
        }
        frameCutAt = config.currentFrame;

        Debug.Log("Wire");
        tnt.connectedWires--;
    }

    private void FixedUpdate()
    {
        if (frameCutAt >= 0 && config.currentFrame < frameCutAt)
        {
            // Reset
            frameCutAt = -1;
        }
    }
}
