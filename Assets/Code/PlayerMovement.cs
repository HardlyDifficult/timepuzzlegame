using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : GenericPlayerMovement
{
    void OnMove(InputValue value)
    {
        var temp = value.Get<Vector2>();
        inputDirection = new Vector3(temp.x, 0, temp.y);
    }
}
