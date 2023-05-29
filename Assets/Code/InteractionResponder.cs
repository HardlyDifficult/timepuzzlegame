using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionResponder : MonoBehaviour
{
    [SerializeField]
    GameObject[] activatables;
    [SerializeField]
    string animationParameter;

    Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
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

        animator.SetBool(animationParameter, isActive);
    }
}
