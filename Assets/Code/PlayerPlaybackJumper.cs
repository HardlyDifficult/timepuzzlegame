using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerPlaybackJumper : GenericJumper
{
    public FrameActionData[] transformData;
    int currentFrame;

    public float jumpForce = 30000;

    CurrentTimeline timeline;

    void Awake()
    {
        timeline = FindFirstObjectByType<CurrentTimeline>();
        var rewinder = FindFirstObjectByType<TransformRewinder>();
        transformData = new FrameActionData[timeline.timelineData.Count - rewinder.currentFrame];
        timeline.timelineData.CopyTo(rewinder.currentFrame, transformData, 0, transformData.Length);
    }

    void FixedUpdate()
    {
        currentFrame += timeline.isForwardTime ? 1 : -timeline.rewindSpeed;
        if (currentFrame >= transformData.Length || currentFrame < 0)
        {
            return;
        }

        var data = transformData[currentFrame];

        // TODO
        // transform.SetPositionAndRotation(data.position, data.rotation);

        if (data.actions.Contains(ActionType.Jump))
        {
            Jump();
        }
    }
}
