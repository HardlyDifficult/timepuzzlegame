using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TimeMachine : MonoBehaviour
{
    public GameObject pastCharacterPrefab;
    Config config;
    CurrentTimeline timeline;

    void Start()
    {
        config = FindObjectOfType<Config>();
        timeline = FindFirstObjectByType<CurrentTimeline>();
    }

    public void OnAction(InputValue action)
    {
        if (action.isPressed)
        {
            config.timeStep = -timeline.rewindSpeed;

            Instantiate(pastCharacterPrefab);
        }
        else
        {
            config.timeStep = 1;
        }
    }
}
