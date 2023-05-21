using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    Config config;
    public float moveSpeed = 5f;
    public float acceleration = 0.01f;

    Vector2 moveDirection;
    Vector2 moveVelocity;

    CharacterController controller;

    void Start()
    {
        config = FindFirstObjectByType<Config>();
        controller = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        if (config.timeStep > 0)
        {
            moveVelocity = Vector2.Lerp(moveVelocity, moveDirection * moveSpeed, acceleration * Time.fixedDeltaTime);
            controller.SimpleMove(new Vector3(moveVelocity.x, 0, moveVelocity.y) * Time.fixedDeltaTime);
        }
    }

    void OnWASD(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
    }
}
