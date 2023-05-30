using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GenericPlayerRotation : MonoBehaviour
{
    public Vector3 targetRotation;
    public float inputRotation;
    public float inputVerticle;

    [SerializeField]
    float clampY = 10;

    [SerializeField]
    float ySpeed = .1f;

    public void FixedUpdate()
    {
        targetRotation += new Vector3(inputVerticle * ySpeed, inputRotation, 0);
        if (Mathf.Abs(targetRotation.x) > clampY)
        {
            targetRotation.x = Mathf.Sign(targetRotation.x) * clampY;
        }
        transform.rotation = Quaternion.Euler(targetRotation);
        inputRotation = 0;
        inputVerticle = 0;
    }
}
