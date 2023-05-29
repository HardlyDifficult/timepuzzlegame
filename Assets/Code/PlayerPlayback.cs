using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlayback : GenericInteractor
{
    public FrameActionData[] transformData;
    int currentFrame;

    CurrentTimeline timeline;

    void Awake()
    {
        timeline = FindFirstObjectByType<CurrentTimeline>();
        var rewinder = FindFirstObjectByType<TransformRewinder>();
        transformData = new FrameActionData[timeline.timelineData.Count - rewinder.currentFrame];
        Debug.Log(rewinder.currentFrame);
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
        transform.SetPositionAndRotation(data.position, data.rotation);

        OnInteract(data.isInteracting);
    }
}
