using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : GenericPlayerRotation
{
    void Start()
    {
        targetRotation = transform.rotation.eulerAngles;
    }

    void OnLook(InputValue value)
    {
        inputRotation += value.Get<Vector2>().x;
        inputVerticle += value.Get<Vector2>().y;
    }
}
