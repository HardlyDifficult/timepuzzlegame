using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField]
    GameObject[] activatables;

    Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    void FixedUpdate()
    {
        bool isOpen = true;
        foreach(var activatableObject in activatables) {
            var activatable = activatableObject.GetComponent<IActivatable>();
            if(!activatable.isActive) {
                isOpen = false;
                break;
            }
        }

        animator.SetBool("opening", isOpen);
    }
}
