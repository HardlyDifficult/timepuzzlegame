using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPlayback : MonoBehaviour
{
    public List<Vector3> positions;
    int index;
    int oldestIndex = -1;
    Config config;

    void Start()
    {
        config = FindObjectOfType<Config>();

        index = positions.Count - 1;
        transform.position = positions[index];
    }

    void FixedUpdate()
    {
        if (oldestIndex == -1 && config.timeStep > 0)
        {
            oldestIndex = index;
        }

        index += config.timeStep;

        if (index >= positions.Count || index < 0 || (oldestIndex >= 0 && index < oldestIndex))
        {
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider>().enabled = false;
            return;
        }

        GetComponent<Renderer>().enabled = true;
        GetComponent<Collider>().enabled = true;

        transform.position = positions[index];
    }
}
