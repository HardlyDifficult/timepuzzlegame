using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatableOnTrigger : MonoBehaviour, IActivatable
{
    Animator animator;

    [SerializeField]
    string animationParameter;

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

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        _isActive = true;
        animator.SetBool(animationParameter, _isActive);
    }

    void OnTriggerExit(Collider other)
    {
        _isActive = false;
        animator.SetBool(animationParameter, _isActive);
    }    

}
