using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    public int timeStep = 1;

    public int currentFrame;

    private void FixedUpdate()
    {
        currentFrame += timeStep;
        if (currentFrame < 0)
        {
            currentFrame = 0;
        }
    }
}
