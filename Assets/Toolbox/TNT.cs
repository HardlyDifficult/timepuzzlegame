using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNT : MonoBehaviour
{
    Config config;
    int _connectedWires = 2;

    int explosionFrame;

    public int connectedWires
    {
        get
        {
            return _connectedWires;
        }
        set
        {
            _connectedWires = value;
            StartCoroutine(onWireCut());
        }
    }

    private void Start()
    {
        config = FindFirstObjectByType<Config>();
    }

    IEnumerator onWireCut()
    {
        Debug.Log("Connected wires " + connectedWires);
        yield return new WaitForSeconds(2f);
        // check for defuse or explode

        explosionFrame = config.currentFrame;

        if (connectedWires == 0)
        {
            // Defused
            Destroy(gameObject);
        }
        else
        {
            var character = FindFirstObjectByType<Character>();
            var position = character.transform.position;
            Destroy(character.gameObject);
            Instantiate(config.tombstonePrefab, position, Quaternion.identity);
            position.y += 4f;
            Instantiate(config.soulPrefab, position, Quaternion.identity);

            // Explode
            Instantiate(config.explosionPrefab, transform.position, transform.rotation);
            while (config.currentFrame >= explosionFrame)
            {
                transform.localScale = Vector3.one * 1.25f;
                yield return new WaitForSeconds(.1f);
                transform.localScale = Vector3.one;
                yield return new WaitForSeconds(.1f);
            }
            transform.localScale = Vector3.one * 3;
            _connectedWires = 2;
        }
    }
}