using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransforPlayback : MonoBehaviour
{
    public TransformData[] transformData;
    int currentFrame;

    CurrentTimeline timeline;

    void Awake()
    {
        timeline = FindFirstObjectByType<CurrentTimeline>();
        var rewinder = FindFirstObjectByType<TransformRewinder>();
        transformData = new TransformData[timeline.transformData.Count - rewinder.currentFrame];
        Debug.Log(rewinder.currentFrame);
        timeline.transformData.CopyTo(rewinder.currentFrame, transformData, 0, transformData.Length);
    }

    void FixedUpdate()
    {
        currentFrame += timeline.isForwardTime ? 1 : -1;
        if (currentFrame >= transformData.Length || currentFrame < 0)
        {
            return;
        }

        var data = transformData[currentFrame];
        transform.SetPositionAndRotation(data.position, data.rotation);
    }
}
