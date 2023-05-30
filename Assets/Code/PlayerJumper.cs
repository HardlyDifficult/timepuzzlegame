using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class PlayerJumper : GenericJumper
{
    bool shouldJump;

    private void OnJump()
    {
        shouldJump = true;
    }

    private void FixedUpdate()
    {
        if (shouldJump)
        {
            Jump();
            shouldJump = false;
        }
    }
}
