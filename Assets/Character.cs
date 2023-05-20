using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{

    public float moveSpeed = 5f;

    Vector2 moveDirection;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        
        rb.MovePosition(transform.position + new Vector3(moveDirection.x, 0, moveDirection.y) * Time.fixedDeltaTime * moveSpeed);
    }

    void OnWASD(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
    }
}
