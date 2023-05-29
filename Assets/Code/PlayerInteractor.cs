using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : GenericInteractor
{
    public bool isInteracting;

    void OnFire(InputValue value)
    {
        isInteracting = value.Get<float>() == 1;
    }
    
    void FixedUpdate() {
        OnInteract(isInteracting);        
    }
}
