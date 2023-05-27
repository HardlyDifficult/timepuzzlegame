using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float inSeconds;

    private void OnEnable()
    {
        Destroy(gameObject, inSeconds);
    }
}
