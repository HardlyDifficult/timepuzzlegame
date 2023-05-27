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
    Vector3 inputDirection;
    Vector3 targetDirection;
    Vector3 moveVelocity;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue value)
    {
        var temp = value.Get<Vector2>();
        inputDirection = new Vector3(temp.x, 0, temp.y);
    }

    private void FixedUpdate()
    {
        targetDirection = Vector3.Lerp(targetDirection, transform.rotation * inputDirection, inputDirection == Vector3.zero ? stopAcceleration : goAcceleration);
        moveVelocity = (targetDirection - moveVelocity) * speed;
        body.MovePosition(transform.position + moveVelocity);
    }
}
