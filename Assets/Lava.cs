using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Lava : MonoBehaviour
{

    Config config;

    private void Start()
    {
        config = FindFirstObjectByType<Config>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Lava");

        other.transform.position -= new Vector3(0, .5f, 0);

        // Freeze movement & sink a bit
        var character = other.gameObject.GetComponent<Character>();
        if (character && other.gameObject.GetComponent<Soul>() == null)
        {
            Destroy(character.gameObject);
            var position = character.transform.position;
            Instantiate(config.tombstonePrefab, position, character.transform.rotation);
            position.y += 4f;
            Instantiate(config.soulPrefab, position, Quaternion.identity);
        }
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
