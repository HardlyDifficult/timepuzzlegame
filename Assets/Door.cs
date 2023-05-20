using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isUp;
    public Button[] buttons;
    public float openOffset;

    void Update()
    {
        foreach(Button button in buttons) {
            if(!button.isPressed) {
                if(isUp) {
                    transform.position -= new Vector3(0, openOffset, 0);
                    isUp = false;
                }

                return;
            }
        }

        if(isUp) {
            return;
        }
        
        // All are pressed
        transform.position += new Vector3(0, openOffset, 0);
        isUp = true;
    }
}
