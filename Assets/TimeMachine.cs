using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TimeMachine : MonoBehaviour
{
    public GameObject pastCharacter;
    Config config;
    CharacterRecorder recorder;

    void Start()
    {
        config = FindObjectOfType<Config>();
        recorder = GetComponent<CharacterRecorder>();
    }

    public void OnAction(InputValue action)
    {
        if (action.isPressed)
        {
            config.timeStep = -1;

            GameObject dupe = Instantiate(pastCharacter);
            CharacterPlayback playback = dupe.GetComponent<CharacterPlayback>();
            playback.positions = new List<Vector3>(recorder.positions);
        }
        else
        {
            config.timeStep = 1;
        }
    }
}
