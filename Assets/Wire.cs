using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    TNT tnt;
    bool isCut;

    private void Start()
    {
        tnt = GetComponentInParent<TNT>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isCut)
        {
            return;
        }
        isCut = true;

        Debug.Log("Wire");
        tnt.connectedWires--;
    }
}
