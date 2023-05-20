using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRecorder : MonoBehaviour
{
    public List<Vector3> positions = new List<Vector3>();

    void FixedUpdate()
    {   
        positions.Add(transform.position);
    }
}
