using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
    Config config;

    private void Start()
    {
        config = FindFirstObjectByType<Config>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Clone>() == null)
        {
            return;
        }

        Destroy(collision.gameObject);
        Destroy(gameObject);
        Instantiate(config.characterPrefab, collision.transform.position, collision.transform.rotation);
    }
}
