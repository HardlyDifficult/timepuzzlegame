using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class GenericJumper : MonoBehaviour
{
    PlayerProperties props;
    Rigidbody body;

    bool isGrounded;

    [SerializeField]
    float force;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        props = GetComponent<PlayerProperties>();
    }

    public void Jump()
    {
        if (props.isGrounded)
        {
            body.AddForce(Vector3.up * force);
        }
    }
}
