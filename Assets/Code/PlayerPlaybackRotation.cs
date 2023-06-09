using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerPlaybackRotation : GenericPlayerRotation
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

    void Start()
    {
        transform.rotation = Quaternion.Euler(timeline.initialRotation);
        targetRotation = timeline.initialRotation;
    }

    new public void FixedUpdate()
    {
        currentFrame += timeline.isForwardTime ? 1 : -timeline.rewindSpeed;
        if (currentFrame >= transformData.Length || currentFrame < 0)
        {
            return;
        }

        var data = transformData[currentFrame];

        if (data.lookDirection != Vector2.zero)
        {
            Debug.Log("Set look direction: " + data.lookDirection + " at " + currentFrame);
        }

        inputRotation = data.lookDirection.x;
        inputVerticle = data.lookDirection.y;

        // if (transform.rotation != data.rotation)
        // {
        //     Debug.LogError(
        //         "Rotation mismatch before update: "
        //             + transform.rotation.eulerAngles
        //             + " != "
        //             + data.rotation.eulerAngles
        //             + " at "
        //             + currentFrame
        //     );
        // }

        base.FixedUpdate();

        if (transform.rotation != data.rotation)
        {
            Debug.LogError(
                "Rotation mismatch after update: "
                    + transform.rotation.eulerAngles
                    + " != "
                    + data.rotation.eulerAngles
                    + " at "
                    + currentFrame
            );
        }
    }
}
