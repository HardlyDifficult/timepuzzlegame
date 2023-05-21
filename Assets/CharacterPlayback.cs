using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPlayback : MonoBehaviour
{
    public List<Vector3> positions;

    Config config;
    CharacterRecorder recorder;
    public bool isMainCharacter;

    [SerializeField]
    int minFrame;

    private void OnEnable()
    {
        config = FindObjectOfType<Config>();
        recorder = FindFirstObjectByType<CharacterRecorder>();

        if (isMainCharacter)
        {
            positions = recorder.positions;
        }
        else
        {
            positions = new List<Vector3>(recorder.positions);
        }

        minFrame = -1; // unknown

        if (config.currentFrame < positions.Count)
        {
            transform.position = positions[config.currentFrame];
        }
    }

    void FixedUpdate()
    {
        if (!isMainCharacter)
        {
            // Min is the frame when I stop traveling back in time
            if (minFrame == -1 && config.timeStep > 0)
            {
                minFrame = config.currentFrame;
            }

            if (minFrame == -1 && config.currentFrame <= 0)
            {
                minFrame = 0;
            }
            if (config.currentFrame >= positions.Count || config.currentFrame < minFrame)
            {
                // Out of time-bounds

                GetComponent<Renderer>().enabled = false;
                GetComponent<Collider>().enabled = false;

                return;
            }

            GetComponent<Renderer>().enabled = true;
            GetComponent<Collider>().enabled = true;
        }

        if (!isMainCharacter || isMainCharacter && config.timeStep < 0)
        {
            Debug.Log(positions.Count + "count + frame: " + config.currentFrame + " isMain" + isMainCharacter);
            transform.position = positions[config.currentFrame];
        }
    }
}
