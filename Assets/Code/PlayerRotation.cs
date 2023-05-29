using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotation : MonoBehaviour
{
    Vector3 targetRotation;
    float inputRotation;
    float inputVerticle;

    [SerializeField]
    float clampY = 10;

    [SerializeField]
    float ySpeed = .1f;

    void Start() {
        targetRotation = transform.rotation.eulerAngles;
    }

    void OnLook(InputValue value)
    {
        inputRotation += value.Get<Vector2>().x;
        inputVerticle += value.Get<Vector2>().y;
    }

    private void FixedUpdate()
    {
        targetRotation += new Vector3(inputVerticle * ySpeed, inputRotation, 0);
        if(Mathf.Abs(targetRotation.x) > clampY) {
            targetRotation.x = Mathf.Sign(targetRotation.x) * clampY;
        } 
        transform.rotation = Quaternion.Euler(targetRotation);
        inputRotation = 0;
        inputVerticle = 0;
    }
}
