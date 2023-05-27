using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    public bool isGrounded
    {
        get
        {
            return Physics.SphereCast(transform.position, .10f, Vector3.down, out RaycastHit hit, 1);
        }
    }
}
