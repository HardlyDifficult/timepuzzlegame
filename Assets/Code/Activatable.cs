using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activatable : MonoBehaviour, IActivatable
{
    Animator animator;

    [SerializeField]
    string animationParameter;

    bool _isActive = false;
    public bool isActive
    {
        get { return _isActive; }
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnStartInteraction()
    {
        _isActive = true;
        animator.SetBool(animationParameter, _isActive);
    }

    void OnStopInteraction()
    {
        _isActive = false;
        animator.SetBool(animationParameter, _isActive);
    }
}
