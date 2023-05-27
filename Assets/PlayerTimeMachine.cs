using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTimeMachine : MonoBehaviour
{
    [SerializeField]
    GameObject historicalBoboPrefab;

    void OnRewindTime(InputValue value)
    {
        var isRewinding = value.Get<float>() == 1;
        Debug.Log(isRewinding);
    }
}
