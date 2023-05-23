using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNT : MonoBehaviour
{
    Config config;
    int _connectedWires = 2;

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
        yield return new WaitForSeconds(2f);
        // check for defuse or explode

        if (connectedWires == 0)
        {
            // Defused
        }
        else
        {
            var character = FindFirstObjectByType<Character>();
            var position = character.transform.position;
            Destroy(character.gameObject);
            position.y += 4f;
            Instantiate(config.soulPrefab, position, Quaternion.identity);

            // Explode
            while (true)
            {
                transform.localScale = Vector3.one * 1.25f;
                yield return new WaitForSeconds(.1f);
                transform.localScale = Vector3.one;
                yield return new WaitForSeconds(.1f);
            }
        }
    }
}
