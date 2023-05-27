using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Config
    [SerializeField]
    float speed;
    [SerializeField]
    [Range(0, 1)]
    float goAcceleration;
    [SerializeField]
    [Range(0, 1)]
    float stopAcceleration;

    // Components
    Rigidbody body;

    // Data
    Vector2 inputDirection;
    Vector2 targetDirection;
    Vector2 moveVelocity;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue value)
    {
        inputDirection = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        targetDirection = Vector2.Lerp(targetDirection, inputDirection, inputDirection == Vector2.zero ? stopAcceleration : goAcceleration);
        moveVelocity = (targetDirection - moveVelocity) * speed;
        body.MovePosition(transform.position + new Vector3(moveVelocity.x, 0, moveVelocity.y));
    }
}
