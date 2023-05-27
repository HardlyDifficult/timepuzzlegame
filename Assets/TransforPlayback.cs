using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransforPlayback : MonoBehaviour
{
    public TransformData[] transformData;
    int currentFrame;

    void Start()
    {
        var timeline = FindFirstObjectByType<CurrentTimeline>();
        var rewinder = FindFirstObjectByType<TransformRewinder>();
        transformData = new TransformData[timeline.transformData.Count - rewinder.currentFrame];
        timeline.transformData.CopyTo(rewinder.currentFrame, transformData, 0, transformData.Length);
    }

    void FixedUpdate()
    {
        if (currentFrame + 1 >= transformData.Length)
        {
            return;
        }
        currentFrame++;

        var data = transformData[currentFrame];
        transform.SetPositionAndRotation(data.position, data.rotation);
    }
}
