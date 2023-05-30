using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerPlaybackMove : GenericPlayerMovement
{
    public FrameActionData[] transformData;
    int currentFrame;

    CurrentTimeline timeline;

    void Awake()
    {
        timeline = FindFirstObjectByType<CurrentTimeline>();
        var rewinder = FindFirstObjectByType<TransformRewinder>();
        transformData = new FrameActionData[timeline.timelineData.Count - rewinder.currentFrame];
        timeline.timelineData.CopyTo(rewinder.currentFrame, transformData, 0, transformData.Length);
    }

    new public void FixedUpdate()
    {
        currentFrame += timeline.isForwardTime ? 1 : -timeline.rewindSpeed;
        if (currentFrame >= transformData.Length || currentFrame < 0)
        {
            return;
        }

        var data = transformData[currentFrame];

        if (data.moveDirection != Vector2.zero)
        {
            Debug.Log("Set move direction: " + data.moveDirection + " at " + currentFrame);
        }

        var temp = data.moveDirection;
        inputDirection = new Vector3(temp.x, 0, temp.y);

        base.FixedUpdate();

        if (transform.position != data.position)
        {
            Debug.LogError(
                "Position mismatch: "
                    + transform.position
                    + " != "
                    + data.position
                    + " at "
                    + currentFrame
            );
        }
    }
}
