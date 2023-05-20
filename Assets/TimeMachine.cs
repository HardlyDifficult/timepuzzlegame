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
        CharacterRecorder recorder = other.GetComponent<CharacterRecorder>();
        if(!recorder) {
            return;
        }

        var pastMes = FindObjectsOfType<CharacterPlayback>();
        foreach(var r in pastMes) {
            r.index -= config.flashbackLength;
        }

        GameObject dupe = Instantiate(pastCharacter);
        CharacterPlayback playback = dupe.GetComponent<CharacterPlayback>();
        playback.positions = new List<Vector3>(recorder.positions);
    }
}
