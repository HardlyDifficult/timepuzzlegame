using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TimeMachine : MonoBehaviour
{
    public GameObject pastCharacterPrefab;
    Config config;

    void Start()
    {
        config = FindObjectOfType<Config>();
    }

    public void OnAction(InputValue action)
    {
        if (action.isPressed)
        {
            config.timeStep = -1;

            Instantiate(pastCharacterPrefab);
        }
        else
        {
            config.timeStep = 1;
        }
    }
}
