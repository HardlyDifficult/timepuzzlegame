using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class PlayerJumper : MonoBehaviour
{
    PlayerProperties props;
    Rigidbody body;

    bool isGrounded;

    [SerializeField]
    float force;

    bool shouldJump;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        props = GetComponent<PlayerProperties>();
    }

    private void OnJump()
    {
        shouldJump = true;
    }

    private void FixedUpdate()
    {
        if (shouldJump)
        {
            if (props.isGrounded)
            {
                body.AddForce(Vector3.up * force);
            }
            shouldJump = false;
        }
    }
}
