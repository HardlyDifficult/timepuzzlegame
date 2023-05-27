using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwistyNobby : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnStartInteraction()
    {
        animator.SetBool("opening", true);
    }

    void OnStopInteraction()
    {
        animator.SetBool("opening", false);
    }
}
