using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Lava");
        // Freeze movement & sink a bit
        var character = other.gameObject.GetComponent<Character>();
        if (character)
        {
            other.gameObject.GetComponent<Character>().enabled = false;
        }

        other.transform.position -= new Vector3(0, .5f, 0);
    }

    private void OnTriggerExit(Collider other)
    {
        var character = other.gameObject.GetComponent<Character>();
        if (character)
        {
            other.gameObject.GetComponent<Character>().enabled = true;
        }
    }
}
