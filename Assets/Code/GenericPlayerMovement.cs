using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GenericPlayerMovement : MonoBehaviour
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
    PlayerProperties props;

    // Data
    internal Vector3 inputDirection;
    Vector3 targetDirection;
    Vector3 moveVelocity;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
        props = GetComponent<PlayerProperties>();
    }

    public void FixedUpdate()
    {
        if (props.isGrounded)
        {
            targetDirection = Vector3.Lerp(
                targetDirection,
                transform.rotation * inputDirection,
                inputDirection == Vector3.zero ? stopAcceleration : goAcceleration
            );
        }
        moveVelocity = (targetDirection - moveVelocity) * speed;
        body.MovePosition(transform.position + moveVelocity);
    }
}
