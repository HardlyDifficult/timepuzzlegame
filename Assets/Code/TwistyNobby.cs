using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwistyNobby : MonoBehaviour, IActivatable
{
    Animator animator;

    bool _isActive = false;
    public bool isActive {
        get {
            return _isActive;
        }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnStartInteraction()
    {
        Debug.Log("OnStartInteraction");
        _isActive = true;
        animator.SetBool("opening", _isActive);
    }

    void OnStopInteraction()
    {
        Debug.Log("OnStopInteraction");
        _isActive = false;
        animator.SetBool("opening", _isActive);
    }
}
