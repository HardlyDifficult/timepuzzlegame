using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Button : MonoBehaviour
{
    bool isInRange = false;
    public bool isPressed = false;
    public Vector3 pressedOffset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnAction()
    {
        // TODO later
    }

    void OnTriggerEnter()
    {
        isInRange = true;
        if (isInRange && !isPressed)
        {
            transform.position += pressedOffset;
            isPressed = true;
        }
    }


    // TODO no exit when the clone is disabled while in range
    void OnTriggerExit()
    {
        if (isPressed)
        {
            transform.position -= pressedOffset;
            isPressed = false;
        }
        isInRange = false;
    }
}
