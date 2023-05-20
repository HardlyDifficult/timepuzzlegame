using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMachine : MonoBehaviour
{
    public GameObject pastCharacter;
    Config config;

    void Start() {
        config = FindObjectOfType<Config>();
    }

    void OnTriggerEnter(Collider other) {
        config.timeStep = -1;

        CharacterRecorder recorder = other.GetComponent<CharacterRecorder>();
        if(!recorder) {
            return;
        }

        GameObject dupe = Instantiate(pastCharacter);
        CharacterPlayback playback = dupe.GetComponent<CharacterPlayback>();
        playback.positions = new List<Vector3>(recorder.positions);
    }

    void OnTriggerExit() {
        config.timeStep = 1;
    }
}
