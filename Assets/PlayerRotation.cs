using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{
    float inputRotation;

    void OnLook(InputValue value)
    {
        inputRotation += value.Get<Vector2>().x;
    }

    private void FixedUpdate()
    {
        transform.rotation *= Quaternion.Euler(0, inputRotation, 0);
        inputRotation = 0;
    }
}
