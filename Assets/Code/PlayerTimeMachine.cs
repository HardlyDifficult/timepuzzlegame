using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTimeMachine : MonoBehaviour
{
    [SerializeField]
    GameObject backwardsBobPrefab;

    void OnRewindTime(InputValue value)
    {
        var isRewinding = value.Get<float>() == 1;
        if (isRewinding)
        {
            Instantiate(backwardsBobPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
