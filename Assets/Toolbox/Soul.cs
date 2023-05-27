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

    private void OnEnable()
    {
        var cameraScript = FindAnyObjectByType<ThirdPersonCamera>();
        //cameraScript._followTarget = transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Clone>() == null)
        {
            return;
        }

        var newGuy = Instantiate(config.characterPrefab, collision.transform.position, collision.transform.rotation);

        for (int i = 0; i < collision.gameObject.transform.childCount; i++)
        {
            var child = collision.gameObject.transform.GetChild(i);
            child.transform.SetParent(newGuy.transform);
        }
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
