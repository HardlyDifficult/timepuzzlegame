using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GenericInteractor : MonoBehaviour
{
    List<GameObject> triggers = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        triggers.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        triggers.Remove(other.gameObject);
        other.gameObject.SendMessage("OnStopInteraction");
    }

    public void OnInteract(bool isInteracting)
    {
        if (triggers.Count == 0)
        {
            return;
        }

        // TODO how to choose if there are multiple in range?
        var trigger = triggers[0];

        if (isInteracting)
        {
            // TODO start/stop (walk away or stop pressing button)
            trigger.SendMessage("OnStartInteraction");
        }
        else
        {
            trigger.SendMessage("OnStopInteraction");
        }
    }
}
