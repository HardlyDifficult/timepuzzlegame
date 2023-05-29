using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLifter : MonoBehaviour
{
    [SerializeField]
    GameObject[] activatables;
    [SerializeField]
    float deltaY;
    [SerializeField]
    float speed;

    float startingY;

    Rigidbody body;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        bool isActive = true;
        foreach(var activatableObject in activatables) {
            var activatable = activatableObject.GetComponent<IActivatable>();
            if(!activatable.isActive) {
                isActive = false;
                break;
            }
        }

        var targetY = startingY + (isActive ? deltaY : 0);
        body.MovePosition(Vector3.MoveTowards(body.position, new Vector3(body.position.x, targetY, body.position.z), speed));
    }
}
