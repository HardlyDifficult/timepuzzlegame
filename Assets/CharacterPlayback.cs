using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPlayback : MonoBehaviour
{
    Rigidbody rb;
    public List<Vector3> positions;
    public int index = 0;
    Config config;

    void Start() {
        config = FindObjectOfType<Config>();
        rb = GetComponent<Rigidbody>();

        index = positions.Count - 1;
    }

    void FixedUpdate()
    {
        index += config.timeStep;
        if(index >= positions.Count || index < 0) {
            GetComponent<Renderer>().enabled = false;
            return;
        }
        
        GetComponent<Renderer>().enabled = true;

        Vector3 position = positions[index];
        // rb.MovePosition(position);
        transform.position = position;
    }
}
